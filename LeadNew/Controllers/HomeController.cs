using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeadNew.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace LeadNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeadNewDB _context;

        public HomeController(LeadNewDB context)
        {
            _context = context;
        }

        public ActionResult Index()
        {            

            var usuarioXempresa = from e in _context.tbEmpresa
                                  join u in _context.tbUsuarios
                                  on e.empUsuarioCrea equals u.usuId
                                  group e by new { u.usuId, u.usuNombreUsuario } into g
                                  select new { nombre = g.Key.usuNombreUsuario, conteo = 1, href = "https://images.app.goo.gl/QUb9jistwp3g3qSTA" };
            ViewBag.usuarioXempresa = JsonConvert.SerializeObject(usuarioXempresa);

            var Productos_usuarios = from p in _context.tbProducto
                                     join u in _context.tbUsuarios
                                     on p.prUsuario equals u.usuId.ToString()
                                     group p by new { cantidad = p.prId, usuario = u.usuNombreUsuario } into g
                                     select new { conteo = 3, usu = g.Key.usuario };
            ViewBag.Productos_usuarios = JsonConvert.SerializeObject(Productos_usuarios);

            var ProductosStock = (from e in _context.tbProducto
                                  where e.prIdSucursal == 5 && e.prCantidad < 70
                                  select e.prId).Count();
            ViewData["ProductosStock"] = ProductosStock;

            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            var now = DateTime.Now;
            var RgTributario = (from rt in _context.tbRegistroTributario
                                where DbF.DateDiffDay(now, rt.rtFechafinal) <= 40
                                select rt.rtId).Count();
            ViewData["RgTributario"] = RgTributario;

            return View();
        }

        public ActionResult RegistroTributario()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            var now = DateTime.Now;
            RegistroTributarioNotificaciones[] tributario = null;
            var registro = (from rt in _context.tbRegistroTributario
                            join e in _context.tbEmpresa
                            on rt.rtIdEmpresa equals e.empId
                            where (DbF.DateDiffDay(now, rt.rtFechafinal) <= 40)
                            select new
                            {
                                rtCAI = rt.rtCAI,
                                rtFechafinal = rt.rtFechafinal,
                                rtRangoAutoInicio = rt.rtRangoAutoInicio,
                                rtRangoAutoFinal = rt.rtRangoAutoFinal,
                                empNombre = e.empNombre
                            }).ToList();

            var list = new List<RegistroTributarioNotificaciones>();

            foreach (var i in registro)
            {
                list.Add(new RegistroTributarioNotificaciones
                {
                    rtCAI = i.rtCAI,
                    rtFechafinal = i.rtFechafinal,
                    rtRangoAutoInicio = i.rtRangoAutoInicio,
                    rtRangoAutoFinal = i.rtRangoAutoFinal,
                    empNombre = i.empNombre
                });
            }
            tributario = list.ToArray();
            ViewData["tributario"] = tributario.ToList();

            return View();
        }

        public ActionResult ProductosStock()
        {
            tbProductoFactura[] products = null;
            var productos = (from p in _context.tbProducto
                             join m in _context.tbMoneda
                             on p.prMoneda equals m.moId
                             join d in _context.tbDescuentos
                             on p.prId equals d.desIdProducto
                             into left
                             from d in left.DefaultIfEmpty()
                             join imp in _context.tbImpuesto
                             on p.prIdImpuesto equals imp.impId
                             where p.prIdSucursal == 5 && p.prCantidad < 70
                             select new
                             {
                                 prIdInterno = p.prIdInterno,
                                 prDetalle = p.prDetalle,
                                 prCantidad = p.prCantidad,
                                 prPrecioVenta = p.prPrecioVenta,
                                 moNombre = m.moNombre,
                                 moId = m.moId,
                                 moAbreviatura = m.moAbreviatura,
                                 desId = d.desId,
                                 desPorcentaje = d.desPorcentaje,
                                 impId = imp.impId,
                                 impPorcentaje = imp.impPorcentaje,
                                 prImagen = p.prImagen
                             }).ToList();
            var list = new List<tbProductoFactura>();

            foreach (var i in productos)
            {
                list.Add(new tbProductoFactura
                {
                    prIdInterno = i.prIdInterno,
                    prDetalle = i.prDetalle,
                    prCantidad = i.prCantidad,
                    prPrecioVenta = i.prPrecioVenta,
                    moNombre = i.moNombre,
                    moId = i.moId,
                    moAbreviatura = i.moAbreviatura,
                    desId = i.desId,
                    desPorcentaje = i.desPorcentaje,
                    impId = i.impId,
                    impPorcentaje = i.impPorcentaje,
                    prImagen = i.prImagen
                });
            }
            products = list.ToArray();
            ViewData["Productos"] = products.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginDataModel)
        {
            if (ModelState.IsValid)
            {
                // AQUÍ EL CÓDIGO DE VALIDACIÓN DEL USUARIO
                return RedirectToAction("LoginOk");
            }
            else
            {
                return View(loginDataModel);
            }
        }

        public ActionResult LoginOK()
        {
            // LA VALIDACIÓN DEL USUARIO HA SIDO CORRECTA
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
