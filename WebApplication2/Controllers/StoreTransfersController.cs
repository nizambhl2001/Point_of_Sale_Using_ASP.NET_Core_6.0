using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StoreTransfersController : Controller
    {
        private readonly POSDbContext _context;

        public StoreTransfersController(POSDbContext context)
        {
            _context = context;
        }

        // GET: StoreTransfers
        public async Task<IActionResult> Index()
        {
            var pOSDbContext = _context.StoreTransfers.Include(s => s.Product);
            return View(await pOSDbContext.ToListAsync());
        }

        // GET: StoreTransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StoreTransfers == null)
            {
                return NotFound();
            }

            var storeTransfer = await _context.StoreTransfers
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.StoreTransferId == id);
            if (storeTransfer == null)
            {
                return NotFound();
            }

            return View(storeTransfer);
        }

        // GET: StoreTransfers/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: StoreTransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreTransferId,ProductId,StoreFrom,StoreTo,Qty")] StoreTransfer storeTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", storeTransfer.ProductId);
            return View(storeTransfer);
        }

        // GET: StoreTransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoreTransfers == null)
            {
                return NotFound();
            }

            var storeTransfer = await _context.StoreTransfers.FindAsync(id);
            if (storeTransfer == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", storeTransfer.ProductId);
            return View(storeTransfer);
        }

        // POST: StoreTransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreTransferId,ProductId,StoreFrom,StoreTo,Qty")] StoreTransfer storeTransfer)
        {
            if (id != storeTransfer.StoreTransferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreTransferExists(storeTransfer.StoreTransferId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", storeTransfer.ProductId);
            return View(storeTransfer);
        }

        // GET: StoreTransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoreTransfers == null)
            {
                return NotFound();
            }

            var storeTransfer = await _context.StoreTransfers
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.StoreTransferId == id);
            if (storeTransfer == null)
            {
                return NotFound();
            }

            return View(storeTransfer);
        }

        // POST: StoreTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoreTransfers == null)
            {
                return Problem("Entity set 'POSDbContext.StoreTransfers'  is null.");
            }
            var storeTransfer = await _context.StoreTransfers.FindAsync(id);
            if (storeTransfer != null)
            {
                _context.StoreTransfers.Remove(storeTransfer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreTransferExists(int id)
        {
          return (_context.StoreTransfers?.Any(e => e.StoreTransferId == id)).GetValueOrDefault();
        }
    }
}
