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
    public class TransactionTypesController : Controller
    {
        private readonly POSDbContext _context;

        public TransactionTypesController(POSDbContext context)
        {
            _context = context;
        }

        // GET: TransactionTypes
        public async Task<IActionResult> Index()
        {
              return _context.TransactionTypes != null ? 
                          View(await _context.TransactionTypes.ToListAsync()) :
                          Problem("Entity set 'POSDbContext.TransactionTypes'  is null.");
        }

        // GET: TransactionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactionTypes == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionType == null)
            {
                return NotFound();
            }

            return View(transactionType);
        }

        // GET: TransactionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,TransactionTypeName")] TransactionType transactionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionType);
        }

        // GET: TransactionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionTypes == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes.FindAsync(id);
            if (transactionType == null)
            {
                return NotFound();
            }
            return View(transactionType);
        }

        // POST: TransactionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,TransactionTypeName")] TransactionType transactionType)
        {
            if (id != transactionType.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionTypeExists(transactionType.TransactionId))
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
            return View(transactionType);
        }

        // GET: TransactionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionTypes == null)
            {
                return NotFound();
            }

            var transactionType = await _context.TransactionTypes
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionType == null)
            {
                return NotFound();
            }

            return View(transactionType);
        }

        // POST: TransactionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionTypes == null)
            {
                return Problem("Entity set 'POSDbContext.TransactionTypes'  is null.");
            }
            var transactionType = await _context.TransactionTypes.FindAsync(id);
            if (transactionType != null)
            {
                _context.TransactionTypes.Remove(transactionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionTypeExists(int id)
        {
          return (_context.TransactionTypes?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
