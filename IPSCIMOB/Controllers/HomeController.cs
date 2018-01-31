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
