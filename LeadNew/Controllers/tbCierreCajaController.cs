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

        public ActionResult EditarCierreCaja(int id, )
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: tbCierreCaja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: tbCierreCaja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}