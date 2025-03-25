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
    public class OrderMDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderMDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderMDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderMDetails.ToListAsync());
        }

        // GET: OrderMDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMDetail = await _context.OrderMDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderMDetail == null)
            {
                return NotFound();
            }

            return View(orderMDetail);
        }

 
        private bool OrderMDetailExists(int id)
        {
            return _context.OrderMDetails.Any(e => e.Id == id);
        }
    }
}
