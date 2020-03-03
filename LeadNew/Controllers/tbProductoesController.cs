using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadNew.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace LeadNew
{
    public class tbProductoesController : Controller
    {
        private readonly LeadNewDB _context;

        public tbProductoesController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbProductoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbProducto.ToListAsync());
        }

        public ActionResult MonedaLista()
        {
            var monedas = (from mon in _context.tbMoneda select new { Text = mon.moNombre, Value = mon.moId }).ToList().OrderBy(x => x.Text);
            return Json(monedas);
        }

        public ActionResult SucursalesLista()
        {
            var sucursales = (from suc in _context.tbSucursales select new { Text = suc.sucNombre, Value = suc.sucId }).ToList().OrderBy(x => x.Text);
            return Json(sucursales);
        }

        // GET: tbProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProducto = await _context.tbProducto
                .FirstOrDefaultAsync(m => m.prId == id);
            if (tbProducto == null)
            {
                return NotFound();
            }

            return View(tbProducto);
        }

        // GET: tbProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearProducto(string prIdInterno, string prDetalle, int prCantidad, decimal prPrecioCosto, decimal prPrecioVenta, int prMoneda, int prIdSucursal, IFormFile img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var codigos = _context.tbProducto.Select(x => x.prIdInterno).ToArray();
                    foreach (var c in codigos)
                    {
                        if (c == prIdInterno)
                        {
                            return Json("Existe");
                        }
                    }

                    byte[] p1 = null;
                    using (var fs1 = img.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }                    

                    tbProducto tbProducto = new tbProducto();
                    tbProducto = new tbProducto();
                    tbProducto.prIdInterno = prIdInterno;
                    tbProducto.prDetalle = prDetalle;
                    tbProducto.prCantidad = prCantidad;
                    tbProducto.prPrecioCosto = prPrecioCosto;
                    tbProducto.prPrecioVenta = prPrecioVenta;
                    tbProducto.prMoneda = prMoneda;
                    tbProducto.prIdSucursal = prIdSucursal;
                    tbProducto.prFechaIngreso = DateTime.Now;
                    tbProducto.prUsuario = "6";
                    tbProducto.prEstado = 1;
                    tbProducto.prImagen = p1;
                    _context.tbProducto.Add(tbProducto);
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

        // GET: tbProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProducto = await _context.tbProducto.FindAsync(id);
            if (tbProducto == null)
            {
                return NotFound();
            }
            return View(tbProducto);
        }

        public ActionResult EditarProducto(int id, string prIdInterno, string prDetalle, int prCantidad, decimal prPrecioCosto, decimal prPrecioVenta, int prMoneda, int prIdSucursal)
        {
            try
            {
                tbProducto tbProducto = _context.tbProducto.Find(id);
                if (tbProducto != null)
                {
                    tbProducto.prIdInterno = prIdInterno;
                    tbProducto.prDetalle = prDetalle;
                    tbProducto.prCantidad = prCantidad;
                    tbProducto.prPrecioCosto = prPrecioCosto;
                    tbProducto.prPrecioVenta = prPrecioVenta;
                    tbProducto.prMoneda = prMoneda;
                    tbProducto.prIdSucursal = prIdSucursal;
                    _context.Entry(tbProducto).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProducto = await _context.tbProducto
                .FirstOrDefaultAsync(m => m.prId == id);
            if (tbProducto == null)
            {
                return NotFound();
            }

            return View(tbProducto);
        }

        // POST: tbProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbProducto = await _context.tbProducto.FindAsync(id);
            _context.tbProducto.Remove(tbProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbProductoExists(int id)
        {
            return _context.tbProducto.Any(e => e.prId == id);
        }
    }
}
