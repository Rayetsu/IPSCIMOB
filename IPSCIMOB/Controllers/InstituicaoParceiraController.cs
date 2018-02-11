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
    public class InstituicaoParceiraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstituicaoParceiraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstituicaoParceira
        public async Task<IActionResult> Index()
        {
            return View(await _context.InstituicaoParceiraModel.ToListAsync());
        }

        // GET: InstituicaoParceira/Details/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicaoParceiraModel = await _context.InstituicaoParceiraModel
                .SingleOrDefaultAsync(m => m.InstituicaoParceiraID == id);
            if (instituicaoParceiraModel == null)
            {
                return NotFound();
            }

            return View(instituicaoParceiraModel);
        }

        // GET: InstituicaoParceira/Create
        [Authorize(Roles = "CIMOB")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoParceira/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Create([Bind("InstituicaoParceiraID,Nome,Pais,Cidade,ProgramaNome")] InstituicaoParceiraModel instituicaoParceiraModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicaoParceiraModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicaoParceiraModel);
        }

        // GET: InstituicaoParceira/Edit/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicaoParceiraModel = await _context.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == id);
            if (instituicaoParceiraModel == null)
            {
                return NotFound();
            }
            return View(instituicaoParceiraModel);
        }

        // POST: InstituicaoParceira/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Edit(int id, [Bind("InstituicaoParceiraID,Nome,Pais,Cidade, ProgramaNome")] InstituicaoParceiraModel instituicaoParceiraModel)
        {
            if (id != instituicaoParceiraModel.InstituicaoParceiraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicaoParceiraModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoParceiraModelExists(instituicaoParceiraModel.InstituicaoParceiraID))
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
            return View(instituicaoParceiraModel);
        }

        // GET: InstituicaoParceira/Delete/5
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicaoParceiraModel = await _context.InstituicaoParceiraModel
                .SingleOrDefaultAsync(m => m.InstituicaoParceiraID == id);
            if (instituicaoParceiraModel == null)
            {
                return NotFound();
            }

            return View(instituicaoParceiraModel);
        }

        // POST: InstituicaoParceira/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CIMOB")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicaoParceiraModel = await _context.InstituicaoParceiraModel.SingleOrDefaultAsync(m => m.InstituicaoParceiraID == id);
            _context.InstituicaoParceiraModel.Remove(instituicaoParceiraModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicaoParceiraModelExists(int id)
        {
            return _context.InstituicaoParceiraModel.Any(e => e.InstituicaoParceiraID == id);
        }
    }
}
