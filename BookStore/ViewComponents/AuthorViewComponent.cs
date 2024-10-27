using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    public class AuthorViewComponent : ViewComponent
    {
        private AppDbContext db;
        public AuthorViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Authors);
        }


    }
}
