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
    public class QcMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QcMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QcMasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QcMasters.Include(q => q.Product).Include(q => q.Stage).Include(q => q.customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QcMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qcMaster = await _context.QcMasters
                .Include(q => q.Product)
                .Include(q => q.Stage)
                .Include(q => q.customer)
                .FirstOrDefaultAsync(m => m.QcMId == id);
            if (qcMaster == null)
            {
                return NotFound();
            }

            return View(qcMaster);
        }

        // GET: QcMasters/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber");
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: QcMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QcMId,FormName,CustomerId,ProductId,StageId,ParameterName,ParameterTitle,ParameterType,Min,Max")] QcMaster qcMaster)
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

                ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", qcMaster.ProductId);
                ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", qcMaster.StageId);
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", qcMaster.CustomerId);
                return View(qcMaster);

            }
            _context.Add(qcMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: QcMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qcMaster = await _context.QcMasters.FindAsync(id);
            if (qcMaster == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", qcMaster.ProductId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", qcMaster.StageId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", qcMaster.CustomerId);
            return View(qcMaster);
        }

        // POST: QcMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QcMId,FormName,CustomerId,ProductId,StageId,ParameterName,ParameterTitle,ParameterType,Min,Max")] QcMaster qcMaster)
        {
            if (id != qcMaster.QcMId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qcMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QcMasterExists(qcMaster.QcMId))
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
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", qcMaster.ProductId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", qcMaster.StageId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", qcMaster.CustomerId);
            return View(qcMaster);
        }

        // GET: QcMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qcMaster = await _context.QcMasters
                .Include(q => q.Product)
                .Include(q => q.Stage)
                .Include(q => q.customer)
                .FirstOrDefaultAsync(m => m.QcMId == id);
            if (qcMaster == null)
            {
                return NotFound();
            }

            return View(qcMaster);
        }

        // POST: QcMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qcMaster = await _context.QcMasters.FindAsync(id);
            if (qcMaster != null)
            {
                _context.QcMasters.Remove(qcMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QcMasterExists(int id)
        {
            return _context.QcMasters.Any(e => e.QcMId == id);
        }
    }
}