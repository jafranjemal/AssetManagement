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
    public class DriverCertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverCertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverCertifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriverCertifications.Include(d => d.Driver);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverCertifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverCertification = await _context.DriverCertifications
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverCertification == null)
            {
                return NotFound();
            }

            return View(driverCertification);
        }

        // GET: DriverCertifications/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber");
            return View();
        }

        // POST: DriverCertifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,CertificationName,IssuedBy,IssuedDate,ExpiryDate,Id,CreatedDate,UpdatedDate")] DriverCertification driverCertification)
        {
            if (ModelState.IsValid)
            {
                driverCertification.Id = Guid.NewGuid();
                _context.Add(driverCertification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverCertification.DriverId);
            return View(driverCertification);
        }

        // GET: DriverCertifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverCertification = await _context.DriverCertifications.FindAsync(id);
            if (driverCertification == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverCertification.DriverId);
            return View(driverCertification);
        }

        // POST: DriverCertifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DriverId,CertificationName,IssuedBy,IssuedDate,ExpiryDate,Id,CreatedDate,UpdatedDate")] DriverCertification driverCertification)
        {
            if (id != driverCertification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverCertification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverCertificationExists(driverCertification.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "ContactNumber", driverCertification.DriverId);
            return View(driverCertification);
        }

        // GET: DriverCertifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverCertification = await _context.DriverCertifications
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverCertification == null)
            {
                return NotFound();
            }

            return View(driverCertification);
        }

        // POST: DriverCertifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var driverCertification = await _context.DriverCertifications.FindAsync(id);
            if (driverCertification != null)
            {
                _context.DriverCertifications.Remove(driverCertification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverCertificationExists(Guid id)
        {
            return _context.DriverCertifications.Any(e => e.Id == id);
        }
    }
}
