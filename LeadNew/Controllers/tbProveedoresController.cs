using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadNew.Models;

namespace LeadNew.Controllers
{
    public class tbProveedoresController : Controller
    {
        private readonly LeadNewDB _context;

        public tbProveedoresController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbProveedores
        public ActionResult Index()
        {
            ProveedoresVista[] ProveedoresVista = null;
            var pvdrs = (from p in _context.tbProveedores
                         join tp in _context.tbTipoProveedores
                         on p.pvIdTipo equals tp.tpId
                         select new
                         {

                             pvId = p.pvId,
                             pvNombre = p.pvNombre,
                             pvTelefono = p.pvTelefono,
                             pvCorreo = p.pvCorreo,
                             pvDireccion = p.pvDireccion,
                             pvDescripcion = p.pvDescripcion,
                             pvFechaCreacion = p.pvFechaCreacion,
                             pvIdTipo = p.pvIdTipo,
                             pvSitioWeb = p.pvSitioWeb,
                             pvImg = p.pvImg,
                             tpDescripcion = tp.tpDescripcion
                         }).ToList();

            var list = new List<ProveedoresVista>();

            foreach (var i in pvdrs)
            {
                list.Add(new ProveedoresVista
                {
                    pvId = i.pvId,
                    pvNombre = i.pvNombre,
                    pvTelefono = i.pvTelefono,
                    pvCorreo = i.pvCorreo,
                    pvDireccion = i.pvDireccion,
                    pvDescripcion = i.pvDescripcion,
                    pvFechaCreacion = i.pvFechaCreacion,
                    pvIdTipo = i.pvIdTipo,
                    pvSitioWeb = i.pvSitioWeb,
                    pvImg = i.pvImg,
                    tpDescripcion = i.tpDescripcion
                });
            }

            ProveedoresVista = list.ToArray();

            ViewData["tbProveedores"] = ProveedoresVista.ToList();
            return View();
        }

        // GET: tbProveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tbProveedores = _context.tbProveedores.FirstOrDefault(m => m.pvId == id);

            ProveedoresVista[] ProveedoresVista = null;
            var pvdrs = (from p in _context.tbProveedores
                         join tp in _context.tbTipoProveedores
                         on p.pvIdTipo equals tp.tpId
                         where p.pvId == id
                         select new
                         {
                             pvId = p.pvId,
                             pvNombre = p.pvNombre,
                             pvTelefono = p.pvTelefono,
                             pvCorreo = p.pvCorreo,
                             pvDireccion = p.pvDireccion,
                             pvDescripcion = p.pvDescripcion,
                             pvFechaCreacion = p.pvFechaCreacion,
                             pvIdTipo = p.pvIdTipo,
                             pvSitioWeb = p.pvSitioWeb,
                             pvImg = p.pvImg,
                             tpDescripcion = tp.tpDescripcion
                         }).ToList();

            var list = new List<ProveedoresVista>();

            foreach (var i in pvdrs)
            {
                list.Add(new ProveedoresVista
                {
                    pvId = i.pvId,
                    pvNombre = i.pvNombre,
                    pvTelefono = i.pvTelefono,
                    pvCorreo = i.pvCorreo,
                    pvDireccion = i.pvDireccion,
                    pvDescripcion = i.pvDescripcion,
                    pvFechaCreacion = i.pvFechaCreacion,
                    pvIdTipo = i.pvIdTipo,
                    pvSitioWeb = i.pvSitioWeb,
                    pvImg = i.pvImg,
                    tpDescripcion = i.tpDescripcion
                });
            }

            ProveedoresVista = list.ToArray();

            ViewData["tbProveedores"] = ProveedoresVista.ToList();

            var contactos = (from c in _context.tbContactosProveedores
                             where c.cpIdproveedor == id
                             select c).OrderByDescending(z => z.cpFechaCreacion).ToList();
            ViewData["contactos"] = contactos;
            ViewData["idproveedor"] = id;

            var notas = (from n in _context.tbNotasProveedores
                         where n.npIdproveedor == id
                         select n).OrderByDescending(z => z.npFechaCreacion).ToList();
            ViewData["notas"] = notas;
            if (ProveedoresVista == null)
            {
                return NotFound();
            }

            return View();
        }

        public ActionResult TipoProveedoresLista()
        {
            var tipos = (from mon in _context.tbTipoProveedores select new { Text = mon.tpDescripcion, Value = mon.tpId }).ToList().OrderBy(x => x.Text);
            return Json(tipos);
        }

        // GET: tbProveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CrearProveedor(string pvNombre, string pvTelefono, string pvCorreo, string pvDireccion, string pvDescripcion, int prIdTipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbProveedores tbProveedores = new tbProveedores();
                    tbProveedores = new tbProveedores();
                    tbProveedores.pvNombre = pvNombre;
                    tbProveedores.pvTelefono = pvTelefono;
                    tbProveedores.pvCorreo = pvCorreo;
                    tbProveedores.pvDireccion = pvDireccion;
                    tbProveedores.pvDescripcion = pvDescripcion;
                    tbProveedores.pvFechaCreacion = DateTime.Now;
                    tbProveedores.pvIdTipo = prIdTipo;
                    _context.tbProveedores.Add(tbProveedores);
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

        public ActionResult CrearNota(int id, string nota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbNotasProveedores tbNotasProveedores = new tbNotasProveedores();
                    tbNotasProveedores = new tbNotasProveedores();
                    tbNotasProveedores.npIdproveedor = id;
                    tbNotasProveedores.npNota = nota;
                    tbNotasProveedores.npFechaCreacion = DateTime.Now;
                    _context.tbNotasProveedores.Add(tbNotasProveedores);
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

        public ActionResult CrearContacto(string nombre, string correo, string telefono, string puesto, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbContactosProveedores tbContactosProveedores = new tbContactosProveedores();
                    tbContactosProveedores = new tbContactosProveedores();
                    tbContactosProveedores.cpNombre = nombre;
                    tbContactosProveedores.cpCorreo = correo;
                    tbContactosProveedores.cpTelefono = telefono;
                    tbContactosProveedores.cpPuesto = puesto;
                    tbContactosProveedores.cpIdproveedor = id;
                    tbContactosProveedores.cpFechaCreacion = DateTime.Now;
                    _context.tbContactosProveedores.Add(tbContactosProveedores);
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

        // GET: tbProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProveedores = await _context.tbProveedores.FindAsync(id);
            
            if (tbProveedores == null)
            {
                return NotFound();
            }
            return View(tbProveedores);
        }
        
        public ActionResult EditarProveedor(int pvid, string pvNombre, string pvTelefono, string pvCorreo, string pvDireccion, string pvDescripcion)
        {
            try
            {
                tbProveedores tbProveedores = _context.tbProveedores.Find(pvid);
                if (tbProveedores != null)
                {
                    tbProveedores.pvNombre = pvNombre;
                    tbProveedores.pvTelefono = pvTelefono;
                    tbProveedores.pvCorreo = pvCorreo;
                    tbProveedores.pvDireccion = pvDireccion;
                    tbProveedores.pvDescripcion = pvDescripcion;
                    _context.Entry(tbProveedores).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public ActionResult EditarNota(int id, string Nota)
        {
            try
            {
                tbNotasProveedores tbNotasProveedores = _context.tbNotasProveedores.Find(id);
                if (tbNotasProveedores != null)
                {
                    tbNotasProveedores.npNota = Nota;
                    _context.Entry(tbNotasProveedores).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public ActionResult EditarContacto(int id, string nombre, string telefono, string correo, string puesto)
        {
            try
            {
                tbContactosProveedores tbContactosProveedores = _context.tbContactosProveedores.Find(id);
                if (tbContactosProveedores != null)
                {
                    tbContactosProveedores.cpNombre = nombre;
                    tbContactosProveedores.cpTelefono = telefono;
                    tbContactosProveedores.cpCorreo = correo;
                    tbContactosProveedores.cpPuesto = puesto;
                    _context.Entry(tbContactosProveedores).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProveedores = await _context.tbProveedores
                .FirstOrDefaultAsync(m => m.pvId == id);
            if (tbProveedores == null)
            {
                return NotFound();
            }

            return View(tbProveedores);
        }

        // POST: tbProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbProveedores = await _context.tbProveedores.FindAsync(id);
            _context.tbProveedores.Remove(tbProveedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbProveedoresExists(int id)
        {
            return _context.tbProveedores.Any(e => e.pvId == id);
        }
    }
}
