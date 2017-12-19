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

        /**
         * @return view
         * define para cada utilizador a pagina home
         */
        public IActionResult Index()
        {
            /*if (!this.User.Identity.IsAuthenticated)
            {
                return View();
                //Layout = "_Layout";
            }*/
            if (this.User.IsInRole("Aluno") || this.User.IsInRole("Funcionário"))
            {
                return View("~/Views/Home/SelecionarMobilidade.cshtml");
                //Layout = "_LayoutAluno";
            }
            else if (this.User.IsInRole("CIMOB"))
            {
                return View("~/Views/Home/CIMOB.cshtml");
                //Layout = "_LayoutCIMOB";
            }

            return View();
        }

        /**
         * @return view CIMOB que so o CIMOB é que tem autorização
         * 
         */
        [Authorize(Roles = "CIMOB")]
        public IActionResult CIMOB()
        {

            return View();
        }

        /**
         * @return view SelecionarMobilidade que só os Alunos e Funcionários é que têm acesso
         */
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

        /**
         * @return view Sugestão que só os Alunos e Funcionários é que têm acesso
         */
        [Authorize(Roles = "Aluno, Funcionário")]
        public IActionResult Sugestoes()
        {

            return View();
        }

        /**
         * @return view VascoDaGama que só os Alunos é que têm acesso
         */
        [Authorize(Roles = "Aluno")]
        public IActionResult VascoDaGama()
        {

            return View();
        }

        /**
         * @return view PolitecnicoDeMacau que só os Alunos é que têm acesso
         */
        [Authorize(Roles = "Aluno")]
        public IActionResult PolitecnicoDeMacau()
        {

            return View();
        }

        /**
         * @return view Erasmus que só os Alunos é que têm acesso
         */
        [Authorize(Roles = "Aluno")]
        public IActionResult Erasmus()
        {

            return View();
        }

        /**
         * @return view ErasmusFormacaoTrabalho que só os Funcionarios é que têm acesso
         */
        [Authorize(Roles = "Funcionário")]
        public IActionResult ErasmusFormacaoTrabalho()
        {

            return View();
        }

        /**
         * @return view SantanderUniversidades que só os Alunos é que têm acesso
         */
        [Authorize(Roles = "Aluno")]
        public IActionResult SantanderUniversidades()
        {

            return View();
        }

        /**
         * @return view SantanderMissoes que só os Funcionarios é que têm acesso
         */
        [Authorize(Roles ="Funcionário")]
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
