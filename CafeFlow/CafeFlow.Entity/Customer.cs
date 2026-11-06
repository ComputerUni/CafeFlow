using CafeFlow.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Customer : BaseEntity
    {
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
