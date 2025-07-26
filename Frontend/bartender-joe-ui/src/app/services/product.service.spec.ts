import { TestBed } from '@angular/core/testing';
import { ProductService } from './product.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../../environments/environment';

describe('ProductService (Jasmine)', () => {
  let service: ProductService;
  let httpMock: HttpTestingController;
  const gatewayUrl = environment.gatewayUrl;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductService]
    });
    service = TestBed.inject(ProductService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('validateProduct should call GET and return data', () => {
    const mockResponse = { productResponse: 'MILK', readyMsg: 'READY TO MIX' };

    service.validateProduct(1).subscribe(res => {
      expect(res).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(`${gatewayUrl}/products/1`);
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });

  it('mixDrink should call POST and return message', () => {
    const mockMixResponse = { message: 'Milkshake is ready!' };

    service.mixDrink(1).subscribe(res => {
      expect(res).toEqual(mockMixResponse);
    });

    const req = httpMock.expectOne(`${gatewayUrl}/mix`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ productId: 1 });
    req.flush(mockMixResponse);
  });
});
