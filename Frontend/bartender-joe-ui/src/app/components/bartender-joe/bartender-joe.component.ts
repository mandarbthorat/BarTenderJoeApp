import { Component,OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-bartender-joe',
  templateUrl: './bartender-joe.component.html',
  styleUrls: ['./bartender-joe.component.scss']
})
export class BartenderJoeComponent {
  productId: string = '';
   productResponse: string = 'INVALID PROD TP';
  readyMsg: string = 'CANNOT MIX IT';
  mixResult: string = '';

  constructor(private service: ProductService) {
     this.productResponse = 'INVALID PROD TP';
    this.readyMsg = 'CANNOT MIX IT';
  }

  ngOnInit() {
    // Call once to set initial state based on null value
    this.onInputChange();
  }

  onInputChange() {
    this.readyMsg = '';
    this.mixResult = '';
      this.service.validateProduct(Number(this.productId)).subscribe({
         next: (res: any) => {
           this.productResponse = res.productResponse?.toUpperCase() ?? 'INVALID PROD TP';
          this.readyMsg = res.readyMsg?.toUpperCase() ?? 'CANNOT MIX IT';
        },
        error: (err) => {
          console.error(err);
          this.productResponse = 'INVALID PROD TP';
          this.readyMsg = 'CANNOT MIX IT';
          this.mixResult = '';
        }
      });
   
  }

  clearInput() {
     this.productId = '';
  this.productResponse = 'INVALID PROD TP';
  this.readyMsg = 'CANNOT MIX IT';
  this.mixResult = '';
  }

  mixDrink() {
  if (this.productResponse !== 'INVALID PROD TP') {
    this.service.mixDrink(Number(this.productId)).subscribe({
      next: (res: any) => {
        this.mixResult = res.message;
      },
      error: () => {
        this.mixResult = 'Mixing failed';
      }
    });
  } else {
    this.mixResult = 'Cannot mix invalid product';
  }
}

}
