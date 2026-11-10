using CafeFlow.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsFeatured { get; set; } = false;
        public bool? IsCustomizable { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
