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
    public class StageMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StageMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StageMasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StageMasters.Include(s => s.DrawingMaster).Include(s => s.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StageMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageMaster = await _context.StageMasters
                .Include(s => s.DrawingMaster)
                .Include(s => s.Name)
                .FirstOrDefaultAsync(m => m.StageId == id);
            if (stageMaster == null)
            {
                return NotFound();
            }

            return View(stageMaster);
        }

        // GET: StageMasters/Create
        public IActionResult Create()
        {
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName");
            ViewData["DrawingId"] = new SelectList(Enumerable.Empty<SelectListItem>(), "DrawingId", "ProductNumber");
            return View();
        }

        // POST: StageMasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StageId,StageName,StageDescription,ProcessId,DrawingId")] StageMaster stageMaster)
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
                ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", stageMaster.ProcessId);
                ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.ProcessId == stageMaster.ProcessId), "DrawingId", "ProductNumber", stageMaster.DrawingId);
                return View(stageMaster);

            }

            

            _context.Add(stageMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: StageMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageMaster = await _context.StageMasters.FindAsync(id);
            if (stageMaster == null)
            {
                return NotFound();
            }
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", stageMaster.ProcessId);
            ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.ProcessId == stageMaster.ProcessId), "DrawingId", "ProductNumber", stageMaster.DrawingId);
            return View(stageMaster);
        }

        // POST: StageMasters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StageId,StageName,StageDescription,ProcessId,DrawingId")] StageMaster stageMaster)
        {
            if (id != stageMaster.StageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stageMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageMasterExists(stageMaster.StageId))
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
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", stageMaster.ProcessId);
            ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.ProcessId == stageMaster.ProcessId), "DrawingId", "ProductNumber", stageMaster.DrawingId);
            return View(stageMaster);
        }

        // GET: StageMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageMaster = await _context.StageMasters
                .Include(s => s.DrawingMaster)
                .Include(s => s.Name)
                .FirstOrDefaultAsync(m => m.StageId == id);
            if (stageMaster == null)
            {
                return NotFound();
            }

            return View(stageMaster);
        }

        // POST: StageMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageMaster = await _context.StageMasters.FindAsync(id);
            if (stageMaster != null)
            {
                _context.StageMasters.Remove(stageMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageMasterExists(int id)
        {
            return _context.StageMasters.Any(e => e.StageId == id);
        }

        // This method will be called via AJAX to populate the drawings dropdown based on the selected process.
        public JsonResult GetDrawingsByProcess(int processId)
        {
            var drawings = _context.Draws.Where(d => d.ProcessId == processId).Select(d => new
            {
                DrawingId = d.DrawingId,
                ProductNumber = d.ProductNumber
            }).ToList();

            return Json(drawings);
        }
    }
}
