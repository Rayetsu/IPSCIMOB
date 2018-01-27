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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



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
        [Authorize(Roles = "CIMOB")]
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
        public IActionResult ConsultarCandidaturaAluno()
        {
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
        public async Task<IActionResult> Create([Bind("CandidaturaID,Programa, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado, EstadoDocumentos")] CandidaturaModel candidaturaModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            if (ModelState.IsValid)
            {
                candidaturaModel.Email = user.Email;
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
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaID,Programa, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa, EstadoBolsa, IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado, EstadoDocumentos")] CandidaturaModel candidaturaModel)
        {
            var userEmail = candidaturaModel.Email;

            if (id != candidaturaModel.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.Aceites))
                    {
                        new Notificacao(userEmail, "CIMOB - Estado Documentos Submetidos", "Os documentos submetidos ao Programa " + candidaturaModel.Programa + " foram: " + candidaturaModel.EstadoDocumentos);
                    }
                    if (candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.Recusados))
                    {
                        new Notificacao(userEmail, "CIMOB - Estado Documentos Submetidos", "Os documentos submetidos ao Programa " + candidaturaModel.Programa + " foram: " + candidaturaModel.EstadoDocumentos);
                    }
                    _context.Update(candidaturaModel);
                    await _context.SaveChangesAsync();
                    if (candidaturaModel.Estado == EstadoCandidatura.Aceite || candidaturaModel.Estado == EstadoCandidatura.Recusado
                        || candidaturaModel.Estado == EstadoCandidatura.EmMobilidade)
                    {
                        new Notificacao(userEmail, "CIMOB - Estado Candidatura", "A sua candidatura ao Programa " + candidaturaModel.Programa + " foi: " + candidaturaModel.Estado);
                    }
                    new Notificacao(userEmail, "CIMOB - Alteração", "A sua candidatura ao Programa "
                            + candidaturaModel.Programa + " sofreu alterações de dados pelo CIMOB.");

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
        public async Task<IActionResult> EditRegulamento([Bind("CandidaturaID,Programa, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa,EstadoBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Pais,Estado")] CandidaturaModel candidaturaModel)
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
        public async Task<IActionResult> Documentacao(int? id)
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
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;

            return View(informacaoGeral);
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> Entrevista()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.NumeroUser = user.NumeroInterno;
            return View(await _context.Entrevista.ToListAsync());
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> ConsultarCandidatura()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;

            var user = await _userManager.GetUserAsync(User);
            ViewBag.Nome = user.Nome;
            ViewBag.NumeroInterno = user.NumeroInterno;


            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                if (c.Nome.Equals(user.Nome))
                {
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

            if (candidaturaModel == null || candidaturaModel.Programa != programaAtual.Titulo)
            {
                if (this.User.IsInRole("Aluno"))
                {
                    return View("ConsultarCandidaturaAluno");
                }
                else if (this.User.IsInRole("Funcionário"))
                    return View("ConsultarCandidaturaFuncionario");
            }
            else
            {
                if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao2)
                {
                    return View("RegulamentoMob", candidaturaModel);
                }
                else if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao3)
                {
                    return View("SubmeterDocs", candidaturaModel);
                }
                else if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao4)
                {
                    return RedirectToAction("Create", "Entrevistas");
                }
                else if (candidaturaModel.Estado == EstadoCandidatura.EmEspera ||
                           candidaturaModel.Estado == EstadoCandidatura.Aceite ||
                               candidaturaModel.Estado == EstadoCandidatura.Recusado ||
                                    candidaturaModel.Estado == EstadoCandidatura.EmMobilidade)
                {
                    return View("FinalCandidatura", candidaturaModel);
                }
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
        }



        public async Task<Entrevista> GetEntrevista()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);

            var user = await _userManager.GetUserAsync(User);

            foreach (Entrevista e in _context.Entrevista)
            {
                if (e.NumeroAluno == user.NumeroInterno && e.NomePrograma.Equals(programaAtual.Titulo) && !e.Estado.Equals(EstadoEntrevista.Recusado))
                {
                    return e;
                }
            }
            return null;
        }


        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> MarcarEntrevistas()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;
            var user = await _userManager.GetUserAsync(User);

            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            if (candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.EmEspera)
                    || candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.Recusados))
            {
                candidaturaModel.Estado = EstadoCandidatura.EmRealizacao3;
            }
            else
            {
                candidaturaModel.Estado = EstadoCandidatura.EmRealizacao4;
            }
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Entrevistas", GetEntrevista());
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> FinalCandidatura()
        {
            var programaAtual = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Titulo;

            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);

            if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao4)
            {
                candidaturaModel.Estado = EstadoCandidatura.EmEspera;
                new Notificacao(user.Email, "Candidatura Registada", "A sua candidatura no programa " + programaAtual.Titulo + " foi registada com sucesso!");
            }
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();

            return View(candidaturaModel);
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
            return NotFound();
        }


        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> HistoricoCandidaturas(int? id)
        {
            var candidatura = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == id);
            ViewBag.NomeUtilizador = candidatura.Nome;
            ViewBag.NumeroInterno = candidatura.NumeroInterno;

            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                if (c.NumeroInterno.Equals(candidatura.NumeroInterno))
                {
                    candidaturasUser.Add(c);
                }
            }
            return View(candidaturasUser);
        }



        public Boolean verificarAluno(int numero, List<CandidaturaModel> candidaturasUser)
        {
            foreach (CandidaturaModel c in candidaturasUser)
            {
                if (c.NumeroInterno.Equals(numero))
                {
                    return true;
                }
            }
            return false;
        }

        [Authorize(Roles = "CIMOB")]
        public IActionResult AlunosComCandidaturas()
        {
            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                if (!verificarAluno(c.NumeroInterno, candidaturasUser))
                {
                    candidaturasUser.Add(c);
                }
            }
            return View(candidaturasUser);
        }
    }
}
