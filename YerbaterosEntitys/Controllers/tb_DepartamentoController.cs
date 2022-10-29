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
    public class tb_DepartamentoController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_Departamento
        public ActionResult Index()
        {
            return View(db.tb_Departamento.ToList());
        }

        // GET: tb_Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Departamento tb_Departamento = db.tb_Departamento.Find(id);
            if (tb_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_Departamento);
        }

        // GET: tb_Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Departamento,Nombre_Departamento")] tb_Departamento tb_Departamento)
        {
            if (ModelState.IsValid)
            {
                db.tb_Departamento.Add(tb_Departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Departamento);
        }

        // GET: tb_Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Departamento tb_Departamento = db.tb_Departamento.Find(id);
            if (tb_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_Departamento);
        }

        // POST: tb_Departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Departamento,Nombre_Departamento")] tb_Departamento tb_Departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Departamento);
        }

        // GET: tb_Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Departamento tb_Departamento = db.tb_Departamento.Find(id);
            if (tb_Departamento == null)
            {
                return HttpNotFound();
            }
            return View(tb_Departamento);
        }

        // POST: tb_Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Departamento tb_Departamento = db.tb_Departamento.Find(id);
            db.tb_Departamento.Remove(tb_Departamento);
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
