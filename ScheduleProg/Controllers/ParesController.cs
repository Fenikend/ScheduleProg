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
            
            ViewBag.monday_item= _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher)
            .Where(p=>p.Week_Day=="Понеділок");

            ViewBag.tuesday_item = _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher)
            .Where(p => p.Week_Day == "Вівторок");

            ViewBag.wednesday_item = _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher)
            .Where(p => p.Week_Day == "Середа");
            ViewBag.thursday_item = _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher)
            .Where(p => p.Week_Day == "Четвер");
            ViewBag.friday_item = _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher)
            .Where(p => p.Week_Day == "Четвер");
            var applicationDbContext = _context.Schedules
                       .Include(p => p.PairTime)
                       .Include(p => p.Semester)
                       .Include(p => p.Subject)
                       .Include(p => p.Teacher);
                //.Where(p=>p.Week_Day=="tuesday");
                
            var p = applicationDbContext.ToList();
            return View(p);
        }


        // GET: Pares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var pare = await _context.Schedules
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
               
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id");
            var view1 = new SelectList(_context.Subject, "Id", "Discipline_Name");
            var view2 = new SelectList(_context.Semesters, "Id", "Id");
            var view3 = new SelectList(_context.Teachers, "Id", "Full_Name");
            //ViewData["Subject_Id"] = new SelectList(_context.Subject, "Id", "Discipline_Name");
           
            ViewData["Subject_Id"]= view1;
            ViewData["Semester_Id"] = view2;
            ViewData["Teacher_Id"] = view3;
            return View();
        }

        // POST: Pares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject_Id,Semester_Id,Teacher_Id,Pair_Time_Id,Week_Day")] Pare pare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Id", "Id", pare.Subject_Id);
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
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Id", "Id", pare.Subject_Id);
            ViewData["Teacher_Id"] = new SelectList(_context.Teachers, "Id", "Id", pare.Teacher_Id);
            return View(pare);
        }

        // POST: Pares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject_Id,Semester_Id,Teacher_Id,Pair_Time_Id,Week_Day")] Pare pare)
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
            ViewData["Pair_Time_Id"] = new SelectList(_context.PairTimes, "Id", "Id", pare.Pair_Time_Id);
            ViewData["Semester_Id"] = new SelectList(_context.Semesters, "Id", "Id", pare.Semester_Id);
            ViewData["Subject_Id"] = new SelectList(_context.Subject, "Id", "Id", pare.Subject_Id);
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
