using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YerbaterosEntitys.Models;

namespace YerbaterosEntitys.Controllers
{
    public class tb_RutaController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Ruta
        public ActionResult Index()
        {
            var tb_Ruta = db.tb_Ruta.Include(t => t.tb_TerminalTerrestre).Include(t => t.tb_TerminalTerrestre1);
            return View(tb_Ruta.ToList());
        }

        // GET: tb_Ruta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Ruta tb_Ruta = db.tb_Ruta.Find(id);
            if (tb_Ruta == null)
            {
                return HttpNotFound();
            }
            return View(tb_Ruta);
        }

        // GET: tb_Ruta/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Terminal_Origen = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal");
            ViewBag.Cod_Terminal_Destino = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal");
            return View();
        }

        // POST: tb_Ruta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Ruta,Alias_Ruta,Tiempo_Promedio_Ruta,Cod_Terminal_Origen,Cod_Terminal_Destino,DistanciaKm")] tb_Ruta tb_Ruta)
        {
            if (ModelState.IsValid)
            {
                db.tb_Ruta.Add(tb_Ruta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Terminal_Origen = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Origen);
            ViewBag.Cod_Terminal_Destino = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Destino);
            return View(tb_Ruta);
        }

        // GET: tb_Ruta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Ruta tb_Ruta = db.tb_Ruta.Find(id);
            if (tb_Ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Terminal_Origen = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Origen);
            ViewBag.Cod_Terminal_Destino = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Destino);
            return View(tb_Ruta);
        }

        // POST: tb_Ruta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Ruta,Alias_Ruta,Tiempo_Promedio_Ruta,Cod_Terminal_Origen,Cod_Terminal_Destino,DistanciaKm")] tb_Ruta tb_Ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Ruta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Terminal_Origen = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Origen);
            ViewBag.Cod_Terminal_Destino = new SelectList(db.tb_TerminalTerrestre, "Cod_Terminal", "Nombre_Terminal", tb_Ruta.Cod_Terminal_Destino);
            return View(tb_Ruta);
        }

        // GET: tb_Ruta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Ruta tb_Ruta = db.tb_Ruta.Find(id);
            if (tb_Ruta == null)
            {
                return HttpNotFound();
            }
            return View(tb_Ruta);
        }

        // POST: tb_Ruta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Ruta tb_Ruta = db.tb_Ruta.Find(id);
            db.tb_Ruta.Remove(tb_Ruta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
