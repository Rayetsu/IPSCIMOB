using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPSCIMOB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult CIMOB()
        {

            return View();
        }

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

        public IActionResult VascoDaGama()
        {

            return View();
        }

        public IActionResult PolitecnicoDeMacau()
        {

            return View();
        }

        public IActionResult Erasmus()
        {

            return View();
        }

        public IActionResult ErasmusFormacaoTrabalho()
        {

            return View();
        }

        public IActionResult SantanderUniversidades()
        {

            return View();
        }

        public IActionResult SantanderMissoes()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
