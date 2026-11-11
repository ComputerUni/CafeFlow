using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class AdminOrderItemDto
    {
        public string ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AdditionalPrice { get; set; }
        public decimal TotalLinePrice => (UnitPrice + AdditionalPrice) * Quantity;
        public string? SelectedOptions { get; set; }
    }
}
