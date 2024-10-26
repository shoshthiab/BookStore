using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ControlPanel : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly AppDbContext _context;

        public ControlPanel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var modelCounts = new
            {
                AdsCount = _context.AdsSliders.Count(),
                BooksCount = _context.Books.Count(),
                AuthorsCount = _context.Authors.Count(),
                EssaysCount = _context.Essays.Count()
            };

            return View(modelCounts);
        }

    }
}
