using System;

namespace OrderCheck.Model.ViewModel {
    public class OrderItemViewModel {
        public Guid Id { get; set; }
        public Guid ProductId {get; set;}
        public string Name { get; set; }
    }
}
