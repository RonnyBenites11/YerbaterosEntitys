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
    public class tb_BusController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Bus
        public ActionResult Index()
        {
            return View(db.tb_Bus.ToList());
        }

        // GET: tb_Bus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Bus tb_Bus = db.tb_Bus.Find(id);
            if (tb_Bus == null)
            {
                return HttpNotFound();
            }
            return View(tb_Bus);
        }

        // GET: tb_Bus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Bus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Bus,Registro,Cantidad_Asientos,Marca,Modelo")] tb_Bus tb_Bus)
        {
            if (ModelState.IsValid)
            {
                db.tb_Bus.Add(tb_Bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Bus);
        }

        // GET: tb_Bus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Bus tb_Bus = db.tb_Bus.Find(id);
            if (tb_Bus == null)
            {
                return HttpNotFound();
            }
            return View(tb_Bus);
        }

        // POST: tb_Bus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Bus,Registro,Cantidad_Asientos,Marca,Modelo")] tb_Bus tb_Bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Bus);
        }

        // GET: tb_Bus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Bus tb_Bus = db.tb_Bus.Find(id);
            if (tb_Bus == null)
            {
                return HttpNotFound();
            }
            return View(tb_Bus);
        }

        // POST: tb_Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Bus tb_Bus = db.tb_Bus.Find(id);
            db.tb_Bus.Remove(tb_Bus);
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
