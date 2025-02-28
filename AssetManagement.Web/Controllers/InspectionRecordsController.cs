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
    public class InspectionRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InspectionRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InspectionRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InspectionRecords.Include(i => i.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InspectionRecords/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspectionRecord = await _context.InspectionRecords
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspectionRecord == null)
            {
                return NotFound();
            }

            return View(inspectionRecord);
        }

        // GET: InspectionRecords/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType");
            return View();
        }

        // POST: InspectionRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,LastInspection,NextInspection,Id,CreatedDate,UpdatedDate")] InspectionRecord inspectionRecord)
        {
            if (ModelState.IsValid)
            {
                inspectionRecord.Id = Guid.NewGuid();
                _context.Add(inspectionRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", inspectionRecord.VehicleId);
            return View(inspectionRecord);
        }

        // GET: InspectionRecords/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspectionRecord = await _context.InspectionRecords.FindAsync(id);
            if (inspectionRecord == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", inspectionRecord.VehicleId);
            return View(inspectionRecord);
        }

        // POST: InspectionRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VehicleId,LastInspection,NextInspection,Id,CreatedDate,UpdatedDate")] InspectionRecord inspectionRecord)
        {
            if (id != inspectionRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectionRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionRecordExists(inspectionRecord.Id))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "FuelType", inspectionRecord.VehicleId);
            return View(inspectionRecord);
        }

        // GET: InspectionRecords/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspectionRecord = await _context.InspectionRecords
                .Include(i => i.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspectionRecord == null)
            {
                return NotFound();
            }

            return View(inspectionRecord);
        }

        // POST: InspectionRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inspectionRecord = await _context.InspectionRecords.FindAsync(id);
            if (inspectionRecord != null)
            {
                _context.InspectionRecords.Remove(inspectionRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionRecordExists(Guid id)
        {
            return _context.InspectionRecords.Any(e => e.Id == id);
        }
    }
}
