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
    public class ProducTypesController : Controller
    {
        private readonly POSDbContext _context;

        public ProducTypesController(POSDbContext context)
        {
            _context = context;
        }

        // GET: ProducTypes
        public async Task<IActionResult> Index()
        {
              return _context.ProducTypes != null ? 
                          View(await _context.ProducTypes.ToListAsync()) :
                          Problem("Entity set 'POSDbContext.ProducTypes'  is null.");
        }

        // GET: ProducTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProducTypes == null)
            {
                return NotFound();
            }

            var producType = await _context.ProducTypes
                .FirstOrDefaultAsync(m => m.ProductTypeId == id);
            if (producType == null)
            {
                return NotFound();
            }

            return View(producType);
        }

        // GET: ProducTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductTypeId,ProductTypeName")] ProducType producType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producType);
        }

        // GET: ProducTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProducTypes == null)
            {
                return NotFound();
            }

            var producType = await _context.ProducTypes.FindAsync(id);
            if (producType == null)
            {
                return NotFound();
            }
            return View(producType);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ProductTypeId,ProductTypeName")] ProducType producType)
        {
            if (id != producType.ProductTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducTypeExists(producType.ProductTypeId))
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
            return View(producType);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProducTypes == null)
            {
                return NotFound();
            }

            var producType = await _context.ProducTypes
                .FirstOrDefaultAsync(m => m.ProductTypeId == id);
            if (producType == null)
            {
                return NotFound();
            }

            return View(producType);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ProducTypes == null)
            {
                return Problem("Entity set 'POSDbContext.ProducTypes'  is null.");
            }
            var producType = await _context.ProducTypes.FindAsync(id);
            if (producType != null)
            {
                _context.ProducTypes.Remove(producType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducTypeExists(int? id)
        {
          return (_context.ProducTypes?.Any(e => e.ProductTypeId == id)).GetValueOrDefault();
        }
    }
}
