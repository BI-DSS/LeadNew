using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeadNew.Models;
using Newtonsoft.Json;

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
