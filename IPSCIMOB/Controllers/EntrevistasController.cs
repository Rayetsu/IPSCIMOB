using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPSCIMOB.Data;
using IPSCIMOB.Models;

namespace IPSCIMOB.Controllers
{
    public class EntrevistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object _userManager;

        public EntrevistasController(ApplicationDbContext context)
        {
            _context = context;
           
        }

       
       // GET: Entrevistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrevista.ToListAsync());
        }

        // GET: Entrevistas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .SingleOrDefaultAsync(m => m.Id == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // GET: Entrevistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entrevistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,DataDeEntrevista")] Entrevista entrevista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrevista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrevista);
        }

        // GET: Entrevistas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.Id == id);
            if (entrevista == null)
            {
                return NotFound();
            }
            return View(entrevista);
        }

        // POST: Entrevistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome,Email,DataDeEntrevista")] Entrevista entrevista)
        {
            if (id != entrevista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrevista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrevistaExists(entrevista.Id))
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
            return View(entrevista);
        }

        // GET: Entrevistas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .SingleOrDefaultAsync(m => m.Id == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // POST: Entrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.Id == id);
            _context.Entrevista.Remove(entrevista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrevistaExists(string id)
        {
            return _context.Entrevista.Any(e => e.Id == id);
        }
    }
}
