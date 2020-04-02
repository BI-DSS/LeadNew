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
    public class tbSucursalesController : Controller
    {
        private readonly LeadNewDB _context;

        public tbSucursalesController(LeadNewDB context)
        {
            _context = context;
        }

        public ActionResult EmpresaLista()
        {
            var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas);
        }

        //GET: tbSucursales
        public ActionResult Index()
        {
            List<tbSucursales> sucursales = _context.tbSucursales.ToList();
            return View(sucursales);
        }

       

        //GET: tbSucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearSucursal(string sucNombre, int sucIdEmpresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbSucursales tbSucursales = new tbSucursales();
                    tbSucursales = new tbSucursales();
                    tbSucursales.sucNombre = sucNombre;
                    tbSucursales.sucIdEmpresa = sucIdEmpresa;
                    tbSucursales.sucEstado = 1;
                    tbSucursales.sucFechaCreacion = DateTime.Now;
                    _context.tbSucursales.Add(tbSucursales);
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

        //GET: tbSucursales/Detail/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSucursales = await _context.tbSucursales
                .FirstOrDefaultAsync(m => m.sucId == id);
            if (tbSucursales == null)
            {
                return NotFound();
            }

            return View(tbSucursales);

        }

        //GET: tbSucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        { 
        if (id == null)
            {
                return NotFound();
            }
            var tbSucursales = await _context.tbSucursales.FindAsync(id);
            if (tbSucursales == null)
            {
                return NotFound();
            }
             
            return View(tbSucursales);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditarSucursal(int id, string sucNombre, int sucIdEmpresa)
        {
            try
            {
                tbSucursales tbSucursales = _context.tbSucursales.Find(id);
                if (tbSucursales != null)
                {
                    tbSucursales.sucNombre = sucNombre;
                    tbSucursales.sucIdEmpresa = sucIdEmpresa;
                    _context.Entry(tbSucursales).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbSucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSucursales = await _context.tbSucursales
                .FirstOrDefaultAsync(m => m.sucId == id);
            if (tbSucursales == null)
            {
                return NotFound();
            }

            return View(tbSucursales);
        }

        //POST: tbSucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSucursales = await _context.tbSucursales.FindAsync(id);
            _context.tbSucursales.Remove(tbSucursales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbSucursalesExists(int id)
        {
            return _context.tbSucursales.Any(e => e.sucId == id);
        }

    }
}
