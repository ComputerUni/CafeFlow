using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class OrderDetailConfirmDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AdditionalPrice { get; set; }      
        public string? SelectedOptions { get; set; }
    }
}
