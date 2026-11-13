using CafeFlow.Entity.Common;

namespace CafeFlow.Entity
{
    public class Favorite : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
 