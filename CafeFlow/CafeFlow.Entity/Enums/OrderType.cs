using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeFlow.Entity.Enums
{
    public enum OrderType
    {
        [Display(Name = "Teslimat")]
        Online = 1,

        [Display(Name = "Gel-Al")]
        TakeAway = 2,

        [Display(Name = "QR Masa")]
        Table = 3

    }
}
