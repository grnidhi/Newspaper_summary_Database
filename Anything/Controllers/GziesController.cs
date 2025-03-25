using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anything.Data;
using Anything.Models;

namespace Anything.Controllers
{
    public class GziesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GziesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gzies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Group.Include(g => g.Processname).Include(g => g.Stages);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gzies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gzie = await _context.Group
                .Include(g => g.Processname)
                .Include(g => g.Stages)
                .FirstOrDefaultAsync(m => m.GId == id);
            if (gzie == null)
            {
                return NotFound();
            }

            return View(gzie);
        }

        // GET: Gzies/Create
        public IActionResult Create()
        {
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName");
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription");
            return View();
        }

        // POST: Gzies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GId,GName,ProcessId,StageId")] Gzie gzie)
        {
            if (ModelState.IsValid)
            {
                // Log the ModelState errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }


                ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", gzie.ProcessId);
                ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", gzie.StageId);
                return View(gzie);
            }

            _context.Add(gzie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Gzies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gzie = await _context.Group.FindAsync(id);
            if (gzie == null)
            {
                return NotFound();
            }
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", gzie.ProcessId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", gzie.StageId);
            return View(gzie);
        }

        // POST: Gzies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GId,GName,ProcessId,StageId")] Gzie gzie)
        {
            if (id != gzie.GId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gzie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GzieExists(gzie.GId))
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
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", gzie.ProcessId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", gzie.StageId);
            return View(gzie);
        }

        // GET: Gzies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gzie = await _context.Group
                .Include(g => g.Processname)
                .Include(g => g.Stages)
                .FirstOrDefaultAsync(m => m.GId == id);
            if (gzie == null)
            {
                return NotFound();
            }

            return View(gzie);
        }

        // POST: Gzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gzie = await _context.Group.FindAsync(id);
            if (gzie != null)
            {
                _context.Group.Remove(gzie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GzieExists(int id)
        {
            return _context.Group.Any(e => e.GId == id);
        }

        public JsonResult GetStagesByProcessId(int processId)
        {
            var stages = _context.StageMasters
                                 .Where(s => s.ProcessId == processId)
                                 .Select(s => new
                                 {
                                     StageId = s.StageId,
                                     StageName = s.StageName
                                 }).ToList();

            return Json(stages);
        }


    }
}
