using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeFlow.Entity.Enums
{
    public enum NotificationTarget
    {
        [Display(Name = "Mutfak")]
        Kitchen = 1,

        [Display(Name = "Kasiyer")]
        Cashier = 2,

        [Display(Name = "Müşteri")]
        Customer = 3

    }
}
