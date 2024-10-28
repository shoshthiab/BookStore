using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    public class EssayViewComponent : ViewComponent
    {
        private AppDbContext db;
        public EssayViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Essays);
        }


    }
}
