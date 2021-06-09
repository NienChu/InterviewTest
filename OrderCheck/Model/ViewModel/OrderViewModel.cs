using OrderCheck.Model.Enum;
using System;
using System.Collections.Generic;

namespace OrderCheck.Model.ViewModel {
    public class OrderViewModel {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public int Price { get; set; }
        public int Cost { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
    }
}
