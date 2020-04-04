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
        public ActionResult Index()
        {
            TasaCambioVista[] TasaCambios = null;
            var moneda = (from tc in _context.tbTasaCambio
                          join m in _context.tbMoneda
                          on tc.tcIdMoneda equals m.moId
                          select new
                          {
                              id = tc.id,
                              tcDescripcion = tc.tcDescripcion,
                              tcFechaIngreso = tc.tcFechaIngreso,
                              tcEstado = tc.tcEstado,
                              tcValor = tc.tcValor,
                              tcIdMoneda = tc.tcIdMoneda,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre
                          }).ToList();
            var list = new List<TasaCambioVista>();

            foreach (var i in moneda)
            {
                list.Add(new TasaCambioVista
                {
                    id = i.id,
                    tcDescripcion = i.tcDescripcion,
                    tcFechaIngreso = i.tcFechaIngreso,
                    tcEstado = i.tcEstado,
                    tcValor = i.tcValor,
                    tcIdMoneda = i.tcIdMoneda,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre
                });
            }
            TasaCambios = list.ToArray();

            ViewData["TasaCambios"] = TasaCambios.ToList();

            return View();
        }

        // GET: tbTasaCambios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tbTasaCambio = _context.tbTasaCambio
            //    .FirstOrDefaultAsync(m => m.id == id);
            //if (tbTasaCambio == null)
            //{
            //    return NotFound();
            //}

            TasaCambioVista[] TasaCambios = null;
            var moneda = (from tc in _context.tbTasaCambio
                          join m in _context.tbMoneda
                          on tc.tcIdMoneda equals m.moId
                          where tc.id == id
                          select new
                          {
                              id = tc.id,
                              tcDescripcion = tc.tcDescripcion,
                              tcFechaIngreso = tc.tcFechaIngreso,
                              tcEstado = tc.tcEstado,
                              tcValor = tc.tcValor,
                              tcIdMoneda = tc.tcIdMoneda,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre
                          }).ToList();
            var list = new List<TasaCambioVista>();

            foreach (var i in moneda)
            {
                list.Add(new TasaCambioVista
                {
                    id = i.id,
                    tcDescripcion = i.tcDescripcion,
                    tcFechaIngreso = i.tcFechaIngreso,
                    tcEstado = i.tcEstado,
                    tcValor = i.tcValor,
                    tcIdMoneda = i.tcIdMoneda,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre
                });
            }
            TasaCambios = list.ToArray();

            ViewData["TasaCambios"] = TasaCambios.ToList();

            return View();
        }

        // GET: tbTasaCambios/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearTasa(string descripcion, decimal valor, int moneda)
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
                    tbTasaCambio.tcIdMoneda = moneda;
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

        public ActionResult MonedaLista()
        {
            var monedas = (from mon in _context.tbMoneda select new { Text = mon.moNombre, Value = mon.moId }).ToList().OrderBy(x => x.Text);
            return Json(monedas);
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

        public ActionResult EditarTasa(int id, string descripcion, decimal valor, int moneda)
        {
            try
            {
                tbTasaCambio tbTasaCambio = _context.tbTasaCambio.Find(id);
                if (tbTasaCambio != null)
                {
                    tbTasaCambio.tcDescripcion = descripcion;
                    tbTasaCambio.tcValor = valor;
                    tbTasaCambio.tcIdMoneda = moneda;
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
