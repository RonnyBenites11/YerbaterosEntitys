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
    public class tb_ClienteController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Cliente
        public ActionResult Index()
        {
            var tb_Cliente = db.tb_Cliente.Include(t => t.tb_TipoDoc).Include(t => t.tb_Usuario);
            return View(tb_Cliente.ToList());
        }

        // GET: tb_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cliente tb_Cliente = db.tb_Cliente.Find(id);
            if (tb_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tb_Cliente);
        }

        // GET: tb_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.Cod_TipoDoc = new SelectList(db.tb_TipoDoc, "Cod_TipoDoc", "Descripcion_TipoDoc");
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario");
            return View();
        }

        // POST: tb_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodNro_Cliente,Cod_TipoDoc,Nombres_Cliente,Apellidos_Cliente,Cod_Usuario")] tb_Cliente tb_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.tb_Cliente.Add(tb_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_TipoDoc = new SelectList(db.tb_TipoDoc, "Cod_TipoDoc", "Descripcion_TipoDoc", tb_Cliente.Cod_TipoDoc);
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_Cliente.Cod_Usuario);
            return View(tb_Cliente);
        }

        // GET: tb_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cliente tb_Cliente = db.tb_Cliente.Find(id);
            if (tb_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_TipoDoc = new SelectList(db.tb_TipoDoc, "Cod_TipoDoc", "Descripcion_TipoDoc", tb_Cliente.Cod_TipoDoc);
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_Cliente.Cod_Usuario);
            return View(tb_Cliente);
        }

        // POST: tb_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodNro_Cliente,Cod_TipoDoc,Nombres_Cliente,Apellidos_Cliente,Cod_Usuario")] tb_Cliente tb_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_TipoDoc = new SelectList(db.tb_TipoDoc, "Cod_TipoDoc", "Descripcion_TipoDoc", tb_Cliente.Cod_TipoDoc);
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_Cliente.Cod_Usuario);
            return View(tb_Cliente);
        }

        // GET: tb_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cliente tb_Cliente = db.tb_Cliente.Find(id);
            if (tb_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tb_Cliente);
        }

        // POST: tb_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Cliente tb_Cliente = db.tb_Cliente.Find(id);
            db.tb_Cliente.Remove(tb_Cliente);
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
