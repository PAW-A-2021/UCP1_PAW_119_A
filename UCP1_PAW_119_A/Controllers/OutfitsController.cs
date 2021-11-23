using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_119_A.Models;

namespace UCP1_PAW_119_A.Controllers
{
    public class OutfitsController : Controller
    {
        private readonly TokoOutfitContext _context;

        public OutfitsController(TokoOutfitContext context)
        {
            _context = context;
        }

        // GET: Outfits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Outfits.ToListAsync());
        }

        // GET: Outfits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outfit = await _context.Outfits
                .FirstOrDefaultAsync(m => m.IdOutfit == id);
            if (outfit == null)
            {
                return NotFound();
            }

            return View(outfit);
        }

        // GET: Outfits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOutfit,NamaOutfit,Perusahaan,Harga")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outfit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outfit = await _context.Outfits.FindAsync(id);
            if (outfit == null)
            {
                return NotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOutfit,NamaOutfit,Perusahaan,Harga")] Outfit outfit)
        {
            if (id != outfit.IdOutfit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outfit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutfitExists(outfit.IdOutfit))
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
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outfit = await _context.Outfits
                .FirstOrDefaultAsync(m => m.IdOutfit == id);
            if (outfit == null)
            {
                return NotFound();
            }

            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var outfit = await _context.Outfits.FindAsync(id);
            _context.Outfits.Remove(outfit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutfitExists(int id)
        {
            return _context.Outfits.Any(e => e.IdOutfit == id);
        }
    }
}
