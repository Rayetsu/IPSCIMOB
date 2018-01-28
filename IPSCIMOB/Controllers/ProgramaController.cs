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
    public class ProgramaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Programa
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramaModel.ToListAsync());
        }

        public async Task<IActionResult> InformacaoProgramas()
        {
            return View(await _context.ProgramaModel.ToListAsync());
        }

        public async Task<IActionResult> DetalhesProgramaEscolhido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaModel = await _context.ProgramaModel
                .SingleOrDefaultAsync(m => m.ProgramaID == id);
            if (programaModel == null)
            {
                return NotFound();
            }

            return View(programaModel);
        }



        // GET: Programa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaModel = await _context.ProgramaModel
                .SingleOrDefaultAsync(m => m.ProgramaID == id);
            if (programaModel == null)
            {
                return NotFound();
            }

            return View(programaModel);
        }

        // GET: Programa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramaID,Nome,Descricao,ProgramaAtual, UtilizadorProfissao")] ProgramaModel programaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programaModel);
        }

        // GET: Programa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaModel = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaID == id);
            if (programaModel == null)
            {
                return NotFound();
            }
            return View(programaModel);
        }

        // POST: Programa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramaID,Nome,Descricao,ProgramaAtual, UtilizadorProfissao")] ProgramaModel programaModel)
        {
            if (id != programaModel.ProgramaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaModelExists(programaModel.ProgramaID))
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
            return View(programaModel);
        }

        // GET: Programa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programaModel = await _context.ProgramaModel
                .SingleOrDefaultAsync(m => m.ProgramaID == id);
            if (programaModel == null)
            {
                return NotFound();
            }

            return View(programaModel);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programaModel = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaID == id);
            _context.ProgramaModel.Remove(programaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaModelExists(int id)
        {
            return _context.ProgramaModel.Any(e => e.ProgramaID == id);
        }
    }
}
