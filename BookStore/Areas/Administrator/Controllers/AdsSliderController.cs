using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using static BookStore.Models.Book;

namespace BookStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdsSliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdsSliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/AdsSlider
        public async Task<IActionResult> Index()
        {
            var ads = _context.AdsSliders.ToList().OrderByDescending(ad => ad.CreationDate);
            return View(ads);
        }

        // GET: Administrator/AdsSlider/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsSlider = await _context.AdsSliders
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (adsSlider == null)
            {
                return NotFound();
            }

            return View(adsSlider);
        }

        // GET: Administrator/AdsSlider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/AdsSlider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdsSlider adsSlider, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    adsSlider.AdImagePath = "/images/" + uniqueFileName;
                }

                adsSlider.AdId = Guid.NewGuid();
                _context.Add(adsSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adsSlider);
        }

        // GET: Administrator/AdsSlider/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsSlider = await _context.AdsSliders.FindAsync(id);
            if (adsSlider == null)
            {
                return NotFound();
            }
            return View(adsSlider);
        }

        // POST: Administrator/AdsSlider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AdsSlider adsSlider, IFormFile imageFile)
        {
            if (id != adsSlider.AdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }

                        adsSlider.AdImagePath = "/images/" + uniqueFileName;
                    }
                    _context.Update(adsSlider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdsSliderExists(adsSlider.AdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adsSlider);
        }

        // GET: Administrator/AdsSlider/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adsSlider = await _context.AdsSliders
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (adsSlider == null)
            {
                return NotFound();
            }

            return View(adsSlider);
        }

        // POST: Administrator/AdsSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adsSlider = await _context.AdsSliders.FindAsync(id);
            if (adsSlider != null)
            {
                if (!string.IsNullOrEmpty(adsSlider.AdImagePath))
                {
                    
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, adsSlider.AdImagePath.TrimStart('/'));

                   
                    if (System.IO.File.Exists(filePath))
                    {
                       
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.AdsSliders.Remove(adsSlider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdsSliderExists(Guid id)
        {
            return _context.AdsSliders.Any(e => e.AdId == id);
        }
    }
}
