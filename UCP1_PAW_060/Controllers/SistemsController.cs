using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_060.Models;

namespace UCP1_PAW_060.Controllers
{
    public class SistemsController : Controller
    {
        private readonly PenjualanBajuContext _context;

        public SistemsController(PenjualanBajuContext context)
        {
            _context = context;
        }

        // GET: Sistems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sistem.ToListAsync());
        }

        // GET: Sistems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (sistem == null)
            {
                return NotFound();
            }

            return View(sistem);
        }

        // GET: Sistems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sistems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaju,NamaBaju,Harga")] Sistem sistem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistem);
        }

        // GET: Sistems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem.FindAsync(id);
            if (sistem == null)
            {
                return NotFound();
            }
            return View(sistem);
        }

        // POST: Sistems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaju,NamaBaju,Harga")] Sistem sistem)
        {
            if (id != sistem.IdBaju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemExists(sistem.IdBaju))
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
            return View(sistem);
        }

        // GET: Sistems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (sistem == null)
            {
                return NotFound();
            }

            return View(sistem);
        }

        // POST: Sistems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistem = await _context.Sistem.FindAsync(id);
            _context.Sistem.Remove(sistem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemExists(int id)
        {
            return _context.Sistem.Any(e => e.IdBaju == id);
        }
    }
}
