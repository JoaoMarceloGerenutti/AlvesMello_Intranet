using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlvesMello_IntraNet.Context;
using AlvesMello_IntraNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace AlvesMello_IntraNet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSitesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminSitesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminSites
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sites.Include(s => s.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Admin/AdminSites/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Color");
            return View();
        }

        // POST: Admin/AdminSites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SiteId,Name,Description,ImageUrl,SiteUrl,IsFavorite,IsActive,CategoryId")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Color", site.CategoryId);
            return View(site);
        }

        // GET: Admin/AdminSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Color", site.CategoryId);
            return View(site);
        }

        // POST: Admin/AdminSites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SiteId,Name,Description,ImageUrl,SiteUrl,IsFavorite,IsActive,CategoryId")] Site site)
        {
            if (id != site.SiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.SiteId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Color", site.CategoryId);
            return View(site);
        }

        // GET: Admin/AdminSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Admin/AdminSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sites == null)
            {
                return Problem("Entity set 'AppDbContext.Sites'  is null.");
            }
            var site = await _context.Sites.FindAsync(id);
            if (site != null)
            {
                _context.Sites.Remove(site);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
          return _context.Sites.Any(e => e.SiteId == id);
        }
    }
}
