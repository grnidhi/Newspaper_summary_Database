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
    public class DrawsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrawsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Draws
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Draws.Include(d => d.customer).Include(d => d.process);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Draws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draws
                .Include(d => d.customer)
                .Include(d => d.process)
                .FirstOrDefaultAsync(m => m.DrawingId == id);
            if (draw == null)
            {
                return NotFound();
            }

            return View(draw);
        }

        // GET: Draws/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName");
            return View();
        }

        // POST: Draws/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrawingId,ProductNumber,CustomerId,ProcessId")] Draw draw)
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
                // If model state is not valid, re-populate the dropdowns and return the view with the current model
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", draw.CustomerId);
                ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", draw.ProcessId);
                return View(draw);
            }

           

            _context.Add(draw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Draws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draws.FindAsync(id);
            if (draw == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", draw.CustomerId);
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", draw.ProcessId);
            return View(draw);
        }

        // POST: Draws/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrawingId,ProductNumber,CustomerId,ProcessId")] Draw draw)
        {
            if (id != draw.DrawingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(draw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawExists(draw.DrawingId))
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

            // If model state is not valid, re-populate the dropdowns and return the view with the current model
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", draw.CustomerId);
            ViewData["ProcessId"] = new SelectList(_context.processMs, "ProcessId", "ProcessName", draw.ProcessId);
            return View(draw);
        }

        // GET: Draws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var draw = await _context.Draws
                .Include(d => d.customer)
                .Include(d => d.process)
                .FirstOrDefaultAsync(m => m.DrawingId == id);
            if (draw == null)
            {
                return NotFound();
            }

            return View(draw);
        }

        // POST: Draws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var draw = await _context.Draws.FindAsync(id);
            if (draw != null)
            {
                _context.Draws.Remove(draw);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawExists(int id)
        {
            return _context.Draws.Any(e => e.DrawingId == id);
        }
    }
}
