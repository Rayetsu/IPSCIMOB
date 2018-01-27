using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;
using IPSCIMOB.Models.Upload;
using IPSCIMOB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using IPSCIMOB.Data;
using Microsoft.EntityFrameworkCore;

namespace IPSCIMOB.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileProvider fileProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private ApplicationDbContext _context;


        public UploadController(IFileProvider fileProvider, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            this.fileProvider = fileProvider;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{


        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                 _hostingEnvironment.WebRootPath, "Documentos",
        //                file.GetFilename());

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    var user = await _userManager.GetUserAsync(User);

        //    var email = user.Email;
        //    var numeroAluno = user.NumeroInterno;
        //    var nomeDoFicheiro = file.GetFilename();

        //    new Notificacao(email, "Documentos à espera de aprovação", "Documentos enviados com sucesso e à espera de aprovação");

        //    _context.AlunoDocumento.Add(new AlunoDocumentos { NumeroAluno = numeroAluno, Documento = nomeDoFicheiro, Caminho = path });

        //    _context.SaveChanges();

        //    return RedirectToAction("Index");

        //}

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return Content("files not selected");

            foreach (var file in files)
            {
                var path = Path.Combine(
                         _hostingEnvironment.WebRootPath, "Documentos",
                        file.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var user = await _userManager.GetUserAsync(User);
                var programaAtual = await _context.ProgramaModel.SingleOrDefaultAsync(m => m.ProgramaAtual == true);

                var email = user.Email;
                var numeroAluno = user.NumeroInterno;
                var nomeDoFicheiro = file.GetFilename();
                var nomePrograma = programaAtual.Nome;

                _context.AlunoDocumento.Add(new AlunoDocumentos { NumeroAluno = numeroAluno, Documento = nomeDoFicheiro, Caminho = nomeDoFicheiro, Programa = nomePrograma});

                _context.SaveChanges();

                new Notificacao(email, "Documentos à espera de aprovação", "Documentos enviados com sucesso e à espera de aprovação");
            }
            return RedirectToAction("SubmeterDocs", "Candidatura");
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFileViaModel(FileInputModel model)
        //{
        //    if (model == null ||
        //        model.FileToUpload == null || model.FileToUpload.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot",
        //                model.FileToUpload.GetFilename());

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await model.FileToUpload.CopyToAsync(stream);
        //    }

        //    var user = await _userManager.GetUserAsync(User);

        //    var email = user.Email;
        //    var numeroAluno = user.NumeroInterno;
        //    var nomeDoFicheiro = model.FileToUpload.GetFilename();

        //    new Notificacao(email, "Documentos à espera de aprovação", "Documentos enviados com sucesso e à espera de aprovação");

        //    var insert = new AlunoDocumentos { NumeroAluno = numeroAluno, Documento = nomeDoFicheiro, Caminho=path};


        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> Files()
        {
            /*var model = new FilesViewModel();
            foreach (var item in this.fileProvider.GetDirectoryContents("wwwroot/Documentos"))
            {
                model.Files.Add(
                    new FileDetails { Name = item.Name, Path = item.PhysicalPath});
            }*/

            List<CandidaturaModel> candidaturasExistentes = new List<CandidaturaModel>();
            foreach (CandidaturaModel c in _context.CandidaturaModel)
            {
                candidaturasExistentes.Add(c);
            }

            List<AlunoDocumentos> alunosComDocumentos = new List<AlunoDocumentos>();
            foreach (AlunoDocumentos a in _context.AlunoDocumento)
            {
                alunosComDocumentos.Add(a);
            }


            ViewBag.candidaturas = candidaturasExistentes;
            ViewBag.alunosDocumento = alunosComDocumentos;

            return View();
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                         _hostingEnvironment.WebRootPath, "Documentos", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}