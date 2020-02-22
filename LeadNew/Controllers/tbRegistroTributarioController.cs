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
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbRegistroTrubutarios.ToListAsync());
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

            var tbResistroTributario = await _context.tbRegistroTrubutarios
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
                    tbRegistroTrubutario tbRegistroTrubutario = new tbRegistroTrubutario();
                    tbRegistroTrubutario = new tbRegistroTrubutario();
                    tbRegistroTrubutario.rtIdEmpresa = rtIdEmpresa;
                    tbRegistroTrubutario.rtCAI = rtCAI;
                    tbRegistroTrubutario.rtFechaCreacion = DateTime.Now;
                    tbRegistroTrubutario.rtFechainicio = DateTime.Now;
                    tbRegistroTrubutario.rtRangoAutoInicio = rtRangoAutoInicio;
                    tbRegistroTrubutario.rtRangoAutoFinal = rtRangoAutoFinal;
                    _context.tbRegistroTrubutarios.Add(tbRegistroTrubutario);
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

            var tbRegistroTributarios = await _context.tbRegistroTrubutarios.FindAsync(id);
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
                tbRegistroTrubutario tbRegistroTrubutario = _context.tbRegistroTrubutarios.Find(id);
                if (tbRegistroTrubutario != null)
                {
                    tbRegistroTrubutario.rtCAI = rtCAI;
                    tbRegistroTrubutario.rtRangoAutoInicio = rtRangoAutoInicio;
                    tbRegistroTrubutario.rtRangoAutoFinal = rtRangoAutoFinal;
                    _context.Entry(tbRegistroTrubutario).State = EntityState.Modified;
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

            var tbRegistroTributarios = await _context.tbRegistroTrubutarios.FindAsync(id);
            if (tbRegistroTributarios == null)
            {
                return NotFound();
            }
            return View(tbRegistroTributarios);
        }
             
    }
}
