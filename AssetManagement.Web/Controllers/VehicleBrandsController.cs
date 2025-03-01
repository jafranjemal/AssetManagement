using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastrucuture.Data;

namespace AssetManagement.Web.Controllers
{
    public class VehicleBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleBrands.ToListAsync());
        }

        // GET: VehicleBrands/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }

            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Category,Division,SubDivision,Id,CreatedDate,UpdatedDate")] VehicleBrand vehicleBrand)
        {
            if (ModelState.IsValid)
            {
                vehicleBrand.Id = Guid.NewGuid();
                _context.Add(vehicleBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands.FindAsync(id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }
            return View(vehicleBrand);
        }

        // POST: VehicleBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Category,Division,SubDivision,Id,CreatedDate,UpdatedDate")] VehicleBrand vehicleBrand)
        {
            if (id != vehicleBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleBrandExists(vehicleBrand.Id))
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
            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }

            return View(vehicleBrand);
        }

        // POST: VehicleBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicleBrand = await _context.VehicleBrands.FindAsync(id);
            if (vehicleBrand != null)
            {
                _context.VehicleBrands.Remove(vehicleBrand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleBrandExists(Guid id)
        {
            return _context.VehicleBrands.Any(e => e.Id == id);
        }
    }
}
