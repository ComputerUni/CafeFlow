using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeFlow.Entity.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Alındı")]
        Received = 1,

        [Display(Name = "Hazırlanıyor")]
        Preparing = 2,

        [Display(Name = "Hazır")]
        Ready = 3,

        [Display(Name = "Teslim Edildi")]
        Delivered = 4,

        [Display(Name = "İptal")]
        Cancelled = 5
    }
}
