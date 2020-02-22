using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadNew.Models;

namespace LeadNew
{
    public class tbTasaCambiosController : Controller
    {
        private readonly LeadNewDB _context;

        public tbTasaCambiosController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbTasaCambios
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbTasaCambio.ToListAsync());
        }

        // GET: tbTasaCambios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTasaCambio = await _context.tbTasaCambio
                .FirstOrDefaultAsync(m => m.id == id);
            if (tbTasaCambio == null)
            {
                return NotFound();
            }

            return View(tbTasaCambio);
        }

        // GET: tbTasaCambios/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearTasa(string descripcion, decimal valor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbTasaCambio tbTasaCambio = new tbTasaCambio();
                    tbTasaCambio = new tbTasaCambio();
                    tbTasaCambio.tcDescripcion = descripcion;
                    tbTasaCambio.tcValor = valor;
                    tbTasaCambio.tcEstado = 1;
                    tbTasaCambio.tcFechaIngreso = DateTime.Now;
                    _context.tbTasaCambio.Add(tbTasaCambio);
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

        // GET: tbTasaCambios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTasaCambio = await _context.tbTasaCambio.FindAsync(id);
            if (tbTasaCambio == null)
            {
                return NotFound();
            }
            return View(tbTasaCambio);
        }

        public ActionResult EditarTasa(int id, string descripcion, decimal valor)
        {
            try
            {
                tbTasaCambio tbTasaCambio = _context.tbTasaCambio.Find(id);
                if (tbTasaCambio != null)
                {
                    tbTasaCambio.tcDescripcion = descripcion;
                    tbTasaCambio.tcValor = valor;
                    _context.Entry(tbTasaCambio).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbTasaCambios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTasaCambio = await _context.tbTasaCambio
                .FirstOrDefaultAsync(m => m.id == id);
            if (tbTasaCambio == null)
            {
                return NotFound();
            }

            return View(tbTasaCambio);
        }

        // POST: tbTasaCambios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTasaCambio = await _context.tbTasaCambio.FindAsync(id);
            _context.tbTasaCambio.Remove(tbTasaCambio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbTasaCambioExists(int id)
        {
            return _context.tbTasaCambio.Any(e => e.id == id);
        }
    }
}
