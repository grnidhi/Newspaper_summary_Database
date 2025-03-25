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
    public class ProcessMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProcessMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.processMs.ToListAsync());
        }

        // GET: ProcessMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processM = await _context.processMs
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (processM == null)
            {
                return NotFound();
            }

            return View(processM);
        }

        // GET: ProcessMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessId,ProcessName,ProcessDescrption")] ProcessM processM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processM);
        }

        // GET: ProcessMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processM = await _context.processMs.FindAsync(id);
            if (processM == null)
            {
                return NotFound();
            }
            return View(processM);
        }

        // POST: ProcessMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessId,ProcessName,ProcessDescrption")] ProcessM processM)
        {
            if (id != processM.ProcessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessMExists(processM.ProcessId))
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
            return View(processM);
        }

        // GET: ProcessMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processM = await _context.processMs
                .FirstOrDefaultAsync(m => m.ProcessId == id);
            if (processM == null)
            {
                return NotFound();
            }

            return View(processM);
        }

        // POST: ProcessMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processM = await _context.processMs.FindAsync(id);
            if (processM != null)
            {
                _context.processMs.Remove(processM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessMExists(int id)
        {
            return _context.processMs.Any(e => e.ProcessId == id);
        }
    }
}
