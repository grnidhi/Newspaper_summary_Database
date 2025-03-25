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
    public class StageConnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StageConnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StageConns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StageConns.Include(s => s.CurrentStage).Include(s => s.FailStage).Include(s => s.Gziee).Include(s => s.PassStage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StageConns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageConn = await _context.StageConns
                .Include(s => s.CurrentStage)
                .Include(s => s.FailStage)
                .Include(s => s.Gziee)
                .Include(s => s.PassStage)
                .FirstOrDefaultAsync(m => m.SCid == id);
            if (stageConn == null)
            {
                return NotFound();
            }

            return View(stageConn);
        }

        // GET: StageConns/Create
        public IActionResult Create()
        {
            ViewData["CurrentStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription");
            ViewData["FailStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription");
            ViewData["GId"] = new SelectList(_context.Group, "GId", "GName");
            ViewData["PassStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription");
            return View();
        }

        // POST: StageConns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SCid,GId,CurrentStageId,FailStageId,PassStageId,CreatedDate")] StageConn stageConn)
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
                ViewData["CurrentStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.CurrentStageId);
                ViewData["FailStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.FailStageId);
                ViewData["GId"] = new SelectList(_context.Group, "GId", "GName", stageConn.GId);
                ViewData["PassStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.PassStageId);
                return View(stageConn);
            }
           

            _context.Add(stageConn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: StageConns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageConn = await _context.StageConns.FindAsync(id);
            if (stageConn == null)
            {
                return NotFound();
            }
            ViewData["CurrentStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.CurrentStageId);
            ViewData["FailStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.FailStageId);
            ViewData["GId"] = new SelectList(_context.Group, "GId", "GName", stageConn.GId);
            ViewData["PassStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.PassStageId);
            return View(stageConn);
        }

        // POST: StageConns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SCid,GId,CurrentStageId,FailStageId,PassStageId,CreatedDate")] StageConn stageConn)
        {
            if (id != stageConn.SCid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stageConn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageConnExists(stageConn.SCid))
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
            ViewData["CurrentStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.CurrentStageId);
            ViewData["FailStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.FailStageId);
            ViewData["GId"] = new SelectList(_context.Group, "GId", "GName", stageConn.GId);
            ViewData["PassStageId"] = new SelectList(_context.StageMasters, "StageId", "StageDescription", stageConn.PassStageId);
            return View(stageConn);
        }

        // GET: StageConns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageConn = await _context.StageConns
                .Include(s => s.CurrentStage)
                .Include(s => s.FailStage)
                .Include(s => s.Gziee)
                .Include(s => s.PassStage)
                .FirstOrDefaultAsync(m => m.SCid == id);
            if (stageConn == null)
            {
                return NotFound();
            }

            return View(stageConn);
        }

        // POST: StageConns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageConn = await _context.StageConns.FindAsync(id);
            if (stageConn != null)
            {
                _context.StageConns.Remove(stageConn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageConnExists(int id)
        {
            return _context.StageConns.Any(e => e.SCid == id);
        }
    }
}
