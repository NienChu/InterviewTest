using OrderCheck.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCheck.Model.DataModel {
    public class Order {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName="nvarchar(50)")]
        public string OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public Guid OwnerId { get; set; }

        [Column(TypeName="nvarchar(MAX)")]
        public string Memo { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime CreateDateTime { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime? CompleteDateTime { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
