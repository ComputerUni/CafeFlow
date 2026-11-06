using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace CafeFlow.Entity.Enums
{
    public enum OptionType
    {
        [Display(Name = "Boyut")]
        Size = 0,

        [Display(Name = "Süt Çeşidi")]
        MilkType = 1,

        [Display(Name = "Ekstra")]
        Extra = 2,

        [Display(Name = "Sıcaklık")]
        Temperature = 3,
    }
}
