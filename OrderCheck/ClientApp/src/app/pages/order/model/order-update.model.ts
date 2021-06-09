import { OrderStatus } from "../../../shared-models/enum/order-status.enum";

export class OrderUpdateModel {
  status: OrderStatus;
  orderIds: string[];
}
