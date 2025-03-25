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
    public class ProcessPagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessPagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProcessPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessPages.ToListAsync());
        }

        // GET: ProcessPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processPage = await _context.ProcessPages
                .FirstOrDefaultAsync(m => m.ProcessPageId == id);
            if (processPage == null)
            {
                return NotFound();
            }

            return View(processPage);
        }

        // GET: ProcessPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessPageId,OpId,QcMId")] ProcessPage processPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processPage);
        }

        // GET: ProcessPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processPage = await _context.ProcessPages.FindAsync(id);
            if (processPage == null)
            {
                return NotFound();
            }
            return View(processPage);
        }

        // POST: ProcessPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessPageId,OpId,QcMId")] ProcessPage processPage)
        {
            if (id != processPage.ProcessPageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessPageExists(processPage.ProcessPageId))
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
            return View(processPage);
        }

        // GET: ProcessPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processPage = await _context.ProcessPages
                .FirstOrDefaultAsync(m => m.ProcessPageId == id);
            if (processPage == null)
            {
                return NotFound();
            }

            return View(processPage);
        }

        // POST: ProcessPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processPage = await _context.ProcessPages.FindAsync(id);
            if (processPage != null)
            {
                _context.ProcessPages.Remove(processPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessPageExists(int id)
        {
            return _context.ProcessPages.Any(e => e.ProcessPageId == id);
        }
    }
}
