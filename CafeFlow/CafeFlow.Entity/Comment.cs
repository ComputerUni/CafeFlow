using CafeFlow.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Comment : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; } = true;
    }
}
