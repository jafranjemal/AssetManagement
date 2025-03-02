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
    public class DriverSafetyCompliancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverSafetyCompliancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverSafetyCompliances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriverSafetyCompliances.Include(d => d.Driver).Include(d => d.SafetyCriteria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverSafetyCompliances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSafetyCompliance = await _context.DriverSafetyCompliances
                .Include(d => d.Driver)
                .Include(d => d.SafetyCriteria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverSafetyCompliance == null)
            {
                return NotFound();
            }

            return View(driverSafetyCompliance);
        }

        // GET: DriverSafetyCompliances/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber");
            ViewData["SafetyCriteriaId"] = new SelectList(_context.SafetyCriterias, "Id", "CriteriaName");
            return View();
        }

        // POST: DriverSafetyCompliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,SafetyCriteriaId,DateCompleted,ExpiryDate,IsCertified,Id,CreatedDate,UpdatedDate")] DriverSafetyCompliance driverSafetyCompliance)
        {
            if (ModelState.IsValid)
            {
                driverSafetyCompliance.Id = Guid.NewGuid();
                _context.Add(driverSafetyCompliance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverSafetyCompliance.DriverId);
            ViewData["SafetyCriteriaId"] = new SelectList(_context.SafetyCriterias, "Id", "CriteriaName", driverSafetyCompliance.SafetyCriteriaId);
            return View(driverSafetyCompliance);
        }

        // GET: DriverSafetyCompliances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSafetyCompliance = await _context.DriverSafetyCompliances.FindAsync(id);
            if (driverSafetyCompliance == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverSafetyCompliance.DriverId);
            ViewData["SafetyCriteriaId"] = new SelectList(_context.SafetyCriterias, "Id", "CriteriaName", driverSafetyCompliance.SafetyCriteriaId);
            return View(driverSafetyCompliance);
        }

        // POST: DriverSafetyCompliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DriverId,SafetyCriteriaId,DateCompleted,ExpiryDate,IsCertified,Id,CreatedDate,UpdatedDate")] DriverSafetyCompliance driverSafetyCompliance)
        {
            if (id != driverSafetyCompliance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverSafetyCompliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverSafetyComplianceExists(driverSafetyCompliance.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverSafetyCompliance.DriverId);
            ViewData["SafetyCriteriaId"] = new SelectList(_context.SafetyCriterias, "Id", "CriteriaName", driverSafetyCompliance.SafetyCriteriaId);
            return View(driverSafetyCompliance);
        }

        // GET: DriverSafetyCompliances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSafetyCompliance = await _context.DriverSafetyCompliances
                .Include(d => d.Driver)
                .Include(d => d.SafetyCriteria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverSafetyCompliance == null)
            {
                return NotFound();
            }

            return View(driverSafetyCompliance);
        }

        // POST: DriverSafetyCompliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var driverSafetyCompliance = await _context.DriverSafetyCompliances.FindAsync(id);
            if (driverSafetyCompliance != null)
            {
                _context.DriverSafetyCompliances.Remove(driverSafetyCompliance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverSafetyComplianceExists(Guid id)
        {
            return _context.DriverSafetyCompliances.Any(e => e.Id == id);
        }
    }
}
