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
    public class SafetyEquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SafetyEquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafetyEquipments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SafetyEquipments.Include(s => s.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SafetyEquipments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyEquipment = await _context.SafetyEquipments
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safetyEquipment == null)
            {
                return NotFound();
            }

            return View(safetyEquipment);
        }

        // GET: SafetyEquipments/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType");
            return View();
        }

        // POST: SafetyEquipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Name,InstalledDate,Purpose,Id,CreatedDate,UpdatedDate")] SafetyEquipment safetyEquipment)
        {
            if (ModelState.IsValid)
            {
                safetyEquipment.Id = Guid.NewGuid();
                _context.Add(safetyEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", safetyEquipment.VehicleId);
            return View(safetyEquipment);
        }

        // GET: SafetyEquipments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyEquipment = await _context.SafetyEquipments.FindAsync(id);
            if (safetyEquipment == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", safetyEquipment.VehicleId);
            return View(safetyEquipment);
        }

        // POST: SafetyEquipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VehicleId,Name,InstalledDate,Purpose,Id,CreatedDate,UpdatedDate")] SafetyEquipment safetyEquipment)
        {
            if (id != safetyEquipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safetyEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafetyEquipmentExists(safetyEquipment.Id))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", safetyEquipment.VehicleId);
            return View(safetyEquipment);
        }

        // GET: SafetyEquipments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyEquipment = await _context.SafetyEquipments
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safetyEquipment == null)
            {
                return NotFound();
            }

            return View(safetyEquipment);
        }

        // POST: SafetyEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var safetyEquipment = await _context.SafetyEquipments.FindAsync(id);
            if (safetyEquipment != null)
            {
                _context.SafetyEquipments.Remove(safetyEquipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafetyEquipmentExists(Guid id)
        {
            return _context.SafetyEquipments.Any(e => e.Id == id);
        }
    }
}
