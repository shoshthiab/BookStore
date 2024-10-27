using BookStore.Data;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.ViewComponents
{
    public class AdsSliderViewComponent : ViewComponent
    {
        private AppDbContext db;
        public AdsSliderViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.AdsSliders);
        }


    }
}
