using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.products.Include(p => p.Discount).Include(p => p.ProductType).Include(p => p.Trademark);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Discount)
                .Include(p => p.ProductType)
                .Include(p => p.Trademark)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["DiscountID"] = new SelectList(_context.discounts, "DiscountID", "DiscountID");
            ViewData["TypeID"] = new SelectList(_context.productTypes, "TypeID", "TypeName");
            ViewData["TrademarkID"] = new SelectList(_context.trademarks, "TrademarkID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,UnitPrice,Amount,Description,ProductImage,DiscountID,TypeID,TrademarkID")] Product product,IFormFile fImage)
        {
            if (ModelState.IsValid)
            {
                product.ProductImage = TeacherHiensTool.UploadHinh(fImage, "product");
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscountID"] = new SelectList(_context.discounts, "DiscountID", "DiscountID", product.DiscountID);
            ViewData["TypeID"] = new SelectList(_context.productTypes, "TypeID", "TypeName", product.TypeID);
            ViewData["TrademarkID"] = new SelectList(_context.trademarks, "TrademarkID", "Name", product.TrademarkID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["DiscountID"] = new SelectList(_context.discounts, "DiscountID", "DiscountID", product.DiscountID);
            ViewData["TypeID"] = new SelectList(_context.productTypes, "TypeID", "TypeName", product.TypeID);
            ViewData["TrademarkID"] = new SelectList(_context.trademarks, "TrademarkID", "Name", product.TrademarkID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,UnitPrice,Amount,Description,ProductImage,DiscountID,TypeID,TrademarkID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["DiscountID"] = new SelectList(_context.discounts, "DiscountID", "DiscountID", product.DiscountID);
            ViewData["TypeID"] = new SelectList(_context.productTypes, "TypeID", "TypeName", product.TypeID);
            ViewData["TrademarkID"] = new SelectList(_context.trademarks, "TrademarkID", "Name", product.TrademarkID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Discount)
                .Include(p => p.ProductType)
                .Include(p => p.Trademark)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.ProductID == id);
        }
    }
}
