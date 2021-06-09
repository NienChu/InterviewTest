using OrderCheck.Model.Enum;
using System;

namespace OrderCheck.Model.ViewModel {
    public class ProductViewModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
    }
}
