using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gorev1.Data;
using Gorev1.Areas.Admin.Models;

namespace Gorev1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UygulamaDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(UygulamaDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.Slaytlar.ToListAsync());
        }

        // GET: Admin/Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slayt = await _context.Slaytlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slayt == null)
            {
                return NotFound();
            }

            return View(slayt);
        }

        // GET: Admin/Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Resim,Baslik,Aciklama,Sira")] Slayt slayt)
        public async Task<IActionResult> Create(YeniSlaytViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(vm.Resim!.FileName);
                string yeniResim = Guid.NewGuid() + ext;
                string yol = Path.Combine(_env.WebRootPath, "img", yeniResim);

                using (var fs = new FileStream(yol, FileMode.CreateNew))
                {
                    vm.Resim.CopyTo(fs);
                }

                Slayt slayt = new Slayt()
                {
                    Id = vm.Id,
                    Resim = yeniResim,
                    Baslik = vm.Baslik,
                    Aciklama = vm.Aciklama,
                    Sira =vm.Sira==null?_context.Slaytlar.Max(x=>x.Sira)+1:(int)vm.Sira,
                };

                _context.Add(slayt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slayt = await _context.Slaytlar.FindAsync(id);
            if (slayt == null)
            {
                return NotFound();
            }

            SlaytViewModel vm = new SlaytViewModel()
            {
                Id = slayt.Id,
                Baslik = slayt.Baslik,
                Aciklama = slayt.Aciklama,
                Sira = slayt.Sira
            };
            return View(vm);
        }

        // POST: Admin/Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Resim,Baslik,Aciklama,Sira")] Slayt slayt)
        public async Task<IActionResult> Edit(SlaytViewModel vm)
        {
            //if (id != slayt.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var slayt = await _context.Slaytlar.FindAsync(vm.Id);
                if (slayt == null)
                {
                    return NotFound();
                }

                if (vm.Resim != null)
                {
                    string dosya = Path.Combine(_env.WebRootPath, "img", slayt.Resim);
                    System.IO.File.Delete(dosya);

                    string ext = Path.GetExtension(vm.Resim!.FileName);
                    string yeniResim = Guid.NewGuid() + ext;
                    string yol = Path.Combine(_env.WebRootPath, "img", yeniResim);

                    using (var fs = new FileStream(yol, FileMode.CreateNew))
                    {
                        vm.Resim.CopyTo(fs);
                    }
                    slayt.Resim = yeniResim;
                }

                slayt.Baslik = vm.Baslik;
                slayt.Aciklama = vm.Aciklama;
                slayt.Sira = vm.Sira;

                try
                {
                    _context.Update(slayt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlaytExists(slayt.Id))
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
            return View(vm);
        }

        // GET: Admin/Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slayt = await _context.Slaytlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slayt == null)
            {
                return NotFound();
            }

            return View(slayt);
        }

        // POST: Admin/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slayt = await _context.Slaytlar.FindAsync(id);
            if (slayt != null)
            {
                _context.Slaytlar.Remove(slayt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlaytExists(int id)
        {
            return _context.Slaytlar.Any(e => e.Id == id);
        }
    }
}
