import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BartenderJoeComponent } from './bartender-joe.component';
import { ProductService } from '../../services/product.service';
import { FormsModule } from '@angular/forms';
import { of, throwError } from 'rxjs';

describe('BartenderJoeComponent (Jasmine)', () => {
  let component: BartenderJoeComponent;
  let fixture: ComponentFixture<BartenderJoeComponent>;
  let productServiceSpy: jasmine.SpyObj<ProductService>;

  beforeEach(async () => {
    const spy = jasmine.createSpyObj('ProductService', ['validateProduct', 'mixDrink']);

    await TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [BartenderJoeComponent],
      providers: [{ provide: ProductService, useValue: spy }]
    }).compileComponents();

    fixture = TestBed.createComponent(BartenderJoeComponent);
    component = fixture.componentInstance;
    productServiceSpy = TestBed.inject(ProductService) as jasmine.SpyObj<ProductService>;

    // 👇 Default mock so validateProduct always returns an observable for tests that don't explicitly override it
    productServiceSpy.validateProduct.and.returnValue(of({ productResponse: 'INVALID PROD TP', readyMsg: 'CANNOT MIX IT' }));

    fixture.detectChanges();
  });

  it('should create component with default state', () => {
    expect(component).toBeTruthy();
    expect(component.productResponse).toBe('INVALID PROD TP');
    expect(component.readyMsg).toBe('CANNOT MIX IT');
  });

  it('should update productResponse and readyMsg for valid input', () => {
    productServiceSpy.validateProduct.and.returnValue(of({ productResponse: 'MILK', readyMsg: 'READY TO MIX' }));

    component.productId = '1';
    component.onInputChange();

    expect(productServiceSpy.validateProduct).toHaveBeenCalledWith(1);
    expect(component.productResponse).toBe('MILK');
    expect(component.readyMsg).toBe('READY TO MIX');
  });

  it('should set productResponse to INVALID PROD TP for invalid input', () => {
    productServiceSpy.validateProduct.and.returnValue(of({ productResponse: 'INVALID PROD TP', readyMsg: 'CANNOT MIX IT' }));

    component.productId = '9';
    component.onInputChange();

    expect(component.productResponse).toBe('INVALID PROD TP');
    expect(component.readyMsg).toBe('CANNOT MIX IT');
  });

  it('should handle API error in onInputChange gracefully', () => {
    productServiceSpy.validateProduct.and.returnValue(throwError(() => new Error('API error')));

    component.productId = '1';
    component.onInputChange();

    expect(component.productResponse).toBe('INVALID PROD TP');
    expect(component.readyMsg).toBe('CANNOT MIX IT');
  });

  it('should reset values on clearInput()', () => {
    // No need to override validateProduct here due to default mock in beforeEach
    component.productId = '1';
    component.productResponse = 'MILK';
    component.readyMsg = 'READY TO MIX';
    component.mixResult = 'Some Drink';

    component.clearInput();

    expect(component.productId).toBe('');
    expect(component.productResponse).toBe('INVALID PROD TP');
    expect(component.readyMsg).toBe('CANNOT MIX IT');
    expect(component.mixResult).toBe('');
  });

  it('should call mixDrink and update mixResult when product is valid', () => {
    productServiceSpy.mixDrink.and.returnValue(of({ message: 'Milkshake is ready!' }));
    component.productId = '1';
    component.productResponse = 'MILK';

    component.mixDrink();

    expect(productServiceSpy.mixDrink).toHaveBeenCalledWith(1);
    expect(component.mixResult).toBe('Milkshake is ready!');
  });

  it('should not call mixDrink service when product is invalid', () => {
  // ensure spy exists and will not error if called
  productServiceSpy.mixDrink.and.returnValue(of({ message: '' }));

  component.productId = '';
  component.productResponse = 'INVALID PROD TP';

  component.mixDrink();

  expect(productServiceSpy.mixDrink).not.toHaveBeenCalled();
  expect(component.mixResult).toBe('Cannot mix invalid product');
});

});
