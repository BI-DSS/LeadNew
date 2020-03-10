using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeadNew.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly LeadNewDB _context;

        public FacturacionController(LeadNewDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult EmpresaLista()
        {
            //var sa = new JsonSerializerSettings();
            var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas);
        }

        public ActionResult SucursalLista()
        {
            var id_empresa = _context.tbUsuarios.Where(x => x.usuId == 6).Select(x => x.usuIdEmpresa).Single();
            var sucursales = (from suc in _context.tbSucursales where suc.sucIdEmpresa == id_empresa select new { Text = suc.sucNombre, Value = suc.sucId }).ToList().OrderBy(x => x.Text);
            return Json(sucursales);
        }

        public PartialViewResult Productos(int id)
        {            
            var productos = _context.tbProducto.Where(x => x.prIdSucursal == id).ToList();
            ViewData["Productos"] = productos;
            return PartialView();                        
        }

        public PartialViewResult Empresa(int id)
        {
            var empresa = _context.tbEmpresa.Where(x => x.empId == id).ToList();
            ViewData["Empresa"] = empresa;
            return PartialView();
        }
    }
}