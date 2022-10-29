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
    public class tb_VentaPasajeController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_VentaPasaje
        public ActionResult Index()
        {
            var tb_VentaPasaje = db.tb_VentaPasaje.Include(t => t.tb_Usuario).Include(t => t.tb_DetalleVentaPasaje);
            return View(tb_VentaPasaje.ToList());
        }

        // GET: tb_VentaPasaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VentaPasaje tb_VentaPasaje = db.tb_VentaPasaje.Find(id);
            if (tb_VentaPasaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_VentaPasaje);
        }

        // GET: tb_VentaPasaje/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario");
            ViewBag.Id = new SelectList(db.tb_DetalleVentaPasaje, "Id_Venta", "Voucher");
            return View();
        }

        // POST: tb_VentaPasaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Usuario,Fecha_Venta,Monto_Total")] tb_VentaPasaje tb_VentaPasaje)
        {
            if (ModelState.IsValid)
            {
                db.tb_VentaPasaje.Add(tb_VentaPasaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_VentaPasaje.Cod_Usuario);
            ViewBag.Id = new SelectList(db.tb_DetalleVentaPasaje, "Id_Venta", "Voucher", tb_VentaPasaje.Id);
            return View(tb_VentaPasaje);
        }

        // GET: tb_VentaPasaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VentaPasaje tb_VentaPasaje = db.tb_VentaPasaje.Find(id);
            if (tb_VentaPasaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_VentaPasaje.Cod_Usuario);
            ViewBag.Id = new SelectList(db.tb_DetalleVentaPasaje, "Id_Venta", "Voucher", tb_VentaPasaje.Id);
            return View(tb_VentaPasaje);
        }

        // POST: tb_VentaPasaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Usuario,Fecha_Venta,Monto_Total")] tb_VentaPasaje tb_VentaPasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_VentaPasaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Usuario = new SelectList(db.tb_Usuario, "Cod_Usuario", "Correo_Usuario", tb_VentaPasaje.Cod_Usuario);
            ViewBag.Id = new SelectList(db.tb_DetalleVentaPasaje, "Id_Venta", "Voucher", tb_VentaPasaje.Id);
            return View(tb_VentaPasaje);
        }

        // GET: tb_VentaPasaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VentaPasaje tb_VentaPasaje = db.tb_VentaPasaje.Find(id);
            if (tb_VentaPasaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_VentaPasaje);
        }

        // POST: tb_VentaPasaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_VentaPasaje tb_VentaPasaje = db.tb_VentaPasaje.Find(id);
            db.tb_VentaPasaje.Remove(tb_VentaPasaje);
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
