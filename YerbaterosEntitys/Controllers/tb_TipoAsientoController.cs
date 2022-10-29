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
    public class tb_TipoAsientoController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_TipoAsiento
        public ActionResult Index()
        {
            return View(db.tb_TipoAsiento.ToList());
        }

        // GET: tb_TipoAsiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoAsiento tb_TipoAsiento = db.tb_TipoAsiento.Find(id);
            if (tb_TipoAsiento == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoAsiento);
        }

        // GET: tb_TipoAsiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_TipoAsiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Tipo_Asiento,Tipo_ASiento")] tb_TipoAsiento tb_TipoAsiento)
        {
            if (ModelState.IsValid)
            {
                db.tb_TipoAsiento.Add(tb_TipoAsiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_TipoAsiento);
        }

        // GET: tb_TipoAsiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoAsiento tb_TipoAsiento = db.tb_TipoAsiento.Find(id);
            if (tb_TipoAsiento == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoAsiento);
        }

        // POST: tb_TipoAsiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Tipo_Asiento,Tipo_ASiento")] tb_TipoAsiento tb_TipoAsiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_TipoAsiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_TipoAsiento);
        }

        // GET: tb_TipoAsiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoAsiento tb_TipoAsiento = db.tb_TipoAsiento.Find(id);
            if (tb_TipoAsiento == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoAsiento);
        }

        // POST: tb_TipoAsiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_TipoAsiento tb_TipoAsiento = db.tb_TipoAsiento.Find(id);
            db.tb_TipoAsiento.Remove(tb_TipoAsiento);
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
