﻿using System;
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
        public async Task<IActionResult> Create([Bind("CandidaturaID, Programa, InstituicaoNome, InstituicaoPais, InstituicaoCidade, DataInicioCandidatura, DataFimCandidatura, Semestre, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Estado, EstadoDocumentos")] CandidaturaModel candidaturaModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);

            int result1 = DateTime.Compare(DateTime.Now, programaAtual.PrazoCandidaturaPrimeiroSemestre);
            int result2 = DateTime.Compare(DateTime.Now, programaAtual.PrazoCandidaturaSegundoSemestre);
            if (ModelState.IsValid)
            {
                if (candidaturaModel.Semestre.Equals(Semestre.PrimeiroSemestre) && result1 > 0
                    || candidaturaModel.Semestre.Equals(Semestre.SegundoSemestre) && result2 > 0)
                {
                    return RedirectToAction(nameof(ConsultarCandidatura));
                }
                candidaturaModel.Email = user.Email;
                candidaturaModel.Nome = user.Nome;
                candidaturaModel.NumeroInterno = user.NumeroInterno;

                candidaturaModel.Programa = programaAtual.Nome;
                candidaturaModel.DataInicioCandidatura = DateTime.Now;

                foreach (InstituicaoParceiraModel i in _context.InstituicaoParceiraModel)
                {
                    if (i.Nome == candidaturaModel.InstituicaoNome && programaAtual.Nome == i.ProgramaNome)
                    {
                        candidaturaModel.InstituicaoPais = i.Pais;
                        candidaturaModel.InstituicaoCidade = i.Cidade;
                    }
                }

                candidaturaModel.Estado = EstadoCandidatura.EmRealizacao2;
                _context.Add(candidaturaModel);
                await _context.SaveChangesAsync();
                user.CandidaturaAtual = candidaturaModel.CandidaturaID;
                await _userManager.UpdateAsync(user);

                return RedirectToAction(nameof(RegulamentoMob));
            }
            return RedirectToAction(nameof(ConsultarCandidatura));

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
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaID,Programa,InstituicaoNome, InstituicaoPais, InstituicaoCidade,DataInicioCandidatura, DataFimCandidatura, Semestre, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa, EstadoBolsa, IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Estado, EstadoDocumentos")] CandidaturaModel candidaturaModel)
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var userEmail = candidaturaModel.Email;
            var user = await _userManager.GetUserAsync(User);

            if (id != candidaturaModel.CandidaturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (InstituicaoParceiraModel i in _context.InstituicaoParceiraModel)
                    {
                        if (i.Nome == candidaturaModel.InstituicaoNome && programaAtual.Nome == i.ProgramaNome)
                        {
                            candidaturaModel.InstituicaoPais = i.Pais;
                            candidaturaModel.InstituicaoCidade = i.Cidade;
                        }
                    }

                    if (candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.Aceites))
                    {
                        new Notificacao(userEmail, "CIMOB - Estado Documentos Submetidos", "Os documentos submetidos ao Programa " + candidaturaModel.Programa + " foram: " + candidaturaModel.EstadoDocumentos);
                    }
                    if (candidaturaModel.EstadoDocumentos.Equals(EstadoDocumentos.Recusados))
                    {
                        new Notificacao(userEmail, "CIMOB - Estado Documentos Submetidos", "Os documentos submetidos ao Programa " + candidaturaModel.Programa + " foram: " + candidaturaModel.EstadoDocumentos);
                    }
                    if (candidaturaModel.Estado == EstadoCandidatura.Aceite)
                    {
                        candidaturaModel.DataFimCandidatura = DateTime.Now;
                    }
                    if(candidaturaModel.Estado == EstadoCandidatura.EmMobilidade)
                    {                      
                        user.IsMobilidade = true;
                    }
                    if (candidaturaModel.Estado == EstadoCandidatura.Finalizou)
                    {
                        user.IsMobilidade = false;
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
        public async Task<IActionResult> EditRegulamento([Bind("CandidaturaID,Programa,InstituicaoNome, InstituicaoPais, InstituicaoCidade,DataInicioCandidatura, DataFimCandidatura, Semestre, Email, EntrevistaID,Nome,NumeroInterno,IsBolsa,EstadoBolsa,IsEstudo,IsEstagio,IsInvestigacao,IsLecionar,IsFormacao,IsConfirmado,Estado")] CandidaturaModel candidaturaModel)
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



        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> Documentacao()
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;

            var infoGeral = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Documentação");
            ViewBag.InfoGeral = infoGeral;
            return View();
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
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;

            var user = await _userManager.GetUserAsync(User);
            ViewBag.Nome = user.Nome;
            ViewBag.NumeroInterno = user.NumeroInterno;

            
            List<InstituicaoParceiraModel> instituicoesProgramaAtual = new List<InstituicaoParceiraModel>();
            foreach (InstituicaoParceiraModel i in _context.InstituicaoParceiraModel)
            {
                if (i.ProgramaNome.Equals(programaAtual.Nome))
                {                 
                    instituicoesProgramaAtual.Add(i);
                }
            }
            ViewBag.Instituicoes = new SelectList(instituicoesProgramaAtual, "Nome", "Nome");



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
                if (c.Programa.Equals(programaAtual.Nome))
                {
                    candidaturaModel = c;
                }
            }

            if (candidaturaModel == null || candidaturaModel.Programa != programaAtual.Nome)
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
                    return RedirectToAction(nameof(RegulamentoMob));
                }
                else if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao3)
                {
                    return RedirectToAction(nameof(SubmeterDocs));
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
                    return RedirectToAction(nameof(FinalCandidatura));
                }
            }
            return NotFound();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> RegulamentoMob()
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;
            
            ViewBag.InfoGeraisModel = await _context.InformacaoGeral.SingleOrDefaultAsync(m => m.Titulo == "Regulamento");

            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);

            return View(candidaturaModel);
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> SubmeterDocs()
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;
            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);
            candidaturaModel.Estado = EstadoCandidatura.EmRealizacao3;
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();
            return View(candidaturaModel);
        }


        public async Task<Entrevista> GetEntrevista()
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);

            var user = await _userManager.GetUserAsync(User);

            foreach (Entrevista e in _context.Entrevista)
            {
                if (e.NumeroAluno == user.NumeroInterno && e.NomePrograma.Equals(programaAtual.Nome) && !e.Estado.Equals(EstadoEntrevista.Recusado))
                {
                    return e;
                }
            }
            return null;
        }


        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> MarcarEntrevistas()
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;
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
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            ViewBag.NomePrograma = programaAtual.Nome;

            var user = await _userManager.GetUserAsync(User);
            var candidaturaModel = await _context.CandidaturaModel.SingleOrDefaultAsync(m => m.CandidaturaID == user.CandidaturaAtual);

            if (candidaturaModel.Estado == EstadoCandidatura.EmRealizacao4)
            {
                candidaturaModel.Estado = EstadoCandidatura.EmEspera;
                new Notificacao(user.Email, "Candidatura Registada", "A sua candidatura no programa " + programaAtual.Nome + " foi registada com sucesso!");
            }
            _context.Update(candidaturaModel);
            await _context.SaveChangesAsync();

            return View(candidaturaModel);
        }

        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> UtilizadoresEmMob()
        {
            return View(await _context.CandidaturaModel.ToListAsync());
        }


        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> Inicio(int? id)
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);
            var roleAlunoID = (await _context.Roles.SingleOrDefaultAsync(m => m.Name.Equals("Aluno"))).Id;
            var roleDocenteID = (await _context.Roles.SingleOrDefaultAsync(m => m.Name.Equals("Funcionário"))).Id;
            ApplicationUser utilizador = null;
            List<ApplicationUser> utilizadoresMobilidade = new List<ApplicationUser>();
            ViewBag.docentes = 0;
            ViewBag.alunos = 0;
            foreach (var c in _context.UserRoles)
            {
                foreach (CandidaturaModel a in _context.CandidaturaModel)
                {
                    if (c.RoleId.Equals(roleAlunoID))
                    {
                        utilizador = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == c.UserId);
                        if (utilizador.IsMobilidade == true && a.Programa.Equals(programaAtual.Nome))
                        {
                            if (utilizador.PartilhaMobilidade == true)
                            {
                                utilizadoresMobilidade.Add(utilizador);
                            }
                            ViewBag.alunos++;
                        }
                    }
                    else if (c.RoleId.Equals(roleDocenteID) && a.Programa.Equals(programaAtual.Nome))
                    {
                        utilizador = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == c.UserId);
                        if (utilizador.IsMobilidade == true)
                        {
                            if (utilizador.PartilhaMobilidade == true)
                            {
                                utilizadoresMobilidade.Add(utilizador);
                            }
                            ViewBag.docentes++;
                        }
                    }
                }
            }
            ViewBag.listaUserMobilidade = utilizadoresMobilidade;
            

            //foreach (ProgramaModel p in _context.ProgramaModel)
            //{
            //    p.ProgramaAtual = false;            
            //} 
            //programaAtual.ProgramaAtual = true;

            ViewBag.NomePrograma = programaAtual.Nome;
            //_context.Update(programaAtual);
            //await _context.SaveChangesAsync();

            return View(await _context.CandidaturaModel.ToListAsync());
        }


        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> HistoricoCandidaturas(int? id)
        {
            var user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.NumeroInterno == id);
            ViewBag.UserName = user.Nome;
            ViewBag.NumeroInterno = id;

            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                if (c.NumeroInterno==id)
                {
                    candidaturasUser.Add(c);
                }
            }
            return View(candidaturasUser);
        }



        public Boolean verificarUtilizador(int numero, List<CandidaturaModel> candidaturasUser)
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
        public IActionResult UtilizadoresComCandidaturas()
        {
            List<CandidaturaModel> candidaturasUser = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                if (!verificarUtilizador(c.NumeroInterno, candidaturasUser))
                {
                    candidaturasUser.Add(c);
                }
            }
            return View(candidaturasUser);
        }
    }
}
