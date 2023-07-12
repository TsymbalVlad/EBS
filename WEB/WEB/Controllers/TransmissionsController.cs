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
    public class TransmissionsController : Controller
    {
        private readonly AppDBContext _context;

        public TransmissionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Transmissions
        public async Task<IActionResult> Index()
        {
              return _context.Transmission != null ? 
                          View(await _context.Transmission.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Transmission'  is null.");
        }

        // GET: Transmissions/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Transmission == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission
                .FirstOrDefaultAsync(m => m.transmission_id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // GET: Transmissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transmission transmission)
        {
            try
            {
                _context.Add(transmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(transmission);
            }
        }

        // GET: Transmissions/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Transmission == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission.FindAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, Transmission transmission)
        {
            if (id != transmission.transmission_id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(transmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransmissionExists(transmission.transmission_id))
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

        // GET: Transmissions/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Transmission == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmission
                .FirstOrDefaultAsync(m => m.transmission_id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // POST: Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Transmission == null)
            {
                return Problem("Entity set 'AppDBContext.Transmission'  is null.");
            }
            var transmission = await _context.Transmission.FindAsync(id);
            if (transmission != null)
            {
                _context.Transmission.Remove(transmission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransmissionExists(byte id)
        {
          return (_context.Transmission?.Any(e => e.transmission_id == id)).GetValueOrDefault();
        }
    }
}
