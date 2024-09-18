﻿namespace BestStoreMVC.Models
{
    public class DashboardViewModel
    {
        public int TotalCustomers { get; set; }
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }
        public List<Order> RecentOrders { get; set; }
    }
}

