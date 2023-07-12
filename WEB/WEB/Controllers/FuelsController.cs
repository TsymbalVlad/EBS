using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB.Entity;
using WEB.Models;

namespace WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FuelsController : Controller
    {
        private readonly AppDBContext _context;

        public FuelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Fuels
        public async Task<IActionResult> Index()
        {
              return _context.Fuels != null ? 
                          View(await _context.Fuels.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Fuels'  is null.");
        }

        // GET: Fuels/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels
                .FirstOrDefaultAsync(m => m.fuel_id == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // GET: Fuels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fuels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fuel fuel)
        {
            try
            {
                _context.Add(fuel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            { 
                return View(fuel);
            }
            
        }

        // GET: Fuels/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels.FindAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, Fuel fuels)
        {
            if (id != fuels.fuel_id)
            {
                return NotFound();
            }
            
                try
                {
                    _context.Update(fuels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuels.fuel_id))
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

        // GET: Fuels/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Fuels == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuels
                .FirstOrDefaultAsync(m => m.fuel_id == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Fuels == null)
            {
                return Problem("Entity set 'AppDBContext.Fuels'  is null.");
            }
            var fuel = await _context.Fuels.FindAsync(id);
            if (fuel != null)
            {
                _context.Fuels.Remove(fuel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelExists(byte id)
        {
          return (_context.Fuels?.Any(e => e.fuel_id == id)).GetValueOrDefault();
        }
    }
}
