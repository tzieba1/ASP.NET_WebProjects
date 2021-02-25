﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhysicianAPI.Models;

namespace PhysicianAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PhysiciansController : ControllerBase
  {
    private readonly chdbContext _context;

    public PhysiciansController(chdbContext context)
    {
      _context = context;
    }

    // GET: api/Physicians
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Physician>>> GetPhysicians()
    {
      return await _context.Physicians.ToListAsync();
    }

    // GET: api/Physicians/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Physician>> GetPhysician(int id)
    {
      var physician = await _context.Physicians.FindAsync(id);

      if (physician == null)
      {
        return NotFound();
      }

      return physician;
    }

    // PUT: api/Physicians/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPhysician(int id, Physician physician)
    {
      if (id != physician.PhysicianId)
      {
        return BadRequest();
      }

      _context.Entry(physician).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PhysicianExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Physicians
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Physician>> PostPhysician(Physician physician)
    {
      var maxId = _context.Physicians.Max(p => p.PhysicianId);
      physician.PhysicianId = maxId + 1;

      _context.Physicians.Add(physician);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (PhysicianExists(physician.PhysicianId))
        {
          return Conflict();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetPhysician", new { id = physician.PhysicianId }, physician);
    }

    // DELETE: api/Physicians/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Physician>> DeletePhysician(int id)
    {
      var physician = await _context.Physicians.FindAsync(id);
      if (physician == null)
      {
        return NotFound();
      }

      _context.Physicians.Remove(physician);
      await _context.SaveChangesAsync();

      return physician;
    }

    private bool PhysicianExists(int id)
    {
      return _context.Physicians.Any(e => e.PhysicianId == id);
    }
  }
}
