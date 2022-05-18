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
    public class SubgroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubgroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subgroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subgroups.Include(s => s.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subgroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subgroups == null)
            {
                return NotFound();
            }

            var subgroup = await _context.Subgroups
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgroup == null)
            {
                return NotFound();
            }

            return View(subgroup);
        }

        // GET: Subgroups/Create
        public IActionResult Create()
        {
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id");
            return View();
        }

        // POST: Subgroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subgr_Name,Group_Id")] Subgroup subgroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subgroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", subgroup.Group_Id);
            return View(subgroup);
        }

        // GET: Subgroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subgroups == null)
            {
                return NotFound();
            }

            var subgroup = await _context.Subgroups.FindAsync(id);
            if (subgroup == null)
            {
                return NotFound();
            }
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", subgroup.Group_Id);
            return View(subgroup);
        }

        // POST: Subgroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subgr_Name,Group_Id")] Subgroup subgroup)
        {
            if (id != subgroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subgroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubgroupExists(subgroup.Id))
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
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", subgroup.Group_Id);
            return View(subgroup);
        }

        // GET: Subgroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subgroups == null)
            {
                return NotFound();
            }

            var subgroup = await _context.Subgroups
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgroup == null)
            {
                return NotFound();
            }

            return View(subgroup);
        }

        // POST: Subgroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subgroups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subgroups'  is null.");
            }
            var subgroup = await _context.Subgroups.FindAsync(id);
            if (subgroup != null)
            {
                _context.Subgroups.Remove(subgroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubgroupExists(int id)
        {
          return (_context.Subgroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
