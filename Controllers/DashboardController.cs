using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BestStoreMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalCustomers = await _context.Customer.CountAsync(),
                TotalOrders = await _context.Order.CountAsync(),
                TotalProducts = await _context.Products.CountAsync(),
                RecentOrders = await _context.Order
                                        .Include(o => o.Customer)
                                        .Include(o => o.OrderItems)
                                        .ThenInclude(oi => oi.Product)
                                        .OrderByDescending(o => o.OrderDate)
                                        .Take(5)
                                        .ToListAsync()
            };

            return View(viewModel);
        }
    }
}

