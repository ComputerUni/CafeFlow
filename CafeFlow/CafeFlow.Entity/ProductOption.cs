using CafeFlow.Entity.Common;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class ProductOption : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public OptionType OptionType { get; set; }
        public decimal AdditionalPrice { get; set; }
    }
}
