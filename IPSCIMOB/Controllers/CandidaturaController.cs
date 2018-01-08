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
        private readonly CandidaturaModel cadidaturaAtual;

        public CandidaturaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Candidatura
        //[Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CandidaturaModel.ToListAsync());
        }


        // GET: Candidatura/Details/5
        [Authorize(Roles = "CIMOB")]
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
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            if (ModelState.IsValid)
            {
                candidaturaModel.Utilizador = user;
                candidaturaModel.Nome = user.Nome;
                candidaturaModel.NumeroInterno = user.NumeroInterno;

                candidaturaModel.Programa = programaAtual.Titulo;

                candidaturaModel.Estado = EstadoCandidatura.EmRealizacao2;
                _context.Add(candidaturaModel);
                await _context.SaveChangesAsync();
                user.CandidaturaAtual = candidaturaModel.CandidaturaID;
                await _userManager.UpdateAsync(user);
                
                return RedirectToAction(nameof(RegulamentoMob));
            }
            return View(candidaturaModel);

        }

        // GET: Candidatura/Edit/5
        [Authorize(Roles = "CIMOB")]
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
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaID,Programa,EntrevistaID,Nome,NumeroInterno,IsBolsa, EstadoBolsa, IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
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
        // POST: Candidatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRegulamento([Bind("CandidaturaID,Programa,EntrevistaID,Nome,NumeroInterno,IsBolsa,EstadoBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.CandidaturaAtual != candidaturaModel.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!candidaturaModel.IsConfirmado)
                    return RedirectToAction(nameof(RegulamentoMob));
                try
                {
                    candidaturaModel.Estado = EstadoCandidatura.EmRealizacao3;
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
        }


        // GET: Candidatura/Delete/5
        [Authorize(Roles = "CIMOB")]
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
        [Authorize(Roles = "CIMOB")]
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
        public async Task<IActionResult> VascoDaGama()
        {
            var programaNovo = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Programa Vasco Da Gama");
            var programaAntigo = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            if (programaAntigo != null & programaAntigo != programaNovo)
            {
                programaAntigo.ProgramaAtual = false;
                _context.Update(programaAntigo);
            }
            programaNovo.ProgramaAtual = true;
            _context.Update(programaNovo);
            await _context.SaveChangesAsync();

            ViewBag.NomePrograma = programaNovo.Titulo;

            return View();
        }

        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> PolitecnicoDeMacau()
        {
            var informacaoAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Politécnico de Macau");
            if (informacaoAtual != null & informacaoAtual != informacaoGeral)
            {
                informacaoAtual.ProgramaAtual = false;
                _context.Update(informacaoAtual);
            }
            informacaoGeral.ProgramaAtual = true;
            _context.Update(informacaoGeral);
            await _context.SaveChangesAsync();

            return View();
        }

        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> Erasmus()
        {
            var informacaoAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Erasmus+");
            if (informacaoAtual != null & informacaoAtual != informacaoGeral)
            {
                informacaoAtual.ProgramaAtual = false;
                _context.Update(informacaoAtual);
            }
            informacaoGeral.ProgramaAtual = true;
            _context.Update(informacaoGeral);
            await _context.SaveChangesAsync();

            return View();
        }

        [Authorize(Roles = "Funcionário")]
        public async Task<IActionResult> ErasmusFormacaoTrabalho()
        {
            var informacaoAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Erasmus+");
            if (informacaoAtual != null & informacaoAtual != informacaoGeral)
            {
                informacaoAtual.ProgramaAtual = false;
                _context.Update(informacaoAtual);
            }
            informacaoGeral.ProgramaAtual = true;
            _context.Update(informacaoGeral);
            await _context.SaveChangesAsync();

            return View();
        }

        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> SantanderUniversidades()
        {
            var informacaoAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Santander Universidades");
            if (informacaoAtual != null & informacaoAtual != informacaoGeral)
            {
                informacaoAtual.ProgramaAtual = false;
                _context.Update(informacaoAtual);
            }
            informacaoGeral.ProgramaAtual = true;
            _context.Update(informacaoGeral);
            await _context.SaveChangesAsync();

            return View();
        }

        [Authorize(Roles = "Funcionário")]
        public async Task<IActionResult> SantanderMissoes()
        {
            var informacaoAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var informacaoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Santander Universidades Missões de Ensino e Formação oferece bolsas");
            if (informacaoAtual != null & informacaoAtual != informacaoGeral)
            {
                informacaoAtual.ProgramaAtual = false;
                _context.Update(informacaoAtual);
            }
            informacaoGeral.ProgramaAtual = true;
            _context.Update(informacaoGeral);
            await _context.SaveChangesAsync();

            return View();
        }




        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> Documentacao()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult Entrevista()
        {
            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> ConsultarCandidatura()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;

            var user = await _userManager.GetUserAsync(User);
            
     
            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in  _context.CandidaturaModel) {
                if (c.Nome.Equals(user.Nome)){
                    candidaturasUser.Add(c);
                }                   
            }

            CandidaturaModel candidaturaModel = null;
            foreach (CandidaturaModel c in candidaturasUser)
            {
                if (c.Programa.Equals(programaAtual.Titulo))
                {
                    candidaturaModel = c;
                }
            }           

            if (this.User.IsInRole("Aluno")) {   
                    if (candidaturaModel == null ) 
                    {
                         return View("ConsultarCandidaturaAluno");
                    }else if (candidaturaModel.Programa != programaAtual.Titulo)
                {
                    return View("ConsultarCandidaturaAluno");
                }
                else{                    
                        //if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao1){
                        //    return View("ConsultarCandidaturaAluno");
                        //}
                        if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao2) {
                            return View("RegulamentoMob", candidaturaModel);
                        }
                        else if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao3) {
                            return View("SubmeterDocs", candidaturaModel);
                        }
                        else if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao4) {
                            return View("MarcarEntrevistas", candidaturaModel);
                        }
                        else if (candidaturaModel.Estado == EstadoCandidatura.EmEspera ||
                                   candidaturaModel.Estado == EstadoCandidatura.Aceite ||
                                       candidaturaModel.Estado == EstadoCandidatura.Recusado ||
                                            candidaturaModel.Estado == EstadoCandidatura.EmMobilidade) {
                            return View("FinalCandidatura", candidaturaModel);
                        }
                    }
                }
                else if (this.User.IsInRole("Funcionário"))     //  FALTA   FAZER IGUAL COMO NO ALUNO 
                {
                    return View("ConsultarCandidaturaFuncionario");
                }
       
            return NotFound();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> RegulamentoMob()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;

            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);

            return View(candidaturaModel);
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> SubmeterDocs()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;
            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            candidaturaModel.Estado = EstadoCandidatura.EmRealizacao3;
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();
            return View(candidaturaModel);
            //return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> MarcarEntrevistas()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;
            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            candidaturaModel.Estado = EstadoCandidatura.EmRealizacao4;
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();
            return View(candidaturaModel);
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> FinalCandidatura()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;            

            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            if(candidaturaModel.Estado == EstadoCandidatura.EmRealizacao4)
            {
                candidaturaModel.Estado = EstadoCandidatura.EmEspera;
            }      
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();

            return View(candidaturaModel);
            //return View(await _context.CandidaturaModel.ToListAsync());
        }

        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> AlunosEmMob()
        {
            return View(await _context.CandidaturaModel.ToListAsync());
        }


        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> CandidaturaInicio()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);

            if (programaAtual.Titulo == "Santander Universidades")
                return View("SantanderMissoes");
            else if (programaAtual.Titulo == "Santander Universidades Missões de Ensino e Formação oferece bolsas")
                return View("SantanderMissoes");
            else if (programaAtual.Titulo == "Erasmus+")
                return View("Erasmus");
            else if (programaAtual.Titulo == "Programa Vasco Da Gama")
                return View("VascoDaGama");
            else if (programaAtual.Titulo == "Politécnico de Macau")
                return View("PolitecnicoDeMacau");

            // meter os restantes programas

            return NotFound();
        }


    }
}
