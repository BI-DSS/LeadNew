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
    public class tbLenguajesController : Controller
    {
        private readonly LeadNewDB _context;

        public tbLenguajesController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbLenguajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbLenguaje.ToListAsync());
        }

        // GET: tbLenguajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLenguaje = await _context.tbLenguaje
                .FirstOrDefaultAsync(m => m.lenId == id);
            if (tbLenguaje == null)
            {
                return NotFound();
            }

            return View(tbLenguaje);
        }

        // GET: tbLenguajes/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearLenguaje(string nombre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbLenguaje tbLenguaje = new tbLenguaje();
                    tbLenguaje = new tbLenguaje();
                    tbLenguaje.lenNombre = nombre;
                    tbLenguaje.lenFehcaActivacion = DateTime.Now;
                    _context.tbLenguaje.Add(tbLenguaje);
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

        // GET: tbLenguajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLenguaje = await _context.tbLenguaje.FindAsync(id);
            if (tbLenguaje == null)
            {
                return NotFound();
            }
            return View(tbLenguaje);
        }

        public ActionResult EditarLenguaje(int id, string nombre)
        {
            try
            {
                tbLenguaje tbLenguaje = _context.tbLenguaje.Find(id);
                if (tbLenguaje != null)
                {
                    tbLenguaje.lenNombre = nombre;
                    tbLenguaje.lenFehcaActivacion = DateTime.Now;
                    _context.Entry(tbLenguaje).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbLenguajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLenguaje = await _context.tbLenguaje
                .FirstOrDefaultAsync(m => m.lenId == id);
            if (tbLenguaje == null)
            {
                return NotFound();
            }

            return View(tbLenguaje);
        }

        // POST: tbLenguajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLenguaje = await _context.tbLenguaje.FindAsync(id);
            _context.tbLenguaje.Remove(tbLenguaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbLenguajeExists(int id)
        {
            return _context.tbLenguaje.Any(e => e.lenId == id);
        }
    }
}
