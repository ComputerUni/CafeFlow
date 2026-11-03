using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.OrderDetail
{
    public class OrderDetailListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AdditionalPrice { get; set; }
        public string? SelectedOptions { get; set; }
    }
}
