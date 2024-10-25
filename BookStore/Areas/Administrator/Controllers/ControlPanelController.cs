using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Administrator.Controllers
{
    public class ControlPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
