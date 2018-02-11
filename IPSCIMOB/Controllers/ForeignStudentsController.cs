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

namespace IPSCIMOB.Controllers
{
    public class ForeignStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForeignStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForeignStudents
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForeignStudent.ToListAsync());
        }

        // GET: ForeignStudents/Details/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foreignStudents = await _context.ForeignStudent
                .SingleOrDefaultAsync(m => m.Id == id);
            if (foreignStudents == null)
            {
                return NotFound();
            }

            return View(foreignStudents);
        }

        // GET: ForeignStudents/Create
        [Authorize(Roles = "CIMOB")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForeignStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nacionalidade,Email,DataDeNascimento,EscolaIPSECurso,Morada,NumeroDaPorta,Andar,Cidade,Distrito,CodigoPostal,Universidade,Telefone,IsBolseiro,PartilhaMobilidade,IsFuncionario,IsDadosVerificados")] ForeignStudents foreignStudents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foreignStudents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foreignStudents);
        }

        // GET: ForeignStudents/Edit/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foreignStudents = await _context.ForeignStudent.SingleOrDefaultAsync(m => m.Id == id);
            if (foreignStudents == null)
            {
                return NotFound();
            }
            return View(foreignStudents);
        }

        // POST: ForeignStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nacionalidade,Email,DataDeNascimento,EscolaIPSECurso,Morada,NumeroDaPorta,Andar,Cidade,Distrito,CodigoPostal,Universidade,Telefone,IsBolseiro,PartilhaMobilidade,IsFuncionario,IsDadosVerificados")] ForeignStudents foreignStudents)
        {
            if (id != foreignStudents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foreignStudents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForeignStudentsExists(foreignStudents.Id))
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
            return View(foreignStudents);
        }

        // GET: ForeignStudents/Delete/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foreignStudents = await _context.ForeignStudent
                .SingleOrDefaultAsync(m => m.Id == id);
            if (foreignStudents == null)
            {
                return NotFound();
            }

            return View(foreignStudents);
        }

        // POST: ForeignStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foreignStudents = await _context.ForeignStudent.SingleOrDefaultAsync(m => m.Id == id);
            _context.ForeignStudent.Remove(foreignStudents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForeignStudentsExists(int id)
        {
            return _context.ForeignStudent.Any(e => e.Id == id);
        }
    }
}
