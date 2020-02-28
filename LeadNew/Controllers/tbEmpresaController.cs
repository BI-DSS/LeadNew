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
    public class tbEmpresaController : Controller
    {
        private readonly LeadNewDB _context;

        public tbEmpresaController(LeadNewDB context)
        {
            _context = context;
        }

        //GET: tbEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbEmpresa.ToListAsync());
        }

        //GET: tbEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbEmpresa = await _context.tbEmpresa
                .FirstOrDefaultAsync(m => m.empId == id);
            if (tbEmpresa == null)
            {
                return NotFound();
            }
            return View(tbEmpresa);
        }

        //GET: tbEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult PaisLista()
        {
            var paises = (from pais in _context.tbPaises select new { Text = pais.paNombre, Value = pais.paId }).ToList().OrderBy(x => x.Text);
            return Json(paises, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult MonedaLista()
        {
            var monedas = (from mon in _context.tbMoneda select new { Text = mon.moNombre, Value = mon.moId }).ToList().OrderBy(x => x.Text);
            return Json(monedas, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult LenguajeLista()
        {
            var lenguajes = (from lengu in _context.tbLenguaje select new { Text = lengu.lenNombre, Value = lengu.lenId }).ToList().OrderBy(x => x.Text);
            return Json(lenguajes, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult CrearEmpresa(string nombre, string direccion, string telefono, string logo, int pais, int moneda, int lenguaje, int licencia, int cantidaduser, int usuariocrea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbEmpresa tbEmpresa = new tbEmpresa();
                    tbEmpresa = new tbEmpresa();
                    tbEmpresa.empNombre = nombre;
                    tbEmpresa.empDireccion = direccion;
                    tbEmpresa.empTelefono = telefono;
                    tbEmpresa.empLogo = logo;
                    tbEmpresa.empPais = pais;
                    tbEmpresa.empMoneda = moneda;
                    tbEmpresa.empLenguaje = lenguaje;
                    tbEmpresa.empLicencia = licencia;
                    tbEmpresa.empCantidadUser = cantidaduser;
                    tbEmpresa.empUsuarioCrea = usuariocrea;
                    tbEmpresa.empFechaCrea = DateTime.Now;
                    _context.tbEmpresa.Add(tbEmpresa);
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

        //GET: tbEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbEmpresa = await _context.tbEmpresa.FindAsync(id);
            if (tbEmpresa == null)
            {
                return NotFound();
            }
            return View(tbEmpresa);
        }

        public ActionResult EditarEmpresa(int id, string nombre, string direccion, string telefono, string logo, int pais, int moneda, int lenguaje, int licencia, int cantidaduser, int usermod)
        {
            try
            {
                tbEmpresa tbEmpresa = _context.tbEmpresa.Find(id);
                if (tbEmpresa != null)
                {
                    tbEmpresa.empNombre = nombre;
                    tbEmpresa.empDireccion = direccion;
                    tbEmpresa.empTelefono = telefono;
                    tbEmpresa.empLogo = logo;
                    tbEmpresa.empPais = pais;
                    tbEmpresa.empMoneda = moneda;
                    tbEmpresa.empLenguaje = lenguaje;
                    tbEmpresa.empLicencia = licencia;
                    tbEmpresa.empCantidadUser = cantidaduser;
                    tbEmpresa.empUsuarioModifica = usermod;
                    tbEmpresa.empFechaModifica = DateTime.Now;
                    _context.Entry(tbEmpresa).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbEmpresa = await _context.tbEmpresa
                .FirstOrDefaultAsync(m => m.empId == id);
            if (tbEmpresa == null)
            {
                return NotFound();
            }

            return View(tbEmpresa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbEmpresa = await _context.tbEmpresa.FindAsync(id);
            _context.tbEmpresa.Remove(tbEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbEmpresaExist(int id)
        {
            return _context.tbEmpresa.Any(e => e.empId == id);
        }


    }
}

