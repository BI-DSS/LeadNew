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
    public class tbCierreCajaController : Controller
    {
        private readonly LeadNewDB _context;

        public tbCierreCajaController(LeadNewDB context)
        {
            _context = context;
        }


        // GET: tbCierreCaja
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbCierreCajas.ToListAsync());
        }

        

        // GET: tbCierreCaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCierreCaja = await _context.tbCierreCajas
                .FirstOrDefaultAsync(m => m.ccId == id);
            if (tbCierreCaja == null)
            {
                return NotFound();
            }

            return View(tbCierreCaja);
        }

        // GET: tbCierreCaja/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearCierre(decimal ccTotalCierre, int ccIdEmpresa, int ccIdSucursal, int ccIdUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbCierreCaja tbCierreCaja = new tbCierreCaja();
                    tbCierreCaja = new tbCierreCaja();
                    tbCierreCaja.ccTotalCierre = ccTotalCierre;
                    tbCierreCaja.ccIdEmpresa = ccIdEmpresa;
                    tbCierreCaja.ccIdSucursal = ccIdSucursal;
                    tbCierreCaja.ccIdUsuario = ccIdUsuario;
                    tbCierreCaja.ccFechaCierre = DateTime.Now;
                    _context.tbCierreCajas.Add(tbCierreCaja);
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

        // GET: tbCierreCaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbCierreCaja = await _context.tbCierreCajas.FindAsync(id);
            if (tbCierreCaja == null)
            {
                return NotFound();
            }
            return View(tbCierreCaja);
        }

        public ActionResult EditarCierreCaja(int id, decimal ccTotalCierre, int ccIdEmpresa, int ccIdSucursal, int ccIdUsuario)
        {
            try
            {
                tbCierreCaja tbCierreCaja = _context.tbCierreCajas.Find(id);
                if (tbCierreCaja != null)
                {
                    tbCierreCaja.ccTotalCierre = ccTotalCierre;
                    tbCierreCaja.ccIdEmpresa = ccIdEmpresa;
                    tbCierreCaja.ccIdSucursal = ccIdSucursal;
                    tbCierreCaja.ccIdUsuario = ccIdUsuario;
                    _context.Entry(tbCierreCaja).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbCierreCaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCierreCaja = await _context.tbCategoriaProducto
                .FirstOrDefaultAsync(m => m.catId == id);
            if (tbCierreCaja == null)
            {
                return NotFound();
            }

            return View(tbCierreCaja);
        }

        // POST: tbCierreCaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCOnfirmed(int id)
        {
            var tbCierreCaja = await _context.tbCierreCajas.FindAsync(id);
            _context.tbCierreCajas.Remove(tbCierreCaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbCierreCajaExists(int id)
        {
            return _context.tbCierreCajas.Any(e => e.ccId == id);
        }
    }
}