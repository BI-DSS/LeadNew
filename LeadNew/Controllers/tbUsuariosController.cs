using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeadNew.Models;
using System.Text;
using System.Security.Cryptography;

namespace LeadNew
{
    public class tbUsuariosController : Controller
    {
        private readonly LeadNewDB _context;

        public tbUsuariosController(LeadNewDB context)
        {
            _context = context;
        }

        // GET: tbUsuarios
        public ActionResult Index()
        {
            return View(_context.tbUsuarios.ToList());
        }

        // GET: tbUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.tbUsuarios
                .FirstOrDefaultAsync(m => m.usuId == id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }

            return View(tbUsuarios);
        }

        // GET: tbUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult EmpresaLista()
        {
            var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult SucursalLista(int id)
        {
            var sucursales = (from suc in _context.tbSucursales where suc.sucIdEmpresa == id select new { Text = suc.sucNombre, Value = suc.sucId }).ToList().OrderBy(x => x.Text);
            return Json(sucursales, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult CrearUsuario(string usuNombreUsuario, string usuPassword, string usuNombres, string usuApellidos, string usuCorreo, int usuIdEmpresa, int usuIdSucursal)
        {
            try
            {
                byte[] data = Encoding.GetEncoding(1252).GetBytes(usuPassword.ToUpper());
                var sha = new SHA256Managed();
                byte[] contrasena_encriptada = sha.ComputeHash(data);

                if (ModelState.IsValid)
                {
                    tbUsuarios tbUsuarios = new tbUsuarios();
                    tbUsuarios = new tbUsuarios();
                    tbUsuarios.usuNombreUsuario = usuNombreUsuario;
                    tbUsuarios.usuPassword = contrasena_encriptada.ToString();
                    tbUsuarios.usuNombres = usuNombres;
                    tbUsuarios.usuApellidos = usuApellidos;
                    tbUsuarios.usuCorreo = usuCorreo;
                    tbUsuarios.usuIdEmpresa = usuIdEmpresa;
                    tbUsuarios.usuIdSucursal = usuIdSucursal;
                    tbUsuarios.usuEsActivo = 1;
                    _context.tbUsuarios.Add(tbUsuarios);
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

        // GET: tbUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.tbUsuarios.FindAsync(id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }
            return View(tbUsuarios);
        }

        // POST: tbUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(int id, string usuNombreUsuario, string usuPassword, string usuNombres, string usuApellidos, string usuCorreo, int usuIdEmpresa, int usuIdSucursal)
        {
            try
            {
                byte[] data = Encoding.GetEncoding(1252).GetBytes(usuPassword.ToUpper());
                var sha = new SHA256Managed();
                byte[] contrasena_encriptada = sha.ComputeHash(data);

                tbUsuarios tbUsuarios = _context.tbUsuarios.Find(id);
                if (tbUsuarios != null)
                {
                    tbUsuarios.usuNombreUsuario = usuNombreUsuario;
                    tbUsuarios.usuPassword = contrasena_encriptada.ToString();
                    tbUsuarios.usuNombres = usuNombres;
                    tbUsuarios.usuApellidos = usuApellidos;
                    tbUsuarios.usuCorreo = usuCorreo;
                    tbUsuarios.usuIdEmpresa = usuIdEmpresa;
                    tbUsuarios.usuIdSucursal = usuIdSucursal;
                    tbUsuarios.usuEsActivo = 1;
                    _context.Entry(tbUsuarios).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        // GET: tbUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.tbUsuarios
                .FirstOrDefaultAsync(m => m.usuId == id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }

            return View(tbUsuarios);
        }

        // POST: tbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbUsuarios = await _context.tbUsuarios.FindAsync(id);
            _context.tbUsuarios.Remove(tbUsuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbUsuariosExists(int id)
        {
            return _context.tbUsuarios.Any(e => e.usuId == id);
        }
    }
}
