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
    public class tb_TerminalTerrestreController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_TerminalTerrestre
        public ActionResult Index()
        {
            var tb_TerminalTerrestre = db.tb_TerminalTerrestre.Include(t => t.tb_Departamento);
            return View(tb_TerminalTerrestre.ToList());
        }

        // GET: tb_TerminalTerrestre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TerminalTerrestre tb_TerminalTerrestre = db.tb_TerminalTerrestre.Find(id);
            if (tb_TerminalTerrestre == null)
            {
                return HttpNotFound();
            }
            return View(tb_TerminalTerrestre);
        }

        // GET: tb_TerminalTerrestre/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Departamento = new SelectList(db.tb_Departamento, "Cod_Departamento", "Nombre_Departamento");
            return View();
        }

        // POST: tb_TerminalTerrestre/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Terminal,Nombre_Terminal,Cod_Departamento")] tb_TerminalTerrestre tb_TerminalTerrestre)
        {
            if (ModelState.IsValid)
            {
                db.tb_TerminalTerrestre.Add(tb_TerminalTerrestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Departamento = new SelectList(db.tb_Departamento, "Cod_Departamento", "Nombre_Departamento", tb_TerminalTerrestre.Cod_Departamento);
            return View(tb_TerminalTerrestre);
        }

        // GET: tb_TerminalTerrestre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TerminalTerrestre tb_TerminalTerrestre = db.tb_TerminalTerrestre.Find(id);
            if (tb_TerminalTerrestre == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Departamento = new SelectList(db.tb_Departamento, "Cod_Departamento", "Nombre_Departamento", tb_TerminalTerrestre.Cod_Departamento);
            return View(tb_TerminalTerrestre);
        }

        // POST: tb_TerminalTerrestre/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Terminal,Nombre_Terminal,Cod_Departamento")] tb_TerminalTerrestre tb_TerminalTerrestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_TerminalTerrestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Departamento = new SelectList(db.tb_Departamento, "Cod_Departamento", "Nombre_Departamento", tb_TerminalTerrestre.Cod_Departamento);
            return View(tb_TerminalTerrestre);
        }

        // GET: tb_TerminalTerrestre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TerminalTerrestre tb_TerminalTerrestre = db.tb_TerminalTerrestre.Find(id);
            if (tb_TerminalTerrestre == null)
            {
                return HttpNotFound();
            }
            return View(tb_TerminalTerrestre);
        }

        // POST: tb_TerminalTerrestre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_TerminalTerrestre tb_TerminalTerrestre = db.tb_TerminalTerrestre.Find(id);
            db.tb_TerminalTerrestre.Remove(tb_TerminalTerrestre);
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
