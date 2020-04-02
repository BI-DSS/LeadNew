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
    public class tbEmpresaController : Controller
    {
        private readonly LeadNewDB _context;

        public tbEmpresaController(LeadNewDB context)
        {
            _context = context;
        }

        public ActionResult PaisLista()
        {
            var paises = (from pais in _context.tbPaises select new { Text = pais.paNombre, Value = pais.paId }).ToList().OrderBy(x => x.Text);
            return Json(paises);
        }

        public ActionResult MonedaLista()
        {
            var monedas = (from mon in _context.tbMoneda select new { Text = mon.moNombre, Value = mon.moId }).ToList().OrderBy(x => x.Text);
            return Json(monedas);
        }

        public ActionResult LenguajeLista()
        {
            var lenguaje = (from leng in _context.tbLenguaje select new { Text = leng.lenNombre, Value = leng.lenId }).ToList().OrderBy(x => x.Text);
            return Json(lenguaje);
        }

        //GET: tbEmpresa
        public ActionResult Index()
        {
            List<tbEmpresa> empresas = _context.tbEmpresa.ToList();
            return View(empresas);
        }

        //GET: tbEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearEmpresa(string empNombre, string empDireccion, string empTelefono, int empPais, int empMoneda, int empLenguaje, int empLicencia, int empCantidaduser)
        {
            try
            {
                if (ModelState.IsValid)
                { 
              
                    tbEmpresa tbEmpresa = new tbEmpresa();
                    tbEmpresa = new tbEmpresa();
                    tbEmpresa.empNombre = empNombre;
                    tbEmpresa.empDireccion = empDireccion;
                    tbEmpresa.empTelefono = empTelefono;
                    tbEmpresa.empPais = empPais;
                    tbEmpresa.empMoneda = empMoneda;
                    tbEmpresa.empLenguaje = empLenguaje;
                    tbEmpresa.empLicencia = empLicencia;
                    tbEmpresa.empCantidadUser = empCantidaduser;
                    tbEmpresa.empUsuarioCrea = 8;
                    tbEmpresa.empFechaCrea = DateTime.Now;
                    tbEmpresa.empFechaModifica = DateTime.Now;
                    tbEmpresa.empUsuarioModifica = 8;
                    tbEmpresa.empVenId = 1;
                    tbEmpresa.emptuId = 1;
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

        public ActionResult EditarEmpresa(int id, string empNombre, string empDireccion, string empTelefono, int empPais, int empMoneda, int empLenguaje, int empLicencia, int empCantidaduser, int empUsuariocrea)
        {
            try
            {
                tbEmpresa tbEmpresa = _context.tbEmpresa.Find(id);
                if (tbEmpresa != null)
                {
                    tbEmpresa.empNombre = empNombre;
                    tbEmpresa.empDireccion = empDireccion;
                    tbEmpresa.empTelefono = empTelefono;
                    tbEmpresa.empPais = empPais;
                    tbEmpresa.empMoneda = empMoneda;
                    tbEmpresa.empLenguaje = empLenguaje;
                    tbEmpresa.empLicencia = empLicencia;
                    tbEmpresa.empCantidadUser = empCantidaduser;
                    tbEmpresa.empUsuarioModifica = empUsuariocrea;
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

