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
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicles.Include(v => v.AssignedDriver).Include(v => v.Brand).Include(v => v.Location).Include(v => v.Model).Include(v => v.Type);
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
                .Include(v => v.AssignedDriver)
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
            ViewData["AssignedDriverId"] = new SelectList(_context.Drivers, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category");
           
           
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName");
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "TypeName");
            var permits = _context.Permits.ToList(); // Fetch from DB
            ViewData["Permits"] = permits;
        
                var se = _context.SafetyEquipments.ToList();
            ViewData["SafetyEquipment"] = se;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBrandDetails(Guid brandId)
        {
            var brand = await _context.VehicleBrands
                                      .Where(b => b.Id == brandId)
                                      .Select(b => new
                                      {
                                          b.Category,
                                          b.Division,
                                          b.SubDivision
                                      })
                                      .FirstOrDefaultAsync();

            if (brand == null)
            {
                return NotFound();
            }

            return Json(brand);
        }

        [HttpGet]
        public async Task<IActionResult> GetTypeDetails(Guid typeId)
        {
            var vehicleType = await _context.VehicleTypes
                                      .Where(b => b.Id == typeId)
                                      .Select(b => new
                                      {
                                          b.TypeName, //(Passenger/Transport/Equipment)
                                          b.Category, // Pick Up
                                          b.Division, // Pick Up 3 Ton
                                          b.SubDivision, // Ouble cabin
                                          b.ChassisNo,
                                          b.EngineNo,

                                          b.SeatsNo,
                                          b.NomberOfCylinder,
                                          b.DoorsNo,
                                          b.Color,
                                          b.TransmissionType,
                                          b.SteeringType,

                                          b.FuelType,
                                          b.FuelCapacity,
                                          b.Altered,
                                          b.Notes,
                                      })
                                      .FirstOrDefaultAsync();

            if (vehicleType == null)
            {
                return NotFound();
            }

            return Json(vehicleType);
        }
         [HttpGet]
        public async Task<IActionResult> GetDriverDetails(Guid driverId)
        {
            var driver = await _context.Drivers
                                      .Where(b => b.Id == driverId)
                                      .Select(b => new
                                      {
                                          b.Id,
                                          b.ContactNumber,
                                          b.Name
                                      })
                                      .FirstOrDefaultAsync();

            if (driver == null)
            {
                return NotFound();
            }

            var driverSafetyCompliance = _context.DriverSafetyCompliances
       .Where(d => d.DriverId == driverId)
       .Include(d => d.SafetyCriteria) // Include safety criteria details
       .ToList();

            ViewData["DriverSafety"] = driverSafetyCompliance;

            return Json(driver);
        }


        [HttpGet("GetAllSafetyEquipment")]
        public IActionResult GetAllSafetyEquipment()
        {
            var equipmentList = _context.SafetyEquipments.Select(eq => new
            {
                eq.Id,
                eq.Name,
                eq.Purpose
            }).ToList();

            return Ok(equipmentList);
        }

       

        [HttpGet]
        public IActionResult GetDriverSafetyCompliance(Guid driverId)
        {
            var driverSafetyCompliance = _context.DriverSafetyCompliances
                .Where(d => d.DriverId == driverId)
                .Include(d => d.SafetyCriteria) // Include safety criteria details
                .Select(d => new
                {
                    CriteriaName = d.SafetyCriteria.CriteriaName,
                    DateCompleted = d.DateCompleted.ToString("MM/dd/yyyy"),
                    Purpose = d.SafetyCriteria.Purpose,
                    Notes = d.SafetyCriteria.Notes
                })
                .ToList();

            return Json(driverSafetyCompliance);
        }


        // Endpoint to get models based on brand ID
        [HttpGet]
        public async Task<IActionResult> GetModelsByBrand(Guid brandId)
        {
            var models = await _context.VehicleModels
                                       .Where(m => m.BrandId == brandId)
                                       .Select(m => new { m.Id, m.ModelName })
                                       .ToListAsync();

            return Json(models);
        }

        // Endpoint to get model details based on model ID
        [HttpGet]
        public async Task<IActionResult> GetModelDetails(Guid modelId)
        {
            var model = await _context.VehicleModels
                                      .Where(m => m.Id == modelId)
                                      .Select(m => new { m.ModelName, m.ModelYear, m.ModelNo })
                                      .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Json(model);
        }




        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("SystemId,PlateNumber,VehicleName,VehicleStatus,OperationalStatus,CurrentStattionlStatus,MaintenanceStatus,EngineCo2Emission,Co2Standard,Horsepower,EmissionSpec,ContactInCharge,ProjectName,CostCenter,DivisionName,InitialManufacturerPrice,PurchaseValue,EstimatedEndOfTermValue,TypeId, AssignedDriverId,BrandId,ModelId,LastInspection,NextInspection,Id,CreatedDate,UpdatedDate, Location")] Vehicle vehicle)
        public async Task<IActionResult> Create( Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.Id = Guid.NewGuid();
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedDriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", vehicle.AssignedDriverId);
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
 
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
            ViewData["AssignedDriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", vehicle.AssignedDriverId);
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
            
            ViewData["ModelId"] = new SelectList(_context.VehicleModels, "Id", "ModelName", vehicle.ModelId);
            ViewData["TypeId"] = new SelectList(_context.VehicleTypes, "Id", "Category", vehicle.TypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SystemId,PlateNumber,VehicleName,VehicleStatus,OperationalStatus,CurrentStattionlStatus,MaintenanceStatus,EngineCo2Emission,Co2Standard,Horsepower,EmissionSpec,LocationName,ContactInCharge,ProjectName,CostCenter,DivisionName,InitialManufacturerPrice,PurchaseValue,EstimatedEndOfTermValue,TypeId, AssignedDriverId,BrandId,ModelId,LastInspection,NextInspection,Id,CreatedDate,UpdatedDate")] Vehicle vehicle)
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
            ViewData["AssignedDriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", vehicle.AssignedDriverId);
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicle.BrandId);
 
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
                .Include(v => v.AssignedDriver)
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
