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
    public class OperatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Operates.Include(o => o.DrawingMaster).Include(o => o.Line).Include(o => o.Select).Include(o => o.Stage);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Operates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operate = await _context.Operates
                .Include(o => o.DrawingMaster)
                .Include(o => o.Line)
                .Include(o => o.Select)
                .Include(o => o.Stage)
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (operate == null)
            {
                return NotFound();
            }

            return View(operate);
        }

        // GET: Operates/Create
        public IActionResult Create()
        {
            ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber");
            ViewData["LineId"] = new SelectList(_context.LineMasters, "LineId", "LineName");
            ViewData["ShiftId"] = new SelectList(_context.SelectShifts, "ShiftId", "ShiftName");
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName");
            return View();
        }

        // POST: Operates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpId,DrawingId,StageId,OperatorName,OperatorCode,LineId,ShiftId,Date")] Operate operate)
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
                ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber", operate.DrawingId);
                ViewData["LineId"] = new SelectList(_context.LineMasters, "LineId", "LineName", operate.LineId);
                ViewData["ShiftId"] = new SelectList(_context.SelectShifts, "ShiftId", "ShiftName", operate.ShiftId);
                ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", operate.StageId);
                return View(operate);

            }
            _context.Add(operate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Operates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operate = await _context.Operates.FindAsync(id);
            if (operate == null)
            {
                return NotFound();
            }
            ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber", operate.DrawingId);
            ViewData["LineId"] = new SelectList(_context.LineMasters, "LineId", "LineName", operate.LineId);
            ViewData["ShiftId"] = new SelectList(_context.SelectShifts, "ShiftId", "ShiftName", operate.ShiftId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", operate.StageId);
            return View(operate);
        }

        // POST: Operates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpId,DrawingId,StageId,OperatorName,OperatorCode,LineId,ShiftId,Date")] Operate operate)
        {
            if (id != operate.OpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperateExists(operate.OpId))
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
            ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber", operate.DrawingId);
            ViewData["LineId"] = new SelectList(_context.LineMasters, "LineId", "LineName", operate.LineId);
            ViewData["ShiftId"] = new SelectList(_context.SelectShifts, "ShiftId", "ShiftName", operate.ShiftId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", operate.StageId);
            return View(operate);
        }

        // GET: Operates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operate = await _context.Operates
                .Include(o => o.DrawingMaster)
                .Include(o => o.Line)
                .Include(o => o.Select)
                .Include(o => o.Stage)
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (operate == null)
            {
                return NotFound();
            }

            return View(operate);
        }

        // POST: Operates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operate = await _context.Operates.FindAsync(id);
            if (operate != null)
            {
                _context.Operates.Remove(operate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperateExists(int id)
        {
            return _context.Operates.Any(e => e.OpId == id);
        }
        public JsonResult GetStagesByDrawingId(int drawingId)
        {
            var stages = _context.StageMasters
                                 .Where(s => s.DrawingId == drawingId)
                                 .Select(s => new
                                 {
                                     StageId = s.StageId,
                                     StageName = s.StageName
                                 }).ToList();

            return Json(stages);
        }



        [HttpPost]
        public IActionResult ProcessBarcode(int drawingId, int stageId)
        {
            // Get the selected Drawing and Stage details from the database
            var drawing = _context.Draws.FirstOrDefault(d => d.DrawingId == drawingId);
            var stage = _context.StageMasters.FirstOrDefault(s => s.StageId == stageId);

            if (drawing == null || stage == null)
            {
                // Handle the case where the drawing or stage is not found
                return NotFound("Drawing or Stage not found.");
            }

            // Pass these details to the view using ViewBag
            ViewBag.DrawingNumber = drawing.ProductNumber;
            ViewBag.StageName = stage.StageName;

            return View(); // Ensure you return the correct view
        }





    }
}