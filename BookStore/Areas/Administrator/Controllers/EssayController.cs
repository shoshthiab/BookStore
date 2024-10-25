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
    public class EssayController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EssayController(AppDbContext context, IWebHostEnvironment webHostEnvironment
)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Administrator/Essay
        public async Task<IActionResult> Index()
        {
            return View(await _context.Essays.ToListAsync());
        }

        // GET: Administrator/Essay/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var essay = await _context.Essays
                .FirstOrDefaultAsync(m => m.EssayId == id);
            if (essay == null)
            {
                return NotFound();
            }

            return View(essay);
        }

        // GET: Administrator/Essay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Essay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Essay essay, IFormFile imageFile)
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

                    essay.EssayImagePath = "/images/" + uniqueFileName;
                }

                essay.EssayId = Guid.NewGuid();
                _context.Add(essay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(essay);
        }

        // GET: Administrator/Essay/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var essay = await _context.Essays.FindAsync(id);
            if (essay == null)
            {
                return NotFound();
            }
            return View(essay);
        }

        // POST: Administrator/Essay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Essay essay, IFormFile imageFile)
        {
            if (id != essay.EssayId)
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

                        essay.EssayImagePath = "/images/" + uniqueFileName;
                    }

                    _context.Update(essay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EssayExists(essay.EssayId))
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
            return View(essay);
        }

        // GET: Administrator/Essay/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var essay = await _context.Essays
                .FirstOrDefaultAsync(m => m.EssayId == id);
            if (essay == null)
            {
                return NotFound();
            }

            return View(essay);
        }

        // POST: Administrator/Essay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var essay = await _context.Essays.FindAsync(id);
            if (essay != null)
            {
                if (!string.IsNullOrEmpty(essay.EssayImagePath))
                {

                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, essay.EssayImagePath.TrimStart('/'));


                    if (System.IO.File.Exists(filePath))
                    {

                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Essays.Remove(essay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EssayExists(Guid id)
        {
            return _context.Essays.Any(e => e.EssayId == id);
        }
    }
}
