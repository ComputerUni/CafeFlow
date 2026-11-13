using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Favorite
{
    public class FavoriteProductDto
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
    }
}
