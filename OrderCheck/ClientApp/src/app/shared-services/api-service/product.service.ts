import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ProductModel } from '../../pages/order/model/Product.model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private url = 'api/Product';

  constructor(private httpClient: HttpClient) { }

  public getProdetail(id: string) {
    return this.httpClient.get<ProductModel>(`${this.url}/${id}`)
      .pipe(
        catchError(res => throwError(res))
      );
  }
}
