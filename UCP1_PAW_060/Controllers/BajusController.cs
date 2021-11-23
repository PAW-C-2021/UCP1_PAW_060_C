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
    public class BajusController : Controller
    {
        private readonly PenjualanBajuContext _context;

        public BajusController(PenjualanBajuContext context)
        {
            _context = context;
        }

        // GET: Bajus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baju.ToListAsync());
        }

        // GET: Bajus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baju = await _context.Baju
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (baju == null)
            {
                return NotFound();
            }

            return View(baju);
        }

        // GET: Bajus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bajus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaju,HargaBaju,StokBaju")] Baju baju)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baju);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baju);
        }

        // GET: Bajus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baju = await _context.Baju.FindAsync(id);
            if (baju == null)
            {
                return NotFound();
            }
            return View(baju);
        }

        // POST: Bajus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBaju,HargaBaju,StokBaju")] Baju baju)
        {
            if (id != baju.IdBaju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baju);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BajuExists(baju.IdBaju))
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
            return View(baju);
        }

        // GET: Bajus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baju = await _context.Baju
                .FirstOrDefaultAsync(m => m.IdBaju == id);
            if (baju == null)
            {
                return NotFound();
            }

            return View(baju);
        }

        // POST: Bajus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baju = await _context.Baju.FindAsync(id);
            _context.Baju.Remove(baju);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BajuExists(int id)
        {
            return _context.Baju.Any(e => e.IdBaju == id);
        }
    }
}
