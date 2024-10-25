using BookStore.Data;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.ViewComponents
{
    public class AdsSliderViewCompnent : ViewComponent
    {
        private AppDbContext db;
        public AdsSliderViewCompnent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.AdsSliders);
        }


    }
}
