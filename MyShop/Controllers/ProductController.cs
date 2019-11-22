using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Category(int? typeId, int? trademarkId)
        {
            if (typeId.HasValue)
            {
                List<Product> productsHasTypeId = _context.products.Include(p => p.Trademark).Include(p => p.Discount).Include(p => p.ProductType).Where(p => p.ProductType.TypeID == typeId || p.ProductType.FatherTypeID == typeId).ToList();
                var productsHasTypeIdView = _mapper.Map<List<ProductViewModel>>(productsHasTypeId);
                ViewBag.Data = productsHasTypeIdView;
                ProductType type = _context.productTypes.SingleOrDefault(p => p.TypeID == typeId);
                ViewBag.type = type;
                return View();
            }
            if (trademarkId.HasValue)
            {
                List<Product> productsHasTrademarkId = _context.products.Include(p =>p.Discount).Include(p => p.Trademark).Include(p => p.Discount).Include(p => p.ProductType).Where(p => p.Trademark.TrademarkID == trademarkId).ToList();
                var productsHasTrademarkIdView = _mapper.Map<List<ProductViewModel>>(productsHasTrademarkId);
                ViewBag.Data = productsHasTrademarkIdView;
                return View();
            }
            List<Product> products = _context.products.Include(p => p.Trademark).Include(p => p.Discount).Include(p => p.ProductType).ToList();
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            ViewBag.Data = productsView;
            return View();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.products.Include(p => p.Discount).Include(p => p.ProductType).Include(p => p.Trademark);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Products/Details/5

        public IActionResult Details(int id)
        {
            Product productDetail = _context.products.Include(p => p.Trademark).Include(p => p.Discount).SingleOrDefault(p => p.ProductID == id);
            if (productDetail !=null)
            {
                ProductDetailViewModel productDetailView = _mapper.Map<ProductDetailViewModel>(productDetail);
                return View(productDetailView);
            }
            return RedirectToAction("Category");
        }

        [Route("{type}/{url}")]
        public IActionResult SeoDetails(string type, string url)
        {
            Product product = _context.products.Include(p => p.Trademark).Include(p => p.Discount).SingleOrDefault(p => p.ProductNameSeoUrl == url);
            if(product != null)
            {
                ProductDetailViewModel productDetailView = _mapper.Map<ProductDetailViewModel>(product);
                return View("Details", productDetailView);
            }
            return RedirectToAction("Category");
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
