using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anything.Data;
using Anything.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Anything.Controllers
{
    public class OrderMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetDrawingsByCustomer(int customerId)
        {
            var drawings = _context.Draws
                                  .Where(d => d.CustomerId == customerId)
                                  .Select(d => new { d.DrawingId, d.ProductNumber })
                                  .ToList();
            return Json(drawings);
        }

        [HttpGet]
        public JsonResult GetProductsByDrawing(int drawingId)
        {
            var products = _context.ProductMasters
                                   .Where(p => p.DrawingId == drawingId)
                                   .Select(p => new { p.ProductId, p.ProductNumber })
                                   .ToList();
            return Json(products);
        }

        // GET: OrderMasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderMasters.Include(o => o.Customer).Include(o => o.Draw).Include(o => o.ProductMasters);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMasters
                .Include(o => o.Customer)
                .Include(o => o.Draw)
                .Include(o => o.ProductMasters)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            return View(orderMaster);
        }

        // GET: OrderMasters/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber");
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber");
            return View();
        }

        // POST: OrderMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,OrderNum,CustomerId,IssueDate,KeyDate,DrawingId,ProductId,OrderQty,Revision,HSNcode,Itemcode,AddInfo,ProDetail,len,Po,Location,Qty")] OrderMaster orderMaster)
        {

            _context.Add(orderMaster);
            await _context.SaveChangesAsync();


            int orderId = orderMaster.Oid;
            int quantity = orderMaster.OrderQty;
            //Console.WriteLine(orderId);

            for (int i = 1; i <= quantity; i++)
            {
                var orderDeatail = new OrderMDetail
                {
                    Oid = orderId,
                    Barcode = $"{orderMaster.OrderNum}.{i.ToString("D4")}"
                };

                _context.Add(orderDeatail);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }


        // GET: OrderMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMasters.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", orderMaster.CustomerId);
            ViewData["DrawingId"] = new SelectList(_context.Draws, "DrawingId", "ProductNumber", orderMaster.DrawingId);
            ViewData["ProductId"] = new SelectList(_context.ProductMasters, "ProductId", "ProductNumber", orderMaster.ProductId);
            return View(orderMaster);
        }

        // POST: OrderMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: OrderMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMasters
                .Include(o => o.Customer)
                .Include(o => o.Draw)
                .Include(o => o.ProductMasters)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            return View(orderMaster);
        }

        // POST: OrderMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderMaster = await _context.OrderMasters.FindAsync(id);
            if (orderMaster != null)
            {
                _context.OrderMasters.Remove(orderMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMasterExists(int id)
        {
            return _context.OrderMasters.Any(e => e.Oid == id);
        }

        private List<string> GenerateBarcodes(string orderNumber, int orderQty)
        {
            List<string> barcodes = new List<string>();

            // Extract the numeric part from OrderNumber
            string numericPart = new string(orderNumber.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(numericPart))
            {
                throw new InvalidOperationException("OrderNumber must contain a numeric part for barcode generation.");
            }

            // Generate barcodes based on orderQty
            for (int i = 1; i <= orderQty; i++)
            {
                string barcode = $"{numericPart}.{i:D4}";
                barcodes.Add(barcode);
            }

            return barcodes;
        }

      

    }
}