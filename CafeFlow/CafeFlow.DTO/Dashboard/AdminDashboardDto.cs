using CafeFlow.DTO.Order;
using CafeFlow.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Dashboard
{
    public class AdminDashboardDto
    {
        public decimal TotalRevenue { get; set; }
        public decimal TodayRevenue { get; set; }
        public int TotalOrderCount { get; set; }
        public int ActiveProductCount { get; set; }
        public int CustomerCount { get; set; }
        public int UnreadNotificationCount { get; set; }
        public Dictionary<string, int> ProductCountByCategory { get; set; } = new();
        public List<ProductListDto> LowStockProducts { get; set; } = new();
        public List<OrderListDto> RecentOrders { get; set; } = new();
    }
}
