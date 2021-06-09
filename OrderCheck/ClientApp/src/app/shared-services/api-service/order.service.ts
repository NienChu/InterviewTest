import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { OrderModel } from '../../pages/order/model/order.model';
import { OrderStatus } from '../../shared-models/enum/order-status.enum';
import { OrderUpdateModel } from '../../pages/order/model/order-update.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private url = 'api/Order';

  constructor(private httpClient: HttpClient) { }

  public getOrderList() {
    return this.httpClient.get<OrderModel[]>(`${this.url}`)
      .pipe(
        catchError(res => throwError(res))
      );
  }

  public updateOrdersStatus(status: OrderStatus, ids: string[]) {
    let model = {
      status: status,
      orderIds: ids
    } as OrderUpdateModel;

    return this.httpClient.put(`${this.url}`, JSON.stringify(model))
      .pipe(
        catchError(res => throwError(res))
      );
  }
}
