using OrderCheck.Model.Enum;
using System;
using System.Collections.Generic;

namespace OrderCheck.Model.ViewModel {
    public class OrderUpdateViewModel {
        public OrderStatus Status { get; set; }
        public List<Guid> OrderIds { get; set; }
    }
}
