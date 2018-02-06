using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using IPSCIMOB.Data;
using Microsoft.EntityFrameworkCore;

namespace IPSCIMOB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("Aluno"))
            {
                ViewBag.UserProfissao = UtilizadorProfissao.Aluno;
                return View("~/Views/Home/SelecionarMobilidade.cshtml", await _context.ProgramaModel.ToListAsync());
            }
            else if (this.User.IsInRole("Funcionário"))
            {
                ViewBag.UserProfissao = UtilizadorProfissao.Funcionario;
                return View("~/Views/Home/SelecionarMobilidade.cshtml", await _context.ProgramaModel.ToListAsync());
            }
            else if (this.User.IsInRole("CIMOB"))
            {
                return View("~/Views/Home/CIMOB.cshtml", await _context.ProgramaModel.ToListAsync());
            }

            DateTime semestre1 = new DateTime();
            DateTime semestre2 = new DateTime();
            foreach (ProgramaModel p in _context.ProgramaModel)
            {
                semestre1 = p.PrazoCandidaturaPrimeiroSemestre;
                semestre2 = p.PrazoCandidaturaSegundoSemestre;
                break;
            }
            TimeSpan date1Semestre = semestre1 - DateTime.Now;
            TimeSpan date2Semestre = semestre2 - DateTime.Now;
            if(date1Semestre.Days < 0)
            {
                ViewBag.Dias1Semestre = 0;
                ViewBag.Dias2Semestre = date2Semestre.Days;
            }else if(date2Semestre.Days < 0)
            {
                ViewBag.Dias1Semestre = date1Semestre.Days;
                ViewBag.Dias2Semestre = 0;
            }else if(date1Semestre.Days < 0 && date2Semestre.Days < 0)
            {
                ViewBag.Dias1Semestre = 0;
                ViewBag.Dias2Semestre = 0;
            }
            

            return View();
        }

        [Authorize(Roles = "CIMOB")]
        public IActionResult CIMOB()
        {

            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult SelecionarMobilidade()
        {

            //List<SelectListItem> items = new List<SelectListItem>();

            //items.Add(new SelectListItem { Text = "Vasco da Gama", Value = "0" });

            //items.Add(new SelectListItem { Text = "Politécnico de Macau", Value = "1" });

            //items.Add(new SelectListItem { Text = "Erasmus+", Value = "2", Selected = true });

            //items.Add(new SelectListItem { Text = "Erasmus+ Formação/Trabalho", Value = "3" });

            //items.Add(new SelectListItem { Text = "Santander Universidades", Value = "4" });

            //items.Add(new SelectListItem { Text = "Santander Missões de Ensino e Formação", Value = "5" });

            //ViewBag.TipoDeMobilidade = items;

            return View();
        }

        //public ViewResult MobilidadeEscolhida(string TipoDeMobilidade)
        //{

        //    ViewBag.messageString = TipoDeMobilidade;

        //    return View("Information");

        //}

        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult Sugestoes()
        {

            return View();
        }

        [Authorize(Roles = "Aluno, Funcionário")]
        public async Task<IActionResult> Inicio(int? id)
        {
            var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaID == id);

            foreach (ProgramaModel p in _context.ProgramaModel)
            {
                p.ProgramaAtual = false;
            }
            programaAtual.ProgramaAtual = true;

            ViewBag.NomePrograma = programaAtual.Nome;
            _context.Update(programaAtual);
            await _context.SaveChangesAsync();
            return RedirectToAction("Inicio", "Candidatura");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
