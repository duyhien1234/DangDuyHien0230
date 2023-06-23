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
    public class DDHSinhvienController : Controller
    {
        private readonly MvcMovieContext _context;

        public DDHSinhvienController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: DDHSinhvien
        public async Task<IActionResult> Index()
        {
              return _context.DDHSinhvien != null ? 
                          View(await _context.DDHSinhvien.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.DDHSinhvien'  is null.");
        }

        // GET: DDHSinhvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DDHSinhvien == null)
            {
                return NotFound();
            }

            var dDHSinhvien = await _context.DDHSinhvien
                .FirstOrDefaultAsync(m => m.Sinhvien == id);
            if (dDHSinhvien == null)
            {
                return NotFound();
            }

            return View(dDHSinhvien);
        }

        // GET: DDHSinhvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DDHSinhvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sinhvien,Truong,Thanhpho")] DDHSinhvien dDHSinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dDHSinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dDHSinhvien);
        }

        // GET: DDHSinhvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DDHSinhvien == null)
            {
                return NotFound();
            }

            var dDHSinhvien = await _context.DDHSinhvien.FindAsync(id);
            if (dDHSinhvien == null)
            {
                return NotFound();
            }
            return View(dDHSinhvien);
        }

        // POST: DDHSinhvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Sinhvien,Truong,Thanhpho")] DDHSinhvien dDHSinhvien)
        {
            if (id != dDHSinhvien.Sinhvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dDHSinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DDHSinhvienExists(dDHSinhvien.Sinhvien))
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
            return View(dDHSinhvien);
        }

        // GET: DDHSinhvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DDHSinhvien == null)
            {
                return NotFound();
            }

            var dDHSinhvien = await _context.DDHSinhvien
                .FirstOrDefaultAsync(m => m.Sinhvien == id);
            if (dDHSinhvien == null)
            {
                return NotFound();
            }

            return View(dDHSinhvien);
        }

        // POST: DDHSinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DDHSinhvien == null)
            {
                return Problem("Entity set 'MvcMovieContext.DDHSinhvien'  is null.");
            }
            var dDHSinhvien = await _context.DDHSinhvien.FindAsync(id);
            if (dDHSinhvien != null)
            {
                _context.DDHSinhvien.Remove(dDHSinhvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DDHSinhvienExists(string id)
        {
          return (_context.DDHSinhvien?.Any(e => e.Sinhvien == id)).GetValueOrDefault();
        }
    }
}
