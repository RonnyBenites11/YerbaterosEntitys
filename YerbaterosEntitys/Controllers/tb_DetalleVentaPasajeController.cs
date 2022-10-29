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
    public class tb_DetalleVentaPasajeController : Controller
    {
        private ProyectoDSW_202202_2Entities db = new ProyectoDSW_202202_2Entities();

        // GET: tb_DetalleVentaPasaje
        public ActionResult Index()
        {
            var tb_DetalleVentaPasaje = db.tb_DetalleVentaPasaje.Include(t => t.tb_Asiento).Include(t => t.tb_Cliente).Include(t => t.tb_VentaPasaje).Include(t => t.tb_Viaje);
            return View(tb_DetalleVentaPasaje.ToList());
        }

        // GET: tb_DetalleVentaPasaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DetalleVentaPasaje tb_DetalleVentaPasaje = db.tb_DetalleVentaPasaje.Find(id);
            if (tb_DetalleVentaPasaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_DetalleVentaPasaje);
        }

        // GET: tb_DetalleVentaPasaje/Create
        public ActionResult Create()
        {
            ViewBag.Cod_Asiento = new SelectList(db.tb_Asiento, "Cod_Asiento", "Alias_Asiento");
            ViewBag.CodNro_Cliente = new SelectList(db.tb_Cliente, "CodNro_Cliente", "Nombres_Cliente");
            ViewBag.Id_Venta = new SelectList(db.tb_VentaPasaje, "Id", "Id");
            ViewBag.Cod_Viaje = new SelectList(db.tb_Viaje, "Cod_Viaje", "Cod_Viaje");
            return View();
        }

        // POST: tb_DetalleVentaPasaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Venta,Cod_Viaje,CodNro_Cliente,Cod_Asiento,Voucher,Costo_Ticket,Descuento,Sub_total")] tb_DetalleVentaPasaje tb_DetalleVentaPasaje)
        {
            if (ModelState.IsValid)
            {
                db.tb_DetalleVentaPasaje.Add(tb_DetalleVentaPasaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cod_Asiento = new SelectList(db.tb_Asiento, "Cod_Asiento", "Alias_Asiento", tb_DetalleVentaPasaje.Cod_Asiento);
            ViewBag.CodNro_Cliente = new SelectList(db.tb_Cliente, "CodNro_Cliente", "Nombres_Cliente", tb_DetalleVentaPasaje.CodNro_Cliente);
            ViewBag.Id_Venta = new SelectList(db.tb_VentaPasaje, "Id", "Id", tb_DetalleVentaPasaje.Id_Venta);
            ViewBag.Cod_Viaje = new SelectList(db.tb_Viaje, "Cod_Viaje", "Cod_Viaje", tb_DetalleVentaPasaje.Cod_Viaje);
            return View(tb_DetalleVentaPasaje);
        }

        // GET: tb_DetalleVentaPasaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DetalleVentaPasaje tb_DetalleVentaPasaje = db.tb_DetalleVentaPasaje.Find(id);
            if (tb_DetalleVentaPasaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cod_Asiento = new SelectList(db.tb_Asiento, "Cod_Asiento", "Alias_Asiento", tb_DetalleVentaPasaje.Cod_Asiento);
            ViewBag.CodNro_Cliente = new SelectList(db.tb_Cliente, "CodNro_Cliente", "Nombres_Cliente", tb_DetalleVentaPasaje.CodNro_Cliente);
            ViewBag.Id_Venta = new SelectList(db.tb_VentaPasaje, "Id", "Id", tb_DetalleVentaPasaje.Id_Venta);
            ViewBag.Cod_Viaje = new SelectList(db.tb_Viaje, "Cod_Viaje", "Cod_Viaje", tb_DetalleVentaPasaje.Cod_Viaje);
            return View(tb_DetalleVentaPasaje);
        }

        // POST: tb_DetalleVentaPasaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Venta,Cod_Viaje,CodNro_Cliente,Cod_Asiento,Voucher,Costo_Ticket,Descuento,Sub_total")] tb_DetalleVentaPasaje tb_DetalleVentaPasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DetalleVentaPasaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cod_Asiento = new SelectList(db.tb_Asiento, "Cod_Asiento", "Alias_Asiento", tb_DetalleVentaPasaje.Cod_Asiento);
            ViewBag.CodNro_Cliente = new SelectList(db.tb_Cliente, "CodNro_Cliente", "Nombres_Cliente", tb_DetalleVentaPasaje.CodNro_Cliente);
            ViewBag.Id_Venta = new SelectList(db.tb_VentaPasaje, "Id", "Id", tb_DetalleVentaPasaje.Id_Venta);
            ViewBag.Cod_Viaje = new SelectList(db.tb_Viaje, "Cod_Viaje", "Cod_Viaje", tb_DetalleVentaPasaje.Cod_Viaje);
            return View(tb_DetalleVentaPasaje);
        }

        // GET: tb_DetalleVentaPasaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DetalleVentaPasaje tb_DetalleVentaPasaje = db.tb_DetalleVentaPasaje.Find(id);
            if (tb_DetalleVentaPasaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_DetalleVentaPasaje);
        }

        // POST: tb_DetalleVentaPasaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DetalleVentaPasaje tb_DetalleVentaPasaje = db.tb_DetalleVentaPasaje.Find(id);
            db.tb_DetalleVentaPasaje.Remove(tb_DetalleVentaPasaje);
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
