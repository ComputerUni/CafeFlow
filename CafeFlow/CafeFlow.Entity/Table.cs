using CafeFlow.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Table : BaseEntity
    {
        public int TableNumber { get; set; }
        public string QRCode { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
