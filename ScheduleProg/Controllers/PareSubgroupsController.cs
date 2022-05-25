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
    public class PareSubgroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public PareSubgroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PareSubgroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PareSubgroups.Include(p => p.Pare).Include(p => p.Subgroup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PareSubgroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PareSubgroups == null)
            {
                return NotFound();
            }
         
            var pareSubgroup = await _context.PareSubgroups
                .Include(p => p.Pare)
                .Include(p => p.Subgroup)
                .FirstOrDefaultAsync(m => m.Pare_Id == id);
            if (pareSubgroup == null)
            {
                return NotFound();
            }

            return View(pareSubgroup);
        }

        // GET: PareSubgroups/Create
        public IActionResult Create()
        {

           var Ixem = _context.Schedules.Join(_context.Subject,
           s => s.Subject_Id,
           c => c.Id,
           (s, c) => new {
               Pare_id = s.Id,
               Discipline_Name = c.Discipline_Name
           }
           );
            ViewData["Pare_Id"] = new SelectList(_context.Schedules, "Id", "Dicipline_Name");
         
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Id");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pare_Id,Subgroup_Id")] PareSubgroup pareSubgroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareSubgroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pare_Id"] = new SelectList(_context.Schedules, "Id", "Id", pareSubgroup.Pare_Id);
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Id", pareSubgroup.Subgroup_Id);
            return View(pareSubgroup);
        }

        // GET: PareSubgroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PareSubgroups == null)
            {
                return NotFound();
            }

            var pareSubgroup = await _context.PareSubgroups.FindAsync(id);
            if (pareSubgroup == null)
            {
                return NotFound();
            }
            ViewData["Pare_Id"] = new SelectList(_context.Schedules, "Id", "Id", pareSubgroup.Pare_Id);
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Id", pareSubgroup.Subgroup_Id);
            return View(pareSubgroup);
        }

        // POST: PareSubgroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pare_Id,Subgroup_Id")] PareSubgroup pareSubgroup)
        {
            if (id != pareSubgroup.Pare_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pareSubgroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PareSubgroupExists(pareSubgroup.Pare_Id))
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
            ViewData["Pare_Id"] = new SelectList(_context.Schedules, "Id", "Id", pareSubgroup.Pare_Id);
            ViewData["Subgroup_Id"] = new SelectList(_context.Subgroups, "Id", "Id", pareSubgroup.Subgroup_Id);
            return View(pareSubgroup);
        }

        // GET: PareSubgroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PareSubgroups == null)
            {
                return NotFound();
            }

            var pareSubgroup = await _context.PareSubgroups
                .Include(p => p.Pare)
                .Include(p => p.Subgroup)
                .FirstOrDefaultAsync(m => m.Pare_Id == id);
            if (pareSubgroup == null)
            {
                return NotFound();
            }

            return View(pareSubgroup);
        }

        // POST: PareSubgroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PareSubgroups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PareSubgroups'  is null.");
            }
            var pareSubgroup = await _context.PareSubgroups.FindAsync(id);
            if (pareSubgroup != null)
            {
                _context.PareSubgroups.Remove(pareSubgroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PareSubgroupExists(int id)
        {
          return (_context.PareSubgroups?.Any(e => e.Pare_Id == id)).GetValueOrDefault();
        }
    }
}
