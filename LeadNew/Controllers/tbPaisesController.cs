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
    public class tbPaisesController : Controller
    {
        private readonly LeadNewDB _context;

        public tbPaisesController(LeadNewDB context)
        {
            _context = context;
        }

        //GET: tbPaises
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbPaises.ToListAsync());
        }

        //GET: tbPaises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPaises = await _context.tbPaises
                .FirstOrDefaultAsync(m => m.paId == id);
            if (tbPaises == null)
            {
                return NotFound();
            }
            return View(tbPaises);
        }

        //GET: tbPaises/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearPais(string paNombre, int paCodPostal, string paAbreviatura, int paUsuarioCrea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbPaises tbPaises = new tbPaises();
                    tbPaises = new tbPaises();
                    tbPaises.paNombre = paNombre;
                    tbPaises.paCodPostal = paCodPostal;
                    tbPaises.paAbreviatura = paAbreviatura;
                    tbPaises.paUsuarioCrea = 1;
                    tbPaises.paFechaCrea = DateTime.Now;
                    _context.tbPaises.Add(tbPaises);
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
        //GET: tbPaises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPaises = await _context.tbPaises.FindAsync(id);
            if (tbPaises == null)
            {
                return NotFound();
            }
            return View(tbPaises);
        }

        public ActionResult EditarPais(int id, string paNombre, int paCodPostal, string paAbreviatura, int paUsuarioCrea)
        {
            try
            {
                tbPaises tbPaises = _context.tbPaises.Find(id);
                if (tbPaises != null)
                {
                    tbPaises.paNombre = paNombre;
                    tbPaises.paCodPostal = paCodPostal;
                    tbPaises.paAbreviatura = paAbreviatura;
                    _context.Entry(tbPaises).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        //GET: tbPaises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPaises = await _context.tbPaises
                .FirstOrDefaultAsync(m => m.paId == id);
            if (tbPaises == null)
            {
                return NotFound();
            }
            return View(tbPaises);
        }

        //POST: tbPaises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPaises = await _context.tbPaises.FindAsync(id);
            _context.tbPaises.Remove(tbPaises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbPaisesExist(int id)
        {
            return _context.tbPaises.Any(e => e.paId == id);
        }
    }
}
