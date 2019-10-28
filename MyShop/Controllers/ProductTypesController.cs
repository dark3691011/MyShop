using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly MyDbContext _context;

        public ProductTypesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.productTypes.Include(p => p.FatherProductType);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.productTypes
                .Include(p => p.FatherProductType)
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            List<SelectListItem> productTypes = new SelectList(_context.productTypes, "TypeID", "TypeName").ToList();
            SelectListItem nullSelectListItem = new SelectListItem() { Value = "", Text = "Không" };
            productTypes.Add(nullSelectListItem);
            ViewData["FatherTypeID"] = productTypes;
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeID,TypeName,FatherTypeID")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> productTypes = new SelectList(_context.productTypes, "TypeID", "TypeName", productType.FatherTypeID).ToList();
            SelectListItem nullSelectListItem = new SelectListItem() { Value = "", Text = "Không" };
            productTypes.Add(nullSelectListItem);
            ViewData["FatherTypeID"] = productTypes;
            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.productTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }
            List<SelectListItem> productTypes = new SelectList(_context.productTypes, "TypeID", "TypeName", productType.FatherTypeID).ToList();
            SelectListItem nullSelectListItem = new SelectListItem() { Value = "", Text = "Không" };
            productTypes.Add(nullSelectListItem);
            ViewData["FatherTypeID"] = productTypes;
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,TypeName,FatherTypeID")] ProductType productType)
        {
            if (id != productType.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(productType.TypeID))
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
            ViewData["FatherTypeID"] = new SelectList(_context.productTypes, "TypeID", "TypeName", productType.FatherTypeID);
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.productTypes
                .Include(p => p.FatherProductType)
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productType = await _context.productTypes.FindAsync(id);
            _context.productTypes.Remove(productType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypeExists(int id)
        {
            return _context.productTypes.Any(e => e.TypeID == id);
        }
    }
}
