using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastrucuture.Data;
using AssetManagement.Web.DTOs;

namespace AssetManagement.Web.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehicleModels.Include(v => v.Brand);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelName,ModelYear,BrandId,Id")] VehicleModelDto modelDto)
        {
            if (ModelState.IsValid)
            {
                var brandExists = await _context.VehicleBrands.FirstAsync(b => b.Id == modelDto.BrandId);
                

                var vehicleModel = new VehicleModel
                {
                    Id = Guid.NewGuid(), // Assign a new unique ID
                    ModelName = modelDto.ModelName,
                    ModelYear = modelDto.ModelYear,
                    BrandId = modelDto.BrandId,
                    Brand = brandExists
                };

                _context.VehicleModels.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", modelDto.BrandId);
            return View(modelDto);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            var vehicleModelDto = new VehicleModelDto
            {
                ModelName = vehicleModel.ModelName,
                ModelYear = vehicleModel.ModelYear,
                BrandId = vehicleModel.BrandId,
               
            };


            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", vehicleModel.BrandId);
            return View(vehicleModelDto);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ModelName,ModelYear,BrandId,Id")] VehicleModelDto _data)
        {
            if (id != _data.Id)
            {
                return NotFound(); // Return NotFound if the ID doesn't match
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing VehicleModel from the database
                    var vehicleModel = await _context.VehicleModels
                        .FirstOrDefaultAsync(vm => vm.Id == id);

                    if (vehicleModel == null)
                    {
                        return NotFound(); // If the vehicle model is not found, return NotFound
                    }

                    // Check if the brand exists
                    var brandExists = await _context.VehicleBrands
                        .FirstOrDefaultAsync(b => b.Id == _data.BrandId);

                    if (brandExists == null)
                    {
                        ModelState.AddModelError("BrandId", "The selected brand does not exist.");
                        return View(_data); // If the brand does not exist, return the view with an error
                    }

                    // Update the properties of the existing VehicleModel
                    vehicleModel.ModelName = _data.ModelName;
                    vehicleModel.ModelYear = _data.ModelYear;
                    vehicleModel.BrandId = _data.BrandId;
                    vehicleModel.Brand = brandExists;

                    // Mark the entity as modified and save changes
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(_data.Id))
                    {
                        return NotFound(); // Handle the concurrency error and check if the entity exists
                    }
                    else
                    {
                        throw; // Rethrow the error if the issue persists
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the Index view after successful update
            }

            // Populate the view with existing data if the model state is not valid
            ViewData["BrandId"] = new SelectList(_context.VehicleBrands, "Id", "Category", _data.BrandId);
            return View(_data); // Return the view with the model data
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel != null)
            {
                _context.VehicleModels.Remove(vehicleModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(Guid id)
        {
            return _context.VehicleModels.Any(e => e.Id == id);
        }
    }
}
