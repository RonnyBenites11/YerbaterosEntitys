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
    public class tb_AsientoController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Asiento
        public ActionResult Index()
        {
            var tb_Asiento = db.tb_Asiento.Include(t => t.tb_Bus).Include(t => t.tb_TipoAsiento);
            return View(tb_Asiento.ToList());
        }

        // GET: tb_Asiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Asiento tb_Asiento = db.tb_Asiento.Find(id);
            if (tb_Asiento == null)
            {
                return HttpNotFound();
            }
            return View(tb_Asiento);
        }

        // GET: tb_Asiento/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro");
            ViewBag.Cod_Tipo_Asiento = new SelectList(db.tb_TipoAsiento, "Cod_Tipo_Asiento", "Tipo_ASiento");
            return View();
        }

        // POST: tb_Asiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Asiento,Alias_Asiento,Cod_Bus,Cod_Tipo_Asiento")] tb_Asiento tb_Asiento)
        {
            if (ModelState.IsValid)
            {
                db.tb_Asiento.Add(tb_Asiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Asiento.Cod_Bus);
            ViewBag.Cod_Tipo_Asiento = new SelectList(db.tb_TipoAsiento, "Cod_Tipo_Asiento", "Tipo_ASiento", tb_Asiento.Cod_Tipo_Asiento);
            return View(tb_Asiento);
        }

        // GET: tb_Asiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Asiento tb_Asiento = db.tb_Asiento.Find(id);
            if (tb_Asiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Asiento.Cod_Bus);
            ViewBag.Cod_Tipo_Asiento = new SelectList(db.tb_TipoAsiento, "Cod_Tipo_Asiento", "Tipo_ASiento", tb_Asiento.Cod_Tipo_Asiento);
            return View(tb_Asiento);
        }

        // POST: tb_Asiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Asiento,Alias_Asiento,Cod_Bus,Cod_Tipo_Asiento")] tb_Asiento tb_Asiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Asiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Bus = new SelectList(db.tb_Bus, "Cod_Bus", "Registro", tb_Asiento.Cod_Bus);
            ViewBag.Cod_Tipo_Asiento = new SelectList(db.tb_TipoAsiento, "Cod_Tipo_Asiento", "Tipo_ASiento", tb_Asiento.Cod_Tipo_Asiento);
            return View(tb_Asiento);
        }

        // GET: tb_Asiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Asiento tb_Asiento = db.tb_Asiento.Find(id);
            if (tb_Asiento == null)
            {
                return HttpNotFound();
            }
            return View(tb_Asiento);
        }

        // POST: tb_Asiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Asiento tb_Asiento = db.tb_Asiento.Find(id);
            db.tb_Asiento.Remove(tb_Asiento);
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
