using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BestStoreMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public CustomersController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var customers = context.Customer.OrderByDescending(c => c.Id).ToList();
            return View(customers);
        }
       
        public IActionResult Details(int id)
        {
            var customer = context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customer.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                context.Update(customer);
                context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = context.Customer.Find(id);
            context.Customer.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}



