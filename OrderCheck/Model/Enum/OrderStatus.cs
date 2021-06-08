using System.ComponentModel.DataAnnotations;

namespace OrderCheck.Model.Enum {
    public enum OrderStatus {
        NotSet,
        [Display(Name= "訂單成立")]
        OrderEstablished,
        [Display(Name= "等待付款")]
        PaymentCompleted,
        [Display(Name= "等待運送")]
        ToBeShipped,
        [Display(Name= "訂單送達")]
        OrderDelivery,
        [Display(Name= "訂單完成")]
        Complete,
        [Display(Name= "訂單取消")]
        Cancel
    }
}
