using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Area.Data;

namespace Area.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AtasozleriController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AtasozleriController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Atasozuleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atasozleri.ToListAsync());
        }

        // GET: Admin/Atasozuleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atasozu = await _context.Atasozleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atasozu == null)
            {
                return NotFound();
            }

            return View(atasozu);
        }

        // GET: Admin/Atasozuleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Atasozuleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Icerik")] Atasozu atasozu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atasozu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atasozu);
        }

        // GET: Admin/Atasozuleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atasozu = await _context.Atasozleri.FindAsync(id);
            if (atasozu == null)
            {
                return NotFound();
            }
            return View(atasozu);
        }

        // POST: Admin/Atasozuleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Icerik")] Atasozu atasozu)
        {
            if (id != atasozu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atasozu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtasozuExists(atasozu.Id))
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
            return View(atasozu);
        }

        // GET: Admin/Atasozuleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atasozu = await _context.Atasozleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atasozu == null)
            {
                return NotFound();
            }

            return View(atasozu);
        }

        // POST: Admin/Atasozuleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atasozu = await _context.Atasozleri.FindAsync(id);
            if (atasozu != null)
            {
                _context.Atasozleri.Remove(atasozu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtasozuExists(int id)
        {
            return _context.Atasozleri.Any(e => e.Id == id);
        }
    }
}
