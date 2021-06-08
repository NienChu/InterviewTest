using OrderCheck.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCheck.Model.DataModel {
    public class Product {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public ProductType Type { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime CreateDateTime { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime UpdateDateTime { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
