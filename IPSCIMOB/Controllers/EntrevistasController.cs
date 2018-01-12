using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Identity;

namespace IPSCIMOB.Controllers
{
    public class EntrevistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EntrevistasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: Entrevistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrevista.ToListAsync());
        }

        // GET: Entrevistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .SingleOrDefaultAsync(m => m.EntrevistaId == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // GET: Entrevistas/Create
        public async Task<IActionResult> Create()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.Programa = programaAtual.Titulo;

            var user = await _userManager.GetUserAsync(User);
            Entrevista entrevista = null;
            foreach (Entrevista e in _context.Entrevista)
            {
                if (e.Estado.Equals(EstadoEntrevista.Entrevistado))
                {
                    return RedirectToAction("FinalCandidatura", "Candidatura");
                }
                else if (e.NumeroAluno == user.NumeroInterno && e.NomePrograma.Equals(programaAtual.Titulo) && e.EntrevistaAtual == true)
                {
                    if (e.Estado.Equals(EstadoEntrevista.Recusado))
                    {
                        e.EntrevistaAtual = false;
                        entrevista = e;
                    }
                    else
                    {
                        return View(e);
                    }
                }
            }
            if (entrevista != null)
            {
                _context.Update(entrevista);
                await _context.SaveChangesAsync();
            }
            return View(entrevista);
        }

        // POST: Entrevistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntrevistaId,NumeroAluno,Email, EntrevistaAtual,DataDeEntrevista,Estado,NomePrograma")] Entrevista entrevista)
        {
            var user = await _userManager.GetUserAsync(User);
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            entrevista.Email = user.Email;
            entrevista.NumeroAluno = user.NumeroInterno;
            entrevista.Estado = EstadoEntrevista.EmEspera;
            entrevista.NomePrograma = programaAtual.Titulo;
            entrevista.EntrevistaAtual = true;

            if (ModelState.IsValid)
            {
                _context.Add(entrevista);
                await _context.SaveChangesAsync();

                //return RedirectToAction("FinalCandidatura", "Candidatura");
            }
            return View(entrevista);
        }

        // GET: Entrevistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.EntrevistaId == id);
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
        public async Task<IActionResult> Edit(int id, [Bind("EntrevistaId,NumeroAluno,Email,DataDeEntrevista,Estado,NomePrograma")] Entrevista entrevista)
        {
            var userEmail = entrevista.Email;

            if (id != entrevista.EntrevistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    entrevista.EntrevistaAtual = true;
                    _context.Update(entrevista);
                    await _context.SaveChangesAsync();
                    if (entrevista.Estado == EstadoEntrevista.Aceite)
                    {
                        new Notificacao(userEmail, "Cimob- Entrevista", "A sua entrevista foi aceite. Consulte o site para mais INFO.");
                    }
                    else if (entrevista.Estado == EstadoEntrevista.Recusado)
                    {
                        new Notificacao(userEmail, "Cimob- Entrevista", "A sua entrevista foi recusada. Por favor marque uma entrevista nova.");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrevistaExists(entrevista.EntrevistaId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .SingleOrDefaultAsync(m => m.EntrevistaId == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // POST: Entrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.EntrevistaId == id);
            _context.Entrevista.Remove(entrevista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrevistaExists(int id)
        {
            return _context.Entrevista.Any(e => e.EntrevistaId == id);
        }
    }
}
