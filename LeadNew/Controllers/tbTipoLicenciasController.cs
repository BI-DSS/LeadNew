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
    public class tbTipoLicenciasController : Controller
    {
        private readonly LeadNewDB _context;

        public tbTipoLicenciasController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbTipoLicencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbTipoLicencia.ToListAsync());
        }

        // GET: tbTipoLicencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTipoLicencia = await _context.tbTipoLicencia
                .FirstOrDefaultAsync(m => m.tlicId == id);
            if (tbTipoLicencia == null)
            {
                return NotFound();
            }

            return View(tbTipoLicencia);
        }

        // GET: tbTipoLicencias/Create
        public IActionResult Create()
        {
            return View();
        }
        
        public ActionResult CrearLicencia(string tlicDescripcion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbTipoLicencia tbTipoLicencia = new tbTipoLicencia();
                    tbTipoLicencia = new tbTipoLicencia();
                    tbTipoLicencia.tlicDescripcion = tlicDescripcion;
                    tbTipoLicencia.tlicUsuarioCrea = 1;
                    tbTipoLicencia.tlicFechaCrea = DateTime.Now;
                    _context.tbTipoLicencia.Add(tbTipoLicencia);
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

        // GET: tbTipoLicencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTipoLicencia = await _context.tbTipoLicencia.FindAsync(id);
            if (tbTipoLicencia == null)
            {
                return NotFound();
            }
            return View(tbTipoLicencia);
        }
       
        public ActionResult EditarLicencia(int id, string tlicDescripcion)
        {
            try
            {
                tbTipoLicencia tbTipoLicencia = _context.tbTipoLicencia.Find(id);
                if (tbTipoLicencia != null)
                {
                    tbTipoLicencia.tlicDescripcion = tlicDescripcion;
                    tbTipoLicencia.tlicFechaModifica = DateTime.Now;
                    tbTipoLicencia.tlicUsuarioModifica = 1;
                    _context.Entry(tbTipoLicencia).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbTipoLicencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTipoLicencia = await _context.tbTipoLicencia
                .FirstOrDefaultAsync(m => m.tlicId == id);
            if (tbTipoLicencia == null)
            {
                return NotFound();
            }

            return View(tbTipoLicencia);
        }

        // POST: tbTipoLicencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTipoLicencia = await _context.tbTipoLicencia.FindAsync(id);
            _context.tbTipoLicencia.Remove(tbTipoLicencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbTipoLicenciaExists(int id)
        {
            return _context.tbTipoLicencia.Any(e => e.tlicId == id);
        }
    }
}
