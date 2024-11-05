using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    public class QuoteViewComponent : ViewComponent
    {
        private AppDbContext db;
        public QuoteViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Quotes.OrderByDescending(b => b.CreationDate).ToList());

        }
    }
}
