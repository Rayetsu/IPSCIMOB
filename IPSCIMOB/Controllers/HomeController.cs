using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Authorization;

namespace IPSCIMOB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SobreCIMOB()
        {
            return View();
        }

        [Authorize]
        public IActionResult BolsaDeEstudos()
        {
            //ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ProgramaVascoDaGama()
        {

            return View();
        }

        public IActionResult ProgramaPolitecnicoDeMacau()
        {

            return View();
        }

        public IActionResult ProgramaErasmus()
        {

            return View();
        }

        public IActionResult ProgramaSantanderUniversidades()
        {

            return View();
        }

        public IActionResult ProgramaSantanderMissoes()
        {

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
