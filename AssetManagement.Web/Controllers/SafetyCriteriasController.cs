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
    public class SafetyCriteriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SafetyCriteriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafetyCriterias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SafetyCriterias.ToListAsync());
        }

        // GET: SafetyCriterias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyCriteria = await _context.SafetyCriterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safetyCriteria == null)
            {
                return NotFound();
            }

            return View(safetyCriteria);
        }

        // GET: SafetyCriterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SafetyCriterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CriteriaName,RequiredBy,Purpose,Notes,Id,CreatedDate,UpdatedDate")] SafetyCriteria safetyCriteria)
        {
            if (ModelState.IsValid)
            {
                safetyCriteria.Id = Guid.NewGuid();
                _context.Add(safetyCriteria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(safetyCriteria);
        }

        // GET: SafetyCriterias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyCriteria = await _context.SafetyCriterias.FindAsync(id);
            if (safetyCriteria == null)
            {
                return NotFound();
            }
            return View(safetyCriteria);
        }

        // POST: SafetyCriterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CriteriaName,RequiredBy,Purpose,Notes,Id,CreatedDate,UpdatedDate")] SafetyCriteria safetyCriteria)
        {
            if (id != safetyCriteria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safetyCriteria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafetyCriteriaExists(safetyCriteria.Id))
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
            return View(safetyCriteria);
        }

        // GET: SafetyCriterias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyCriteria = await _context.SafetyCriterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safetyCriteria == null)
            {
                return NotFound();
            }

            return View(safetyCriteria);
        }

        // POST: SafetyCriterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var safetyCriteria = await _context.SafetyCriterias.FindAsync(id);
            if (safetyCriteria != null)
            {
                _context.SafetyCriterias.Remove(safetyCriteria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafetyCriteriaExists(Guid id)
        {
            return _context.SafetyCriterias.Any(e => e.Id == id);
        }
    }
}
