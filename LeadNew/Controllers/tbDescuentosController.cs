﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadNew.Controllers
{
    public class tbDescuentosController : Controller
    {
        private readonly LeadNewDB _context;

        public tbDescuentosController(LeadNewDB context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            DescuentosVista[] DescuentosVista = null;
            var descuentos = (from d in _context.tbDescuentos
                          join p in _context.tbProducto
                          on d.desIdProducto equals p.prId
                          select new
                          {
                              desId = d.desId,
                              desNombreCampaña = d.desNombreCampaña,
                              desPorcentaje = d.desPorcentaje,
                              desFechaCreacion = d.desFechaCreacion,
                              desFechaInicio = d.desFechaInicio,
                              desFechaFinal = d.desFechaFinal,
                              desIdProducto = d.desIdProducto,
                              prIdInterno = p.prIdInterno,
                              prDetalle = p.prDetalle
                          }).ToList();
            var list = new List<DescuentosVista>();

            foreach (var i in descuentos)
            {
                list.Add(new DescuentosVista
                {
                    desId = i.desId,
                    desNombreCampaña = i.desNombreCampaña,
                    desPorcentaje = i.desPorcentaje,
                    desFechaCreacion = i.desFechaCreacion,
                    desFechaInicio = i.desFechaInicio,
                    desFechaFinal = i.desFechaFinal,
                    desIdProducto = i.desIdProducto,
                    prIdInterno = i.prIdInterno,
                    prDetalle = i.prDetalle
                });
            }
            DescuentosVista = list.ToArray();

            ViewData["DescuentosVista"] = DescuentosVista.ToList();


            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ProductoLista()
        {
            var productos = (from mon in _context.tbProducto select new { Text = mon.prDetalle, Value = mon.prId }).ToList().OrderBy(x => x.Text);
            return Json(productos);
        }

        public ActionResult CrearDescuento(string desCampaña, int desPorcentaje, DateTime desFechaInicio, DateTime desFechaFin, int desProducto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbDescuentos tbDescuentos = new tbDescuentos();
                    tbDescuentos = new tbDescuentos();
                    tbDescuentos.desNombreCampaña = desCampaña;
                    tbDescuentos.desPorcentaje = desPorcentaje;
                    tbDescuentos.desFechaInicio = desFechaInicio;
                    tbDescuentos.desFechaFinal = desFechaFin;
                    tbDescuentos.desIdProducto = desProducto;
                    tbDescuentos.desFechaCreacion = DateTime.Now;
                    _context.tbDescuentos.Add(tbDescuentos);
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

            var tbDescuentos = await _context.tbDescuentos.FindAsync(id);
            if (tbDescuentos == null)
            {
                return NotFound();
            }
            return View(tbDescuentos);
        }

        public ActionResult EditarDescuento(int id, string desCampaña, int desPorcentaje, DateTime desFechaInicio, DateTime desFechaFin, int desProducto)
        {
            try
            {
                tbDescuentos tbDescuentos = _context.tbDescuentos.Find(id);
                if (tbDescuentos != null)
                {
                    tbDescuentos.desNombreCampaña = desCampaña;
                    tbDescuentos.desPorcentaje = desPorcentaje;
                    tbDescuentos.desFechaInicio = desFechaInicio;
                    tbDescuentos.desFechaFinal = desFechaFin;
                    tbDescuentos.desIdProducto = desProducto;                    
                    _context.Entry(tbDescuentos).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDescuentos = _context.tbDescuentos.FirstOrDefault(m => m.desId == id);
            if (tbDescuentos == null)
            {
                return NotFound();
            }

            return View(tbDescuentos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDescuentos = await _context.tbDescuentos.FindAsync(id);
            _context.tbDescuentos.Remove(tbDescuentos);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "tbDescuentos");
        }
    }
}