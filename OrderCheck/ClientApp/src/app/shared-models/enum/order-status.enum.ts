export enum OrderStatus {
  NotSet,
  // 訂單成立
  OrderEstablished,
  // 等待付款
  PaymentCompleted,
  // 等待運送
  ToBeShipped,
  // 訂單送達
  OrderDelivery,
  // 訂單完成
  Complete,
  // 訂單取消
  Cancel
}
