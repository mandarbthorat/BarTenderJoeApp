import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
@Injectable({ providedIn: 'root' })
export class ProductService {
  private gatewayUrl =  environment.gatewayUrl;//'https://localhost:7133/gateway';

  constructor(private http: HttpClient) {}

  validateProduct(id: number): Observable<any> {
    return this.http.get(`${this.gatewayUrl}/products/${id}`);
  }

  mixDrink(id: number): Observable<any> {
    return this.http.post(`${this.gatewayUrl}/mix`, { productId: id });
  }
}
