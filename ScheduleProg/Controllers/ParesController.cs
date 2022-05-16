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
    public class ParesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pares
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Schedules.Include(p => p.Group).Include(p => p.PairTime).Include(p => p.Semester).Include(p => p.Subject).Include(p => p.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var pare = await _context.Schedules
                .Include(p => p.Group)
                .Include(p => p.PairTime)
                .Include(p => p.Semester)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pare == null)
            {
                return NotFound();
            }

            return View(pare);
        }

        // GET: Pares/Create
        public IActionResult Create()
        {
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id");
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id");
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id");
            ViewData["Subject_Id"] = new SelectList(_context.Set<Subject>(), "Id", "Id");
            ViewData["Teacher_Id"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: Pares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Group_Id,Subject_Id,Semester_Id,Teacher_Id,Pair_Time_Id")] Pare pare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", pare.Group_Id);
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Set<Subject>(), "Id", "Id", pare.Subject_Id);
            ViewData["Teacher_Id"] = new SelectList(_context.Teachers, "Id", "Id", pare.Teacher_Id);
            return View(pare);
        }

        // GET: Pares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var pare = await _context.Schedules.FindAsync(id);
            if (pare == null)
            {
                return NotFound();
            }
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", pare.Group_Id);
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Set<Subject>(), "Id", "Id", pare.Subject_Id);
            ViewData["Teacher_Id"] = new SelectList(_context.Teachers, "Id", "Id", pare.Teacher_Id);
            return View(pare);
        }

        // POST: Pares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Group_Id,Subject_Id,Semester_Id,Teacher_Id,Pair_Time_Id")] Pare pare)
        {
            if (id != pare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PareExists(pare.Id))
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
            ViewData["Group_Id"] = new SelectList(_context.Groups, "Id", "Id", pare.Group_Id);
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Set<Subject>(), "Id", "Id", pare.Subject_Id);
            ViewData["Teacher_Id"] = new SelectList(_context.Teachers, "Id", "Id", pare.Teacher_Id);
            return View(pare);
        }

        // GET: Pares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var pare = await _context.Schedules
                .Include(p => p.Group)
                .Include(p => p.PairTime)
                .Include(p => p.Semester)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pare == null)
            {
                return NotFound();
            }

            return View(pare);
        }

        // POST: Pares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schedules == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Schedules'  is null.");
            }
            var pare = await _context.Schedules.FindAsync(id);
            if (pare != null)
            {
                _context.Schedules.Remove(pare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PareExists(int id)
        {
          return (_context.Schedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
