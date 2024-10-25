using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ControlPanel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
