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
    public class tbMonedasController : Controller
    {
        private readonly LeadNewDB _context;

        public tbMonedasController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbMonedas
        public ActionResult Index()
        {
            MonedaVista[] monedas = null;
            var moneda = (from m in _context.tbMoneda
                          join u in _context.tbUsuarios
                          on m.moUsuarioCrea equals u.usuId
                          into leftUsuCrea from u in leftUsuCrea.DefaultIfEmpty()
                          join u2 in _context.tbUsuarios
                          on m.moUsuarioModifica equals u2.usuId
                          into leftUsuMod from u2 in leftUsuMod.DefaultIfEmpty()
                          select new
                          {
                              moId = m.moId,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre,
                              moUsuarioCrea = m.moUsuarioCrea,
                              moFechaCrea = m.moFechaCrea,
                              moUsuarioModifica = m.moUsuarioModifica,
                              moFechaModifica = m.moFechaModifica,
                              usuNombres = u.usuNombres,
                              usuApellidos = u.usuApellidos,
                              usuNombresMod = u2.usuNombres,
                              usuApellidosMod = u2.usuApellidos
                          }).ToList();
            var list = new List<MonedaVista>();

            foreach (var i in moneda)
            {
                list.Add(new MonedaVista
                {
                    moId = i.moId,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    moUsuarioCrea = i.moUsuarioCrea,
                    moFechaCrea = i.moFechaCrea,
                    moUsuarioModifica = i.moUsuarioModifica,
                    moFechaModifica = i.moFechaModifica,
                    usuNombres = i.usuNombres,
                    usuApellidos = i.usuApellidos,
                    usuNombresMod = i.usuNombresMod,
                    usuApellidosMod = i.usuApellidosMod
                });
            }
            monedas = list.ToArray();

            ViewData["monedas"] = monedas.ToList();

            return View();
        }

        // GET: tbMonedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonedaVista[] monedas = null;
            var moneda = (from m in _context.tbMoneda
                          join u in _context.tbUsuarios
                          on m.moUsuarioCrea equals u.usuId
                          into leftUsuCrea
                          from u in leftUsuCrea.DefaultIfEmpty()
                          join u2 in _context.tbUsuarios
                          on m.moUsuarioModifica equals u2.usuId
                          into leftUsuMod
                          from u2 in leftUsuMod.DefaultIfEmpty()
                          where m.moId == id
                          select new
                          {
                              moId = m.moId,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre,
                              moUsuarioCrea = m.moUsuarioCrea,
                              moFechaCrea = m.moFechaCrea,
                              moUsuarioModifica = m.moUsuarioModifica,
                              moFechaModifica = m.moFechaModifica,
                              usuNombres = u.usuNombres,
                              usuApellidos = u.usuApellidos,
                              usuNombresMod = u2.usuNombres,
                              usuApellidosMod = u2.usuApellidos
                          }).ToList();
            var list = new List<MonedaVista>();

            foreach (var i in moneda)
            {
                list.Add(new MonedaVista
                {
                    moId = i.moId,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    moUsuarioCrea = i.moUsuarioCrea,
                    moFechaCrea = i.moFechaCrea,
                    moUsuarioModifica = i.moUsuarioModifica,
                    moFechaModifica = i.moFechaModifica,
                    usuNombres = i.usuNombres,
                    usuApellidos = i.usuApellidos,
                    usuNombresMod = i.usuNombresMod,
                    usuApellidosMod = i.usuApellidosMod
                });
            }
            monedas = list.ToArray();

            ViewData["monedas"] = monedas.ToList();

            return View();
        }

        // GET: tbMonedas/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearMoneda(string abreviatura, string nombre)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    var abreviaturas = _context.tbMoneda.Select(x => x.moAbreviatura).ToList();

                    foreach (var a in abreviaturas)
                    {
                        if (a.ToUpper() == abreviatura.ToUpper())
                        {
                            return Json("Existe");
                        }
                    }

                    var nombres = _context.tbMoneda.Select(x => x.moNombre).ToList();

                    foreach (var n in nombres)
                    {
                        if (n.ToUpper() == nombre.ToUpper())
                        {
                            return Json("Existe");
                        }
                    }

                    tbMoneda tbMoneda = new tbMoneda();
                    tbMoneda = new tbMoneda();
                    tbMoneda.moAbreviatura = abreviatura;
                    tbMoneda.moNombre = nombre;
                    tbMoneda.moUsuarioCrea = 1;
                    tbMoneda.moFechaCrea = DateTime.Now;
                    _context.tbMoneda.Add(tbMoneda);
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

        // GET: tbMonedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonedaVista[] monedas = null;
            var moneda = (from m in _context.tbMoneda
                          join u in _context.tbUsuarios
                          on m.moUsuarioCrea equals u.usuId
                          into leftUsuCrea
                          from u in leftUsuCrea.DefaultIfEmpty()
                          join u2 in _context.tbUsuarios
                          on m.moUsuarioModifica equals u2.usuId
                          into leftUsuMod
                          from u2 in leftUsuMod.DefaultIfEmpty()
                          where m.moId == id
                          select new
                          {
                              moId = m.moId,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre,
                              moUsuarioCrea = m.moUsuarioCrea,
                              moFechaCrea = m.moFechaCrea,
                              moUsuarioModifica = m.moUsuarioModifica,
                              moFechaModifica = m.moFechaModifica,
                              usuNombres = u.usuNombres,
                              usuApellidos = u.usuApellidos,
                              usuNombresMod = u2.usuNombres,
                              usuApellidosMod = u2.usuApellidos
                          }).ToList();
            var list = new List<MonedaVista>();

            foreach (var i in moneda)
            {
                list.Add(new MonedaVista
                {
                    moId = i.moId,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    moUsuarioCrea = i.moUsuarioCrea,
                    moFechaCrea = i.moFechaCrea,
                    moUsuarioModifica = i.moUsuarioModifica,
                    moFechaModifica = i.moFechaModifica,
                    usuNombres = i.usuNombres,
                    usuApellidos = i.usuApellidos,
                    usuNombresMod = i.usuNombresMod,
                    usuApellidosMod = i.usuApellidosMod
                });
            }
            monedas = list.ToArray();

            ViewData["monedas"] = monedas.ToList();

            return View();
        }

        public ActionResult EditarMoneda(int id, string abreviatura, string nombre)
        {
            try
            {
                tbMoneda tbMoneda = _context.tbMoneda.Find(id);
                if (tbMoneda != null)
                {                   
                    tbMoneda.moAbreviatura = abreviatura;
                    tbMoneda.moNombre = nombre;
                    tbMoneda.moFechaModifica = DateTime.Now;
                    tbMoneda.moUsuarioModifica = 1;
                    _context.Entry(tbMoneda).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbMonedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonedaVista[] monedas = null;
            var moneda = (from m in _context.tbMoneda
                          join u in _context.tbUsuarios
                          on m.moUsuarioCrea equals u.usuId
                          into leftUsuCrea
                          from u in leftUsuCrea.DefaultIfEmpty()
                          join u2 in _context.tbUsuarios
                          on m.moUsuarioModifica equals u2.usuId
                          into leftUsuMod
                          from u2 in leftUsuMod.DefaultIfEmpty()
                          where m.moId == id
                          select new
                          {
                              moId = m.moId,
                              moAbreviatura = m.moAbreviatura,
                              moNombre = m.moNombre,
                              moUsuarioCrea = m.moUsuarioCrea,
                              moFechaCrea = m.moFechaCrea,
                              moUsuarioModifica = m.moUsuarioModifica,
                              moFechaModifica = m.moFechaModifica,
                              usuNombres = u.usuNombres,
                              usuApellidos = u.usuApellidos,
                              usuNombresMod = u2.usuNombres,
                              usuApellidosMod = u2.usuApellidos
                          }).ToList();
            var list = new List<MonedaVista>();

            foreach (var i in moneda)
            {
                list.Add(new MonedaVista
                {
                    moId = i.moId,
                    moAbreviatura = i.moAbreviatura,
                    moNombre = i.moNombre,
                    moUsuarioCrea = i.moUsuarioCrea,
                    moFechaCrea = i.moFechaCrea,
                    moUsuarioModifica = i.moUsuarioModifica,
                    moFechaModifica = i.moFechaModifica,
                    usuNombres = i.usuNombres,
                    usuApellidos = i.usuApellidos,
                    usuNombresMod = i.usuNombresMod,
                    usuApellidosMod = i.usuApellidosMod
                });
            }
            monedas = list.ToArray();

            ViewData["monedas"] = monedas.ToList();

            return View();
        }

        // POST: tbMonedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMoneda tbMoneda = _context.tbMoneda.Find(id);

            _context.tbMoneda.Remove(tbMoneda);
            _context.SaveChanges();
            return RedirectToAction("Index", "tbMonedas");
        }

        private bool tbMonedaExists(int id)
        {
            return _context.tbMoneda.Any(e => e.moId == id);
        }
    }
}
