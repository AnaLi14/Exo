using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exo.Data;
using Exo.Models;

namespace Exo.Controllers
{
    public class ExoController : Controller
    {
        private readonly ExoContext _context;

        public ExoController(ExoContext context)
        {
            _context = context;
        }

        // GET: Exo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exo.ToListAsync());
        }

        // GET: Exo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exo = await _context.Exo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exo == null)
            {
                return NotFound();
            }

            return View(exo);
        }

        // GET: Exo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Exo.Models.Exo exo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exo);
        }

        // GET: Exo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exo = await _context.Exo.FindAsync(id);
            if (exo == null)
            {
                return NotFound();
            }
            return View(exo);
        }

        // POST: Exo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Exo.Models.Exo exo)
        {
            if (id != exo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExoExists(exo.Id))
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
            return View(exo);
        }

        // GET: Exo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exo = await _context.Exo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exo == null)
            {
                return NotFound();
            }

            return View(exo);
        }

        // POST: Exo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exo = await _context.Exo.FindAsync(id);
            if (exo != null)
            {
                _context.Exo.Remove(exo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExoExists(int id)
        {
            return _context.Exo.Any(e => e.Id == id);
        }
    }
}
