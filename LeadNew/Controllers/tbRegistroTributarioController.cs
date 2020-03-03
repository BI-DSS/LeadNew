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
    public class tbRegistroTributarioController : Controller
    {
        private readonly LeadNewDB _context;

        public tbRegistroTributarioController(LeadNewDB context)
        {
            _context = context;
        }

        //GET: tbRegistroTributario
        public ActionResult Index()
        {
            IList<tbRegistroTributario> RegistrosList = new List<tbRegistroTributario>();

            ViewData["RegistroList"] = RegistrosList;

            return View();

        }
        public ActionResult EmpresaLista()
        {
            var empresas = (from emp in _context.tbEmpresa select new { Text = emp.empNombre, Value = emp.empId }).ToList().OrderBy(x => x.Text);
            return Json(empresas, new Newtonsoft.Json.JsonSerializerSettings());
        }

        //GET: tbResgistroTribitarios/Detail/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbResistroTributario = await _context.tbRegistroTributarios
                .FirstOrDefaultAsync(m => m.rtId == id);
            if (tbResistroTributario == null)
            {
                return NotFound();
            }
            return View(tbResistroTributario);
        }

        //GET: tbResgistroTributario/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult CrearRegistro(int rtIdEmpresa, string rtCAI, string rtRangoAutoInicio, string rtRangoAutoFinal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbRegistroTributario tbRegistroTrubutario = new tbRegistroTributario();
                    tbRegistroTrubutario = new tbRegistroTributario();
                    tbRegistroTrubutario.rtIdEmpresa = rtIdEmpresa;
                    tbRegistroTrubutario.rtCAI = rtCAI;
                    tbRegistroTrubutario.rtFechaCreacion = DateTime.Now;
                    tbRegistroTrubutario.rtFechainicio = DateTime.Now;
                    tbRegistroTrubutario.rtRangoAutoInicio = rtRangoAutoInicio;
                    tbRegistroTrubutario.rtRangoAutoFinal = rtRangoAutoFinal;
                    _context.tbRegistroTributarios.Add(tbRegistroTrubutario);
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
        // GET: tbRegistroTributarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbRegistroTributarios = await _context.tbRegistroTributarios.FindAsync(id);
            if (tbRegistroTributarios == null)
            {
                return NotFound();
            }
            return View(tbRegistroTributarios);
        }

        public ActionResult EditarRegistro(int id, string rtCAI, string rtRangoAutoInicio, string rtRangoAutoFinal)
        {
            try
            {
                tbRegistroTributario tbRegistroTributario = _context.tbRegistroTributarios.Find(id);
                if (tbRegistroTributario != null)
                {
                    tbRegistroTributario.rtCAI = rtCAI;
                    tbRegistroTributario.rtRangoAutoInicio = rtRangoAutoInicio;
                    tbRegistroTributario.rtRangoAutoFinal = rtRangoAutoFinal;
                    _context.Entry(tbRegistroTributario).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public async Task<IActionResult> ListadoTributario(int? id)
        {
            if (id == null)
                {
                return NotFound();
            }

            var tbRegistroTributarios = await _context.tbRegistroTributarios.FindAsync(id);
            if (tbRegistroTributarios == null)
            {
                return NotFound();
            }
            return View(tbRegistroTributarios);
        }
             
    }
}
