using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleProg.Data;
using ScheduleProg.Models;

namespace ScheduleProg.Controllers
{
    public class PotoksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PotoksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Potoks
        public async Task<IActionResult> Index()
        {
              return _context.Potoks != null ? 
                          View(await _context.Potoks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Potoks'  is null.");
        }

        // GET: Potoks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Potoks == null)
            {
                return NotFound();
            }

            var potok = await _context.Potoks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potok == null)
            {
                return NotFound();
            }

            return View(potok);
        }

        // GET: Potoks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Potoks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Potok_Name")] Potok potok)
        {
            if (ModelState.IsValid)
            {
                _context.Add(potok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(potok);
        }

        // GET: Potoks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Potoks == null)
            {
                return NotFound();
            }

            var potok = await _context.Potoks.FindAsync(id);
            if (potok == null)
            {
                return NotFound();
            }
            return View(potok);
        }

        // POST: Potoks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Potok_Name")] Potok potok)
        {
            if (id != potok.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(potok);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotokExists(potok.Id))
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
            return View(potok);
        }

        // GET: Potoks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Potoks == null)
            {
                return NotFound();
            }

            var potok = await _context.Potoks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potok == null)
            {
                return NotFound();
            }

            return View(potok);
        }

        // POST: Potoks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Potoks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Potoks'  is null.");
            }
            var potok = await _context.Potoks.FindAsync(id);
            if (potok != null)
            {
                _context.Potoks.Remove(potok);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PotokExists(int id)
        {
          return (_context.Potoks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
