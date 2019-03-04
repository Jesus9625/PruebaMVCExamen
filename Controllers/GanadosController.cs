using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s102parcial1ingweb.Models;

namespace s102parcial1ingweb.Controllers
{
    public class GanadosController : Controller
    
    {

        private readonly SqliteGanadoRepository ganados;

        public GanadosController(){

            ganados = new SqliteGanadoRepository("DataSource=app.db");

        }
            
        // GET: Ganados
        public ActionResult Index()
        {
            var model = ganados.LeerTodos();
            return View(model);
        }

        // GET: Ganados/Details/5
        public ActionResult Details(int id)
        {
            var model = ganados.LeerPorId(id);
            return View(model);
        }

        // GET: Ganados/Create
        public ActionResult Create()
        {
            var model = new GanadoModel();
            return View(model);
        }

        // POST: Ganados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GanadoModel model)
        {
            try
            {
                // TODO: Add insert logic here

                ganados.Crear(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ganados/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ganados.LeerPorId(id);

            if(model == null){
                return NotFound();
            }
            return View(model);
        }

        // POST: Ganados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GanadoModel model)
        {
            try
            {
                var empleado = ganados.LeerPorId(id);

                if(model == null){
                    return NotFound();
                 }
                // TODO: Add update logic here
                ganados.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ganados/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ganados.LeerPorId(id);

                if(model == null){
                    return NotFound();
                 }
            return View(model);
        }

        // POST: Ganados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GanadoModel model)
        {
            try
            {
                // TODO: Add delete logic here
                ganados.Borrar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}