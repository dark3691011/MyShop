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
    public class TrademarksController : Controller
    {
        private readonly MyDbContext _context;

        public TrademarksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Trademarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.trademarks.ToListAsync());
        }

        // GET: Trademarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trademark = await _context.trademarks
                .FirstOrDefaultAsync(m => m.TrademarkID == id);
            if (trademark == null)
            {
                return NotFound();
            }

            return View(trademark);
        }

        // GET: Trademarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trademarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trademark trademark, IFormFile fLogo)
        {
            if (ModelState.IsValid)
            {
                trademark.Logo = TeacherHiensTool.UploadHinh(fLogo,"logo");
                _context.Add(trademark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trademark);
        }

        // GET: Trademarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trademark = await _context.trademarks.FindAsync(id);
            if (trademark == null)
            {
                return NotFound();
            }
            return View(trademark);
        }

        // POST: Trademarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Trademark trademark, IFormFile fLogo)
        {
            if (id != trademark.TrademarkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trademark.Logo = TeacherHiensTool.UploadHinh(fLogo, "Logo");
                    _context.Update(trademark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrademarkExists(trademark.TrademarkID))
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
            return View(trademark);
        }

        // GET: Trademarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trademark = await _context.trademarks
                .FirstOrDefaultAsync(m => m.TrademarkID == id);
            if (trademark == null)
            {
                return NotFound();
            }

            return View(trademark);
        }

        // POST: Trademarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trademark = await _context.trademarks.FindAsync(id);
            _context.trademarks.Remove(trademark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrademarkExists(int id)
        {
            return _context.trademarks.Any(e => e.TrademarkID == id);
        }
    }
}
