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
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbMoneda.ToListAsync());
        }

        // GET: tbMonedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMoneda = await _context.tbMoneda
                .FirstOrDefaultAsync(m => m.moId == id);
            if (tbMoneda == null)
            {
                return NotFound();
            }

            return View(tbMoneda);
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMoneda = await _context.tbMoneda.FindAsync(id);
            if (tbMoneda == null)
            {
                return NotFound();
            }
            return View(tbMoneda);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMoneda = await _context.tbMoneda
                .FirstOrDefaultAsync(m => m.moId == id);
            if (tbMoneda == null)
            {
                return NotFound();
            }

            return View(tbMoneda);
        }

        // POST: tbMonedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMoneda = await _context.tbMoneda.FindAsync(id);
            _context.tbMoneda.Remove(tbMoneda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbMonedaExists(int id)
        {
            return _context.tbMoneda.Any(e => e.moId == id);
        }
    }
}
