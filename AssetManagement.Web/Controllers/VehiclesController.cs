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
    public class VehiclesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicles.Include(v => v.Brand).Include(v => v.Location).Include(v => v.Model).Include(v => v.Type);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Brand)
                .Include(v => v.Location)
                .Include(v => v.Model)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "ContactInCharge");
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName");
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "Category");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SystemId,PlateNumber,BrandId,ModelId,TypeId,LocationId,AssignedDriverId,FuelType,FuelCapacity,TransmissionType,SteeringType,Horsepower,Co2Emission,GpsId,TrackerType,PurchaseValue,EstimatedEndTermValue,LastInspection,NextInspection,Status,Id,CreatedDate,UpdatedDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.Id = Guid.NewGuid();
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "ContactInCharge", vehicle.LocationId);
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName", vehicle.ModelId);
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "Category", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "ContactInCharge", vehicle.LocationId);
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName", vehicle.ModelId);
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "Category", vehicle.TypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SystemId,PlateNumber,BrandId,ModelId,TypeId,LocationId,AssignedDriverId,FuelType,FuelCapacity,TransmissionType,SteeringType,Horsepower,Co2Emission,GpsId,TrackerType,PurchaseValue,EstimatedEndTermValue,LastInspection,NextInspection,Status,Id,CreatedDate,UpdatedDate")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "ContactInCharge", vehicle.LocationId);
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName", vehicle.ModelId);
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "Category", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Brand)
                .Include(v => v.Location)
                .Include(v => v.Model)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(Guid id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
