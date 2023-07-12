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
    public class Drive_typeController : Controller
    {
        private readonly AppDBContext _context;

        public Drive_typeController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Drive_type
        public async Task<IActionResult> Index()
        {
              return _context.Drive_type != null ? 
                          View(await _context.Drive_type.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Drive_type'  is null.");
        }

        // GET: Drive_type/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Drive_type == null)
            {
                return NotFound();
            }

            var drive_type = await _context.Drive_type
                .FirstOrDefaultAsync(m => m.drive_id == id);
            if (drive_type == null)
            {
                return NotFound();
            }

            return View(drive_type);
        }

        // GET: Drive_type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drive_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drive_type drive_type)
        {
            try
            {
                _context.Add(drive_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(drive_type);
            }
        }

        // GET: Drive_type/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Drive_type == null)
            {
                return NotFound();
            }

            var drive_type = await _context.Drive_type.FindAsync(id);
            if (drive_type == null)
            {
                return NotFound();
            }
            return View(drive_type);
        }

        // POST: Drive_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, Drive_type drive_type)
        {
            if (id != drive_type.drive_id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(drive_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Drive_typeExists(drive_type.drive_id))
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

        // GET: Drive_type/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Drive_type == null)
            {
                return NotFound();
            }

            var drive_type = await _context.Drive_type
                .FirstOrDefaultAsync(m => m.drive_id == id);
            if (drive_type == null)
            {
                return NotFound();
            }

            return View(drive_type);
        }

        // POST: Drive_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Drive_type == null)
            {
                return Problem("Entity set 'AppDBContext.Drive_type'  is null.");
            }
            var drive_type = await _context.Drive_type.FindAsync(id);
            if (drive_type != null)
            {
                _context.Drive_type.Remove(drive_type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Drive_typeExists(byte id)
        {
          return (_context.Drive_type?.Any(e => e.drive_id == id)).GetValueOrDefault();
        }
    }
}
