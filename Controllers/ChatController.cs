// Controllers/ChatController.cs
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

