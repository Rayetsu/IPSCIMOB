using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IPSCIMOB.Data;
using IPSCIMOB.Models;

namespace IPSCIMOB.Controllers
{
    public class EnviarMsgsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnviarMsgsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnviarMsgs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnviarMsg.ToListAsync());
        }

        // GET: EnviarMsgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviarMsg = await _context.EnviarMsg
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enviarMsg == null)
            {
                return NotFound();
            }

            return View(enviarMsg);
        }

        // GET: EnviarMsgs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnviarMsgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToEmail,EMailBody,EmailSubject")] EnviarMsg enviarMsg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enviarMsg);
                await _context.SaveChangesAsync();
                var email = enviarMsg.ToEmail;
                var subject = enviarMsg.EmailSubject;
                var body = enviarMsg.EMailBody;

                new Notificacao(email, subject, body);

                return RedirectToAction(nameof(Index));
            }

            

            return View(enviarMsg);

           
        }

        // GET: EnviarMsgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviarMsg = await _context.EnviarMsg.SingleOrDefaultAsync(m => m.Id == id);
            if (enviarMsg == null)
            {
                return NotFound();
            }
            return View(enviarMsg);
        }

        // POST: EnviarMsgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToEmail,EMailBody,EmailSubject")] EnviarMsg enviarMsg)
        {
            if (id != enviarMsg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enviarMsg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnviarMsgExists(enviarMsg.Id))
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
            return View(enviarMsg);
        }

        // GET: EnviarMsgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviarMsg = await _context.EnviarMsg
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enviarMsg == null)
            {
                return NotFound();
            }

            return View(enviarMsg);
        }

        // POST: EnviarMsgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enviarMsg = await _context.EnviarMsg.SingleOrDefaultAsync(m => m.Id == id);
            _context.EnviarMsg.Remove(enviarMsg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnviarMsgExists(int id)
        {
            return _context.EnviarMsg.Any(e => e.Id == id);
        }
    }
}
