using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DangDuyHien0230.Models;
using MvcMovie.Data;

namespace DangDuyHien0230.Controllers
{
    public class DDHHocsinhgioiController : Controller
    {
        private readonly MvcMovieContext _context;

        public DDHHocsinhgioiController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: DDHHocsinhgioi
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.DDHHocsinhgioi.Include(d => d.DDHSinhvien);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: DDHHocsinhgioi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DDHHocsinhgioi == null)
            {
                return NotFound();
            }

            var dDHHocsinhgioi = await _context.DDHHocsinhgioi
                .Include(d => d.DDHSinhvien)
                .FirstOrDefaultAsync(m => m.Ketqua == id);
            if (dDHHocsinhgioi == null)
            {
                return NotFound();
            }

            return View(dDHHocsinhgioi);
        }

        // GET: DDHHocsinhgioi/Create
        public IActionResult Create()
        {
            ViewData["Sinhvien"] = new SelectList(_context.DDHSinhvien, "Sinhvien", "Sinhvien");
            return View();
        }

        // POST: DDHHocsinhgioi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ketqua,Sinhvien")] DDHHocsinhgioi dDHHocsinhgioi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dDHHocsinhgioi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sinhvien"] = new SelectList(_context.DDHSinhvien, "Sinhvien", "Sinhvien", dDHHocsinhgioi.Sinhvien);
            return View(dDHHocsinhgioi);
        }

        // GET: DDHHocsinhgioi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DDHHocsinhgioi == null)
            {
                return NotFound();
            }

            var dDHHocsinhgioi = await _context.DDHHocsinhgioi.FindAsync(id);
            if (dDHHocsinhgioi == null)
            {
                return NotFound();
            }
            ViewData["Sinhvien"] = new SelectList(_context.DDHSinhvien, "Sinhvien", "Sinhvien", dDHHocsinhgioi.Sinhvien);
            return View(dDHHocsinhgioi);
        }

        // POST: DDHHocsinhgioi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ketqua,Sinhvien")] DDHHocsinhgioi dDHHocsinhgioi)
        {
            if (id != dDHHocsinhgioi.Ketqua)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dDHHocsinhgioi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DDHHocsinhgioiExists(dDHHocsinhgioi.Ketqua))
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
            ViewData["Sinhvien"] = new SelectList(_context.DDHSinhvien, "Sinhvien", "Sinhvien", dDHHocsinhgioi.Sinhvien);
            return View(dDHHocsinhgioi);
        }

        // GET: DDHHocsinhgioi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DDHHocsinhgioi == null)
            {
                return NotFound();
            }

            var dDHHocsinhgioi = await _context.DDHHocsinhgioi
                .Include(d => d.DDHSinhvien)
                .FirstOrDefaultAsync(m => m.Ketqua == id);
            if (dDHHocsinhgioi == null)
            {
                return NotFound();
            }

            return View(dDHHocsinhgioi);
        }

        // POST: DDHHocsinhgioi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DDHHocsinhgioi == null)
            {
                return Problem("Entity set 'MvcMovieContext.DDHHocsinhgioi'  is null.");
            }
            var dDHHocsinhgioi = await _context.DDHHocsinhgioi.FindAsync(id);
            if (dDHHocsinhgioi != null)
            {
                _context.DDHHocsinhgioi.Remove(dDHHocsinhgioi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DDHHocsinhgioiExists(string id)
        {
          return (_context.DDHHocsinhgioi?.Any(e => e.Ketqua == id)).GetValueOrDefault();
        }
    }
}
