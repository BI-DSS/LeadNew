using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeadNew.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadNew
{
    public class tbAperturaCajaController : Controller
    {

        private readonly LeadNewDB _context;

        public tbAperturaCajaController(LeadNewDB context)
        {
            _context = context;
        }


        // GET: tbAperturaCaja
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbAperturaCajas.ToListAsync());
        }

        // GET: tbAperturaCaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAperturaCaja = await _context.tbAperturaCajas
                .FirstOrDefaultAsync(m => m.acId == id);
            if (tbAperturaCaja == null)
            {
                return NotFound();
            }

            return View(tbAperturaCaja);
        }

        // GET: tbAperturaCaja/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CrearApertura(decimal acValorApertura, int acEstado, int acIdUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbAperturaCaja tbAperturaCaja = new tbAperturaCaja();
                    tbAperturaCaja = new tbAperturaCaja();
                    tbAperturaCaja.acValorApertura = acValorApertura;
                    tbAperturaCaja.acEstado = acEstado;
                    tbAperturaCaja.acIdUsuario = acIdUsuario;
                    tbAperturaCaja.acFechaApertura = DateTime.Now;
                    _context.tbAperturaCajas.Add(tbAperturaCaja);
                    _context.SaveChanges();

                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbAperturaCaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbAperturaCaja = await _context.tbAperturaCajas.FindAsync(id);
            if (tbAperturaCaja == null)
            {
                return NotFound();
            }

            return View(tbAperturaCaja);
        }

        public ActionResult EditarApertura(int id, decimal acValorApertura, int acEstado, int acIdUsuario)
        {
            try
            {
                tbAperturaCaja tbAperturaCaja = _context.tbAperturaCajas.Find(id);
                if (tbAperturaCaja != null)
                {
                    tbAperturaCaja.acValorApertura = acValorApertura;
                    tbAperturaCaja.acEstado = acEstado;
                    tbAperturaCaja.acIdUsuario = acIdUsuario;
                    _context.Entry(tbAperturaCaja).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbAperturaCaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAperturaCaja = await _context.tbAperturaCajas
                .FirstOrDefaultAsync(m => m.acId == id);
            if (tbAperturaCaja == null)
            {
                return NotFound();
            }
            return View(tbAperturaCaja);
        }

        // POST: tbAperturaCaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAperturaCaja = await _context.tbAperturaCajas.FindAsync(id);
            _context.tbAperturaCajas.Remove(tbAperturaCaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbAperturacaja(int id)
        {
            return _context.tbAperturaCajas.Any(e => e.acId == id);
        }
    }
}