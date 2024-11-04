using BookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.ViewComponents
{
	public class BookViewComponent : ViewComponent
	{
		private AppDbContext db;
		public BookViewComponent(AppDbContext _db)
		{
			db = _db;
		}
		public IViewComponentResult Invoke()
		{
            return View(db.Books.OrderByDescending(b => b.CreationDate).ToList());

        }


    }
}
