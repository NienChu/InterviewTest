import { Component, OnInit } from '@angular/core';
import { OrderStatus } from '../../../shared-models/enum/order-status.enum';
import { OrderService } from '../../../shared-services/api-service/order.service';
import { OrderModel } from '../model/order.model';

export class orderSelectModel extends OrderModel {
  selected: boolean;

  constructor(model: OrderModel) {
    super();
    this.id = model.id;
    this.orderId = model.orderId;
    this.price = model.price;
    this.cost = model.cost
    this.status = model.status
    this.items = model.items
  }
}

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {

  dataSource: orderSelectModel[];
  displayedColumns = ['selected', 'orderId', 'item', 'price', 'cost', 'status'];

  orderStatus = OrderStatus;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrderData();
  }

  getOrderData() {
    this.orderService.getOrderList()
      .subscribe(res => {
        this.dataSource = res.map(o => new orderSelectModel(o));
      });
  }

  onStatusChange() {
    const ids = this.dataSource.filter(d => d.selected).map(d => d.id);

    this.orderService.updateOrdersStatus(OrderStatus.ToBeShipped, ids)
      .subscribe(res => {
        this.getOrderData();
      });
  }
}
