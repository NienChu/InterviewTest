import { OrderStatus } from "../../../shared-models/enum/order-status.enum";
import { OrderItemModel } from "./order-item.model";

export class OrderModel {
  id: string;
  orderId: string;
  price: number;
  cost: number;
  status: OrderStatus;
  items: OrderItemModel[];
}
