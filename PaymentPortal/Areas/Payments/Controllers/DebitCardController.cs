using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaymentPortal.Models;

namespace PaymentPortal.Areas.Payments.Controllers
{
    [Area("Payments")]
    public class DebitCardController : Controller
    {
        private readonly PaymentPortalContext _context;

        public DebitCardController(PaymentPortalContext context)
        {
            _context = context;
        }

        // GET: Payments/DebitCard
        public async Task<IActionResult> Index()
        {
            return View(await _context.DebitCard.ToListAsync());
        }

        // GET: Payments/DebitCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitCard = await _context.DebitCard
                .FirstOrDefaultAsync(m => m.DebitCardID == id);
            if (debitCard == null)
            {
                return NotFound();
            }

            return View(debitCard);
        }

        // GET: Payments/DebitCard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/DebitCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DebitCardID,DebitCardNumber")] DebitCard debitCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(debitCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(debitCard);
        }

        // GET: Payments/DebitCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitCard = await _context.DebitCard.FindAsync(id);
            if (debitCard == null)
            {
                return NotFound();
            }
            return View(debitCard);
        }

        // POST: Payments/DebitCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DebitCardID,DebitCardNumber")] DebitCard debitCard)
        {
            if (id != debitCard.DebitCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debitCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebitCardExists(debitCard.DebitCardID))
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
            return View(debitCard);
        }

        // GET: Payments/DebitCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debitCard = await _context.DebitCard
                .FirstOrDefaultAsync(m => m.DebitCardID == id);
            if (debitCard == null)
            {
                return NotFound();
            }

            return View(debitCard);
        }

        // POST: Payments/DebitCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var debitCard = await _context.DebitCard.FindAsync(id);
            _context.DebitCard.Remove(debitCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DebitCardExists(int id)
        {
            return _context.DebitCard.Any(e => e.DebitCardID == id);
        }
    }
}
