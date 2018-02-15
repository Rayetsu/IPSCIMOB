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
    public class SugestaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SugestaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sugestao
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sugestao.ToListAsync());
        }

        // GET: Sugestao/Details/5
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao
                .SingleOrDefaultAsync(m => m.SugestaoID == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // GET: Sugestao/Create
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sugestao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Create([Bind("SugestaoID,EmailUtilizador,TextoSugestao")] Sugestao sugestao)
        {
            sugestao.EmailUtilizador = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(sugestao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
                //return RedirectToAction(nameof(Index));
            }
            return View(sugestao);
        }

        // GET: Sugestao/Edit/5
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao.SingleOrDefaultAsync(m => m.SugestaoID == id);
            if (sugestao == null)
            {
                return NotFound();
            }
            return View(sugestao);
        }

        // POST: Sugestao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("SugestaoID,EmailUtilizador,TextoSugestao")] Sugestao sugestao)
        {
            if (id != sugestao.SugestaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugestao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugestaoExists(sugestao.SugestaoID))
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
            return View(sugestao);
        }

        // GET: Sugestao/Delete/5
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao
                .SingleOrDefaultAsync(m => m.SugestaoID == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // POST: Sugestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Aluno, Funcionário, CIMOB")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sugestao = await _context.Sugestao.SingleOrDefaultAsync(m => m.SugestaoID == id);
            _context.Sugestao.Remove(sugestao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugestaoExists(int id)
        {
            return _context.Sugestao.Any(e => e.SugestaoID == id);
        }
    }
}
