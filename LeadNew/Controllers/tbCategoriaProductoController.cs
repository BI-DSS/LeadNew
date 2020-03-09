using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadNew.Controllers
{
    public class tbCategoriaProductoController : Controller
    {
        private readonly LeadNewDB _context;

        public tbCategoriaProductoController(LeadNewDB context)
        {
            _context = context;
        }

        public ActionResult Index()
        {            
            return View(_context.tbCategoriaProducto.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CrearCategoria(string catNombre, string catDescripcion)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    tbCategoriaProducto tbCategoriaProducto = new tbCategoriaProducto();
                    tbCategoriaProducto = new tbCategoriaProducto();
                    tbCategoriaProducto.catNombre = catNombre;
                    tbCategoriaProducto.catDescripcion = catDescripcion;
                    tbCategoriaProducto.catFechaCreacion = DateTime.Now;                                                           
                    _context.tbCategoriaProducto.Add(tbCategoriaProducto);
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

            var tbCategoriaProducto = await _context.tbCategoriaProducto.FindAsync(id);
            if (tbCategoriaProducto == null)
            {
                return NotFound();
            }
            return View(tbCategoriaProducto);
        }

        public ActionResult EditarCategoria(int catId, string catNombre, string catDescripcion)
        {
            try
            {
                tbCategoriaProducto tbCategoriaProducto = _context.tbCategoriaProducto.Find(catId);
                if (tbCategoriaProducto != null)
                {
                    tbCategoriaProducto.catNombre = catNombre;
                    tbCategoriaProducto.catDescripcion = catDescripcion;
                    _context.Entry(tbCategoriaProducto).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}