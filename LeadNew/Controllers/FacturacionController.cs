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
            //var productos = _context.tbProducto.Where(x => x.prIdSucursal == id).ToList();
            tbProductoFactura[] products = null;
            var productos = (from p in _context.tbProducto
                             join m in _context.tbMoneda
                             on p.prMoneda equals m.moId
                             join d in _context.tbDescuentos
                             on p.prId equals d.desIdProducto 
                             into left from d in left.DefaultIfEmpty()
                             join imp in _context.tbImpuesto
                             on p.prIdImpuesto equals imp.impId
                             where p.prIdSucursal == id
                             select new { 
                                 prIdInterno = p.prIdInterno, prDetalle = p.prDetalle, prCantidad = p.prCantidad, prPrecioVenta = p.prPrecioVenta, moNombre = m.moNombre,
                                 moId = m.moId, moAbreviatura = m.moAbreviatura,
                                 desId = d.desId, desPorcentaje = d.desPorcentaje,
                                 impId = imp.impId, impPorcentaje = imp.impPorcentaje
                             }).ToList();
            var list = new List<tbProductoFactura>();

            foreach (var i in productos)
            {
                list.Add(new tbProductoFactura { 
                    prIdInterno = i.prIdInterno, prDetalle = i.prDetalle, prCantidad = i.prCantidad, prPrecioVenta = i.prPrecioVenta, moNombre = i.moNombre,
                    moId = i.moId, moAbreviatura = i.moAbreviatura,
                    desId = i.desId, desPorcentaje = i.desPorcentaje,
                    impId = i.impId, impPorcentaje = i.impPorcentaje
                });
            }
            products = list.ToArray();

            ViewData["Productos"] = products.ToList();
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