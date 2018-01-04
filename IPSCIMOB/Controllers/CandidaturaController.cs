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
using Microsoft.AspNetCore.Identity;
using IPSCIMOB.Models.ManageViewModels;

namespace IPSCIMOB.Controllers
{
    public class CandidaturaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidaturaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Candidatura
        public async Task<IActionResult> Index()
        {
            return View(await _context.CandidaturaModel.ToListAsync());
        }


        // GET: Candidatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaModel = await _context.CandidaturaModel
                .SingleOrDefaultAsync(m => m.CandidaturaID == id);
            if (candidaturaModel == null)
            {
                return NotFound();
            }

            return View(candidaturaModel);
        }

        // GET: Candidatura/Create
        public async Task<IActionResult> ConsultarCandidaturaAluno()
        {
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            //var model = new IndexViewModel
            //{
            //    Nome = user.Nome,
            //    NumeroInterno = user.NumeroInterno
            //};
            return View();
        }

        public IActionResult ConsultarCandidaturaFuncionario()
        {
            return View();
        }

        // POST: Candidatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidaturaID,Programa,EntrevistaID,Nome,NumeroInterno,IsBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {                
                candidaturaModel.Utilizador = user;

                
                _context.Add(candidaturaModel);
                await _context.SaveChangesAsync();
                user.CandidaturaAtual = candidaturaModel.CandidaturaID;
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(RegulamentoMob));
            }
            return View(candidaturaModel);

        }

        // GET: Candidatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == id);
            if (candidaturaModel == null)
            {
                return NotFound();
            }
            return View(candidaturaModel);
        }

        // POST: Candidatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaID,Programa,EntrevistaID,Nome,NumeroInterno,IsBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
        {
            if (id != candidaturaModel.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidaturaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaModelExists(candidaturaModel.CandidaturaID))
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
            return View(candidaturaModel);
        }

        // GET: Candidatura/Edit/5
        public async Task<IActionResult> EditCandidatura(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == id);
            if (candidaturaModel == null)
            {
                return NotFound();
            }
            return View(candidaturaModel);
        }

        // POST: Candidatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> EditCandidatura([Bind("CandidaturaID,Programa,EntrevistaID,Nome,NumeroInterno,IsBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.CandidaturaAtual != candidaturaModel.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidaturaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaModelExists(candidaturaModel.CandidaturaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SubmeterDocs));
            }
            return View(candidaturaModel);







            
            /*var candidaturaModel1 = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            if (candidaturaModel1 == null)
            {
                return NotFound();
            }

            if (user.CandidaturaAtual != candidaturaModel1.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidaturaModel1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaModelExists(candidaturaModel1.CandidaturaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SubmeterDocs));
            }
            return View(candidaturaModel1);*/
        }


        // GET: Candidatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaModel = await _context.CandidaturaModel
                .SingleOrDefaultAsync(m => m.CandidaturaID == id);
            if (candidaturaModel == null)
            {
                return NotFound();
            }

            return View(candidaturaModel);
        }

        // POST: Candidatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == id);
            _context.CandidaturaModel.Remove(candidaturaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaModelExists(int id)
        {
            return _context.CandidaturaModel.Any(e => e.CandidaturaID == id);

        }









        [Authorize(Roles = "Aluno")]
        public IActionResult VascoDaGama()
        {
            return View();
        }

        [Authorize(Roles = "Aluno")]
        public IActionResult PolitecnicoDeMacau()
        {
            return View();
        }

        [Authorize(Roles = "Aluno")]
        public IActionResult Erasmus()
        {

            return View();
        }

        [Authorize(Roles = "Funcionário")]
        public IActionResult ErasmusFormacaoTrabalho()
        {
            return View();
        }

        [Authorize(Roles = "Aluno")]
        public IActionResult SantanderUniversidades()
        {
            return View();
        }

        [Authorize(Roles = "Funcionário")]
        public IActionResult SantanderMissoes()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult Documentacao()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult Entrevista()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult ConsultarCandidatura()
        {
            if (this.User.IsInRole("Aluno"))
                return View("ConsultarCandidaturaAluno");
            else if (this.User.IsInRole("Funcionário"))
                return View("ConsultarCandidaturaFuncionario");
            return null;            
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult RegulamentoMob()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult SubmeterDocs()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult MarcarEntrevistas()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult FinalCandidatura()
        {
            return View();
        }
    }
}

