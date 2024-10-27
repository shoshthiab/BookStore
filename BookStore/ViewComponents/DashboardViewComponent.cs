using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.ViewComponents
{
	public class DashboardViewComponent : ViewComponent
	{
		private AppDbContext db;
		public DashboardViewComponent(AppDbContext _db)
		{
			db = _db;
		}
		public IViewComponentResult Invoke()
		{
			var modelCounts = new
			{
				AdsCount = db.AdsSliders.Count(),
				BooksCount = db.Books.Count()+1598,
				AuthorsCount = db.Authors.Count()+500,
				EssaysCount = db.Essays.Count()+800
			};

			return View(modelCounts);
		}


	}
}
