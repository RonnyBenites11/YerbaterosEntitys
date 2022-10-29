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
    public class tb_ViajeController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Viaje
        public ActionResult Index()
        {
            var tb_Viaje = db.tb_Viaje.Include(t => t.tb_Bus).Include(t => t.tb_Ruta);
            return View(tb_Viaje.ToList());
        }

        // GET: tb_Viaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Viaje tb_Viaje = db.tb_Viaje.Find(id);
            if (tb_Viaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_Viaje);
        }

        // GET: tb_Viaje/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro");
            ViewBag.Cod_Ruta = new SelectList(db.tb_Ruta, "Cod_Ruta", "Alias_Ruta");
            return View();
        }

        // POST: tb_Viaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Viaje,Fecha_Hora_Partida,Fecha_Hora_Llegada,Cod_Ruta,Cod_Bus")] tb_Viaje tb_Viaje)
        {
            if (ModelState.IsValid)
            {
                db.tb_Viaje.Add(tb_Viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Viaje.Cod_Bus);
            ViewBag.Cod_Ruta = new SelectList(db.tb_Ruta, "Cod_Ruta", "Alias_Ruta", tb_Viaje.Cod_Ruta);
            return View(tb_Viaje);
        }

        // GET: tb_Viaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Viaje tb_Viaje = db.tb_Viaje.Find(id);
            if (tb_Viaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Viaje.Cod_Bus);
            ViewBag.Cod_Ruta = new SelectList(db.tb_Ruta, "Cod_Ruta", "Alias_Ruta", tb_Viaje.Cod_Ruta);
            return View(tb_Viaje);
        }

        // POST: tb_Viaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Viaje,Fecha_Hora_Partida,Fecha_Hora_Llegada,Cod_Ruta,Cod_Bus")] tb_Viaje tb_Viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Viaje.Cod_Bus);
            ViewBag.Cod_Ruta = new SelectList(db.tb_Ruta, "Cod_Ruta", "Alias_Ruta", tb_Viaje.Cod_Ruta);
            return View(tb_Viaje);
        }

        // GET: tb_Viaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Viaje tb_Viaje = db.tb_Viaje.Find(id);
            if (tb_Viaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_Viaje);
        }

        // POST: tb_Viaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Viaje tb_Viaje = db.tb_Viaje.Find(id);
            db.tb_Viaje.Remove(tb_Viaje);
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
