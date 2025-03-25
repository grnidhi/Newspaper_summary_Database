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
    public class RsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rss.Include(r => r.Product).Include(r => r.Stage).Include(r => r.customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rs = await _context.Rss
                .Include(r => r.Product)
                .Include(r => r.Stage)
                .Include(r => r.customer)
                .FirstOrDefaultAsync(m => m.RId == id);
            if (rs == null)
            {
                return NotFound();
            }

            return View(rs);
        }

        // GET: Rs/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber");
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Rs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RId,Reason,CustomerId,ProductId,StageId")] Rs rs)
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
                ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", rs.ProductId);
                ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", rs.StageId);
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", rs.CustomerId);
                return View(rs);
            }
           

            _context.Add(rs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Rs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rs = await _context.Rss.FindAsync(id);
            if (rs == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", rs.ProductId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", rs.StageId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", rs.CustomerId);
            return View(rs);
        }

        // POST: Rs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RId,Reason,CustomerId,ProductId,StageId")] Rs rs)
        {
            if (id != rs.RId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RsExists(rs.RId))
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
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", rs.ProductId);
            ViewData["StageId"] = new SelectList(_context.StageMasters, "StageId", "StageName", rs.StageId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", rs.CustomerId);
            return View(rs);
        }

        // GET: Rs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rs = await _context.Rss
                .Include(r => r.Product)
                .Include(r => r.Stage)
                .Include(r => r.customer)
                .FirstOrDefaultAsync(m => m.RId == id);
            if (rs == null)
            {
                return NotFound();
            }

            return View(rs);
        }

        // POST: Rs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rs = await _context.Rss.FindAsync(id);
            if (rs != null)
            {
                _context.Rss.Remove(rs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RsExists(int id)
        {
            return _context.Rss.Any(e => e.RId == id);
        }
    }
}
