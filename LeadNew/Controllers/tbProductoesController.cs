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
        public ActionResult Index()
        {
            ProductosVista[] producto = null;
            var product = (from p in _context.tbProducto
                           join m in _context.tbMoneda
                           on p.prMoneda equals m.moId
                           join s in _context.tbSucursales
                           on p.prIdSucursal equals s.sucId
                           join c in _context.tbCategoriaProducto
                           on p.prIdCategoria equals c.catId
                           join i in _context.tbImpuesto
                           on p.prIdImpuesto equals i.impId
                           join pro in _context.tbProveedores
                           on p.prIdProveedor equals pro.pvId
                           select new
                           {
                               prId = p.prId,
                               prIdInterno = p.prIdInterno,
                               prDetalle = p.prDetalle,
                               prCantidad = p.prCantidad,
                               prPrecioCosto = p.prPrecioCosto,
                               prPrecioVenta = p.prPrecioVenta,
                               prMoneda = p.prMoneda,
                               prEstado = p.prEstado,
                               prFechaIngreso = p.prFechaIngreso,
                               prUsuario = p.prUsuario,
                               prIdSucursal = p.prIdSucursal,
                               prImagen = p.prImagen,
                               prIdImpuesto = p.prIdImpuesto,
                               prIdProveedor = p.prIdProveedor,
                               prIdCategoria = p.prIdCategoria,
                               moAbreviatura = m.moAbreviatura,
                               moNombre = m.moNombre,
                               sucNombre = s.sucNombre,
                               catNombre = c.catNombre,
                               impPorcentaje = i.impPorcentaje,
                               pvNombre = pro.pvNombre
                           }).ToList();
            var list = new List<ProductosVista>();

            foreach (var i in product)
            {
                list.Add(new ProductosVista
                {
                    prId = i.prId,
                    prIdInterno = i.prIdInterno,
                    prDetalle = i.prDetalle,
                    prCantidad = i.prCantidad,
                    prPrecioCosto = i.prPrecioCosto,
                    prPrecioVenta = i.prPrecioVenta,
                    prMoneda = i.prMoneda,
                    prEstado = i.prEstado,
                    prFechaIngreso = i.prFechaIngreso,
                    prUsuario = i.prUsuario,
                    prIdSucursal = i.prIdSucursal,
                    prImagen = i.prImagen,
                    prIdImpuesto = i.prIdImpuesto,
                    prIdProveedor = i.prIdProveedor,
                    prIdCategoria = i.prIdCategoria,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    sucNombre = i.sucNombre,
                    catNombre = i.catNombre,
                    impPorcentaje = i.impPorcentaje,
                    pvNombre = i.pvNombre
                });
            }

            producto = list.ToArray();

            ViewData["Productos"] = producto.ToList();

            return View();
        }

        public ActionResult MonedaLista()
        {
            var monedas = (from mon in _context.tbMoneda select new { Text = mon.moNombre, Value = mon.moId }).ToList().OrderBy(x => x.Text);
            return Json(monedas);
        }

        public ActionResult ProveedorLista()
        {
            var proveedor = (from mon in _context.tbProveedores select new { Text = mon.pvNombre, Value = mon.pvId }).ToList().OrderBy(x => x.Text);
            return Json(proveedor);
        }

        public ActionResult ImpuestoLista()
        {
            var impuesto = (from mon in _context.tbImpuesto select new { Text = mon.impPorcentaje, Value = mon.impId }).ToList().OrderBy(x => x.Text);
            return Json(impuesto);
        }

        public ActionResult SucursalesLista()
        {
            var sucursales = (from suc in _context.tbSucursales select new { Text = suc.sucNombre, Value = suc.sucId }).ToList().OrderBy(x => x.Text);
            return Json(sucursales);
        }

        public ActionResult CategoriaLista()
        {
            var categoria = (from suc in _context.tbCategoriaProducto select new { Text = suc.catNombre, Value = suc.catId }).ToList().OrderBy(x => x.Text);
            return Json(categoria);
        }

        // GET: tbProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductosVista[] producto = null;
            var product = (from p in _context.tbProducto
                           join m in _context.tbMoneda
                           on p.prMoneda equals m.moId
                           join s in _context.tbSucursales
                           on p.prIdSucursal equals s.sucId
                           join c in _context.tbCategoriaProducto
                           on p.prIdCategoria equals c.catId
                           join i in _context.tbImpuesto
                           on p.prIdImpuesto equals i.impId
                           join pro in _context.tbProveedores
                           on p.prIdProveedor equals pro.pvId
                           where p.prId == id
                           select new
                           {
                               prId = p.prId,
                               prIdInterno = p.prIdInterno,
                               prDetalle = p.prDetalle,
                               prCantidad = p.prCantidad,
                               prPrecioCosto = p.prPrecioCosto,
                               prPrecioVenta = p.prPrecioVenta,
                               prMoneda = p.prMoneda,
                               prEstado = p.prEstado,
                               prFechaIngreso = p.prFechaIngreso,
                               prUsuario = p.prUsuario,
                               prIdSucursal = p.prIdSucursal,
                               prImagen = p.prImagen,
                               prIdImpuesto = p.prIdImpuesto,
                               prIdProveedor = p.prIdProveedor,
                               prIdCategoria = p.prIdCategoria,
                               moAbreviatura = m.moAbreviatura,
                               moNombre = m.moNombre,
                               sucNombre = s.sucNombre,
                               catNombre = c.catNombre,
                               impPorcentaje = i.impPorcentaje,
                               pvNombre = pro.pvNombre
                           }).ToList();
            var list = new List<ProductosVista>();

            foreach (var i in product)
            {
                list.Add(new ProductosVista
                {
                    prId = i.prId,
                    prIdInterno = i.prIdInterno,
                    prDetalle = i.prDetalle,
                    prCantidad = i.prCantidad,
                    prPrecioCosto = i.prPrecioCosto,
                    prPrecioVenta = i.prPrecioVenta,
                    prMoneda = i.prMoneda,
                    prEstado = i.prEstado,
                    prFechaIngreso = i.prFechaIngreso,
                    prUsuario = i.prUsuario,
                    prIdSucursal = i.prIdSucursal,
                    prImagen = i.prImagen,
                    prIdImpuesto = i.prIdImpuesto,
                    prIdProveedor = i.prIdProveedor,
                    prIdCategoria = i.prIdCategoria,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    sucNombre = i.sucNombre,
                    catNombre = i.catNombre,
                    impPorcentaje = i.impPorcentaje,
                    pvNombre = i.pvNombre
                });
            }

            producto = list.ToArray();

            ViewData["Productos"] = producto.ToList();

            return View();
        }

        // GET: tbProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearProducto(string prIdInterno, string prDetalle, int prCantidad, decimal prPrecioCosto, decimal prPrecioVenta, int prMoneda, int prIdSucursal, IFormFile img, int prIdProveedor, int prIdImpuesto, int prCategoria)
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
                    tbProducto.prIdProveedor = prIdProveedor;
                    tbProducto.prIdImpuesto = prIdImpuesto;
                    tbProducto.prIdCategoria = prCategoria;
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

            //categorias
            var idcategoria = _context.tbProducto.Where(x => x.prId == id).Select(x => x.prIdCategoria).Single();
            var SelectCategoria = _context.tbCategoriaProducto.Where(x => x.catId == idcategoria).ToList();
            ViewData["SelectCategoria"] = SelectCategoria;
            var AllCategoria = _context.tbCategoriaProducto.Where(x => x.catId != idcategoria).ToList();
            ViewData["AllCategoria"] = AllCategoria;

            //monedas
            var idmoneda = _context.tbProducto.Where(x => x.prId == id).Select(x => x.prMoneda).Single();
            var SelectMoneda = _context.tbMoneda.Where(x => x.moId == idmoneda).ToList();
            ViewData["SelectMoneda"] = SelectMoneda;
            var AllMoneda = _context.tbMoneda.Where(x => x.moId != idmoneda).ToList();
            ViewData["AllMoneda"] = AllMoneda;

            //proveedor
            var idproveedor = _context.tbProducto.Where(x => x.prId == id).Select(x => x.prIdProveedor).Single();
            var SelectProveedor = _context.tbProveedores.Where(x => x.pvId == idproveedor).ToList();
            ViewData["SelectProveedor"] = SelectProveedor;
            var AllProveedor = _context.tbProveedores.Where(x => x.pvId != idproveedor).ToList();
            ViewData["AllProveedor"] = AllProveedor;

            //impuestos
            var idimpuestos = _context.tbProducto.Where(x => x.prId == id).Select(x => x.prIdImpuesto).Single();
            var SelectImpuesto = _context.tbImpuesto.Where(x => x.impId == idimpuestos).ToList();
            ViewData["SelectImpuesto"] = SelectImpuesto;
            var AllImpuesto = _context.tbImpuesto.Where(x => x.impId != idimpuestos).ToList();
            ViewData["AllImpuesto"] = AllImpuesto;

            //sucursales
            var idsucursal = _context.tbProducto.Where(x => x.prId == id).Select(x => x.prIdSucursal).Single();
            var SelectSucursal = _context.tbSucursales.Where(x => x.sucId == idsucursal).ToList();
            ViewData["SelectSucursal"] = SelectSucursal;
            var AllSucursal = _context.tbSucursales.Where(x => x.sucId != idsucursal).ToList();
            ViewData["AllSucursal"] = AllSucursal;

            if (tbProducto == null)
            {
                return NotFound();
            }
            return View(tbProducto);
        }

        public ActionResult EditarProducto(int id, string prIdInterno, string prDetalle, int prCantidad, decimal prPrecioCosto, decimal prPrecioVenta, int prMoneda, int prIdSucursal, int prIdProveedor, int prIdImpuesto)
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
                    tbProducto.prIdProveedor = prIdProveedor;
                    tbProducto.prIdImpuesto = prIdImpuesto;
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
