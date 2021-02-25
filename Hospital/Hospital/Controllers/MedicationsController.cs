using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers
{
  public class MedicationsController : Controller
  {
    private readonly CHDBContext _context;

    public MedicationsController(CHDBContext context)
    {
      _context = context;
    }

    // GET: Medications
    public async Task<IActionResult> Index(string sortOrder, string searchString)
    {
      ViewBag.DescriptionSortParm = string.IsNullOrEmpty(sortOrder) ? "description_desc" : "";
      ViewBag.CostSortParm = sortOrder == "cost" ? "cost_desc" : "cost";
      ViewBag.CurrentFilter = searchString;

      var medications = from m in _context.Medications
                        select m;

      if (!string.IsNullOrEmpty(searchString))
      {
        medications = medications.Where(m => m.MedicationDescription.Contains(searchString));
      }

      switch (sortOrder)
      {
        case "description_desc":
          medications = medications.OrderByDescending(m => m.MedicationDescription);
          break;

        case "cost":
          medications = medications.OrderBy(m => m.MedicationCost);
          break;

        case "cost_desc":
          medications = medications.OrderByDescending(m => m.MedicationCost);
          break;
        default:
          medications = medications.OrderBy(m => m.MedicationDescription);
          break;
      }

      return View(await medications.AsNoTracking().ToListAsync());
    }

    // GET: Medications/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var medications = await _context.Medications
          .FirstOrDefaultAsync(m => m.MedicationId == id);
      if (medications == null)
      {
        return NotFound();
      }

      return View(medications);
    }

    // GET: Medications/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Medications/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MedicationId,MedicationDescription,MedicationCost,PackageSize,Strength,Sig,UnitsUsedYtd,LastPrescribedDate")] Medications medications)
    {
      if (ModelState.IsValid)
      {
        _context.Add(medications);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(medications);
    }

    // GET: Medications/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var medications = await _context.Medications.FindAsync(id);
      if (medications == null)
      {
        return NotFound();
      }
      return View(medications);
    }

    // POST: Medications/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("MedicationId,MedicationDescription,MedicationCost,PackageSize,Strength,Sig,UnitsUsedYtd,LastPrescribedDate")] Medications medications)
    {
      if (id != medications.MedicationId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(medications);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MedicationsExists(medications.MedicationId))
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
      return View(medications);
    }

    // GET: Medications/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var medications = await _context.Medications
          .FirstOrDefaultAsync(m => m.MedicationId == id);
      if (medications == null)
      {
        return NotFound();
      }

      return View(medications);
    }

    // POST: Medications/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var medications = await _context.Medications.FindAsync(id);
      _context.Medications.Remove(medications);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MedicationsExists(int id)
    {
      return _context.Medications.Any(e => e.MedicationId == id);
    }
  }
}
