using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Authorization;

namespace IPSCIMOB.Controllers
{
    public class InformacoesGeraisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InformacoesGeraisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InformacoesGerais
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.InformacaoGeral.ToListAsync());
        }

        // GET: InformacoesGerais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoGeral = await _context.InformacaoGeral
                .SingleOrDefaultAsync(m => m.InformacaoGeralID == id);
            if (informacaoGeral == null)
            {
                return NotFound();
            }

            return View(informacaoGeral);
        }

        // GET: InformacoesGerais/Create
        [Authorize(Roles = "CIMOB")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: InformacoesGerais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InformacaoGeralID,Titulo,Descricao")] InformacaoGeral informacaoGeral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacaoGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(informacaoGeral);
        }

        // GET: InformacoesGerais/Edit/5
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.InformacaoGeralID == id);
            if (informacaoGeral == null)
            {
                return NotFound();
            }
            return View(informacaoGeral);
        }

        // POST: InformacoesGerais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("InformacaoGeralID,Titulo,Descricao")] InformacaoGeral informacaoGeral)
        {
            if (id != informacaoGeral.InformacaoGeralID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacaoGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacaoGeralExists(informacaoGeral.InformacaoGeralID))
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
            return View(informacaoGeral);
        }

        // GET: InformacoesGerais/Delete/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoGeral = await _context.InformacaoGeral
                .SingleOrDefaultAsync(m => m.InformacaoGeralID == id);
            if (informacaoGeral == null)
            {
                return NotFound();
            }

            return View(informacaoGeral);
        }

        // POST: InformacoesGerais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.InformacaoGeralID == id);
            _context.InformacaoGeral.Remove(informacaoGeral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacaoGeralExists(int id)
        {
            return _context.InformacaoGeral.Any(e => e.InformacaoGeralID == id);
        }
    }
}
