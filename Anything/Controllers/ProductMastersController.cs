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
    public class ProductMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductMasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductMasters.Include(p => p.DrawingMaster).Include(p => p.customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters
                .Include(p => p.DrawingMaster)

               
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return View(productMaster);
        }

        // GET: ProductMasters/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["DrawingId"] = new SelectList(Enumerable.Empty<SelectListItem>(), "DrawingId", "ProductNumber"); // Empty initially
            return View();
        }

        // POST: ProductMasters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductNumber,CustomerId,DrawingId")] ProductMaster productMaster)
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

                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", productMaster.CustomerId);
                ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.CustomerId == productMaster.CustomerId), "DrawingId", "ProductNumber", productMaster.DrawingId);
                return View(productMaster);

            }
       
            _context.Add(productMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", productMaster.CustomerId);
            ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.CustomerId == productMaster.CustomerId), "DrawingId", "ProductNumber", productMaster.DrawingId);
            return View(productMaster);
        }

        // POST: ProductMasters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductNumber,CustomerId,DrawingId")] ProductMaster productMaster)
        {
            if (id != productMaster.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMasterExists(productMaster.ProductId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", productMaster.CustomerId);
            ViewData["DrawingId"] = new SelectList(_context.Draws.Where(d => d.CustomerId == productMaster.CustomerId), "DrawingId", "ProductNumber", productMaster.DrawingId);
            return View(productMaster);
        }

        // GET: ProductMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters
                .Include(p => p.DrawingMaster)
                
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return View(productMaster);
        }

        // POST: ProductMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMaster = await _context.ProductMasters.FindAsync(id);
            if (productMaster != null)
            {
                _context.ProductMasters.Remove(productMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMasterExists(int id)
        {
            return _context.ProductMasters.Any(e => e.ProductId == id);
        }

        // This is the new method to get drawings by customer
        [HttpGet]
        public JsonResult GetDrawingsByCustomer(int customerId)
        {
            var drawings = _context.Draws
                .Where(d => d.CustomerId == customerId)
                .Select(d => new { d.DrawingId, d.ProductNumber })
                .ToList();
            return Json(drawings);
        }
    }
}
