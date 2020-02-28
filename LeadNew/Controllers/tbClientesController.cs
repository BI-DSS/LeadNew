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
    public class tbClientesController : Controller
    {
        private readonly LeadNewDB _context;

        public tbClientesController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbClientes.ToListAsync());
        }

        public ActionResult EmpresaLista()
        {
            var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas);
        }

        // GET: tbClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.tbClientes
                .FirstOrDefaultAsync(m => m.clId == id);
            if (tbClientes == null)
            {
                return NotFound();
            }

            return View(tbClientes);
        }

        // GET: tbClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearCliente(string clNombre, string clApellido, string clTelefono, string clIdentidad, string clRTN, string clDireccion, int clIdEmpresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbClientes tbClientes = new tbClientes();
                    tbClientes = new tbClientes();
                    tbClientes.clNombre = clNombre;
                    tbClientes.clApellido = clApellido;
                    tbClientes.clTelefono = clTelefono;
                    tbClientes.clIdentidad = clIdentidad;
                    tbClientes.clRTN = clRTN;
                    tbClientes.clDireccion = clDireccion;
                    tbClientes.clIdEmpresa = clIdEmpresa;
                    tbClientes.clUsuarioCrea = 1;
                    tbClientes.clFechaCrea = DateTime.Now;
                    _context.tbClientes.Add(tbClientes);
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

        // GET: tbClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.tbClientes.FindAsync(id);
            if (tbClientes == null)
            {
                return NotFound();
            }
            return View(tbClientes);
        }

        public ActionResult EditarCliente(int id, string clNombre, string clApellido, string clTelefono, string clIdentidad, string clRTN, string clDireccion, int clIdEmpresa)
        {
            try
            {
                tbClientes tbClientes = _context.tbClientes.Find(id);
                if (tbClientes != null)
                {
                    tbClientes.clNombre = clNombre;
                    tbClientes.clApellido = clApellido;
                    tbClientes.clTelefono = clTelefono;
                    tbClientes.clIdentidad = clIdentidad;
                    tbClientes.clRTN = clRTN;
                    tbClientes.clDireccion = clDireccion;
                    tbClientes.clIdEmpresa = clIdEmpresa;
                    _context.Entry(tbClientes).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.tbClientes
                .FirstOrDefaultAsync(m => m.clId == id);
            if (tbClientes == null)
            {
                return NotFound();
            }

            return View(tbClientes);
        }

        // POST: tbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbClientes = await _context.tbClientes.FindAsync(id);
            _context.tbClientes.Remove(tbClientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbClientesExists(int id)
        {
            return _context.tbClientes.Any(e => e.clId == id);
        }
    }
}
