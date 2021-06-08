using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCheck.Model.DataModel {
    public class OrderItem {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Memo { get; set; }

        public int Cost { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
