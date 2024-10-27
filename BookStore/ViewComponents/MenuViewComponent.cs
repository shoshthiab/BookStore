using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private AppDbContext db;
        public MenuViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Menus);
        }


    }
}
