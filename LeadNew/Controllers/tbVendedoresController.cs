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
    public class tbVendedoresController : Controller
    {
        private readonly LeadNewDB _context;

        public tbVendedoresController(LeadNewDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        { 
        return View(await _context.tbVendedores.ToListAsync());
        }

        public ActionResult EmpresaLista()
        { 
        var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbVendedores = await _context.tbVendedores
                .FirstOrDefaultAsync(m => m.venId == id);
            if (tbVendedores == null)
            {
                return NotFound();
            }
            return View(tbVendedores);
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearVendedor(string venNombre, int venTuId, int venEstado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbVendedores tbVendedores = new tbVendedores();
                    tbVendedores = new tbVendedores();
                    tbVendedores.venNombre = venNombre;
                    tbVendedores.venTuId = venTuId;
                    tbVendedores.venEstado = venEstado;
                    _context.tbVendedores.Add(tbVendedores);
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendedores = await _context.tbVendedores.FindAsync(id);
            if (tbVendedores == null)
            {
                return NotFound();
            }
            return View(tbVendedores);
        }

        public ActionResult EditarVendedor(int id, string venNombre, int venTuId, int venEstado)
        {
            try
            {
                tbVendedores tbVendedores = _context.tbVendedores.Find(id);
                if (tbVendedores != null)
                {
                    tbVendedores.venNombre = venNombre;
                    tbVendedores.venTuId = venTuId;
                    tbVendedores.venEstado = venEstado;
                    _context.Entry(tbVendedores).State = EntityState.Modified;
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
            var tbVendedores = await _context.tbVendedores
                .FirstOrDefaultAsync(m => m.venId == id);
            if (tbVendedores == null)
            {
                return NotFound();
            }
            return View(tbVendedores);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tbVendedores = await _context.tbVendedores.FindAsync(id);
            _context.tbVendedores.Remove(tbVendedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbVendedoresExist(int id)
        {
            return _context.tbVendedores.Any(e => e.venId == id);
        }
    }
}
