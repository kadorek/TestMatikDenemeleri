using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMatik_V1.Models;

namespace TestMatik_V1.Controllers
{
    public class KonusController : Controller
    {
        private VerilerEntities db = new VerilerEntities();

        // GET: Konus
        public ActionResult Index()
        {
            var konus = db.Konus.Include(k => k.Der);
            return View(konus.ToList());
        }

        // GET: Konus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konu konu = db.Konus.Find(id);
            if (konu == null)
            {
                return HttpNotFound();
            }
            return View(konu);
        }

        // GET: Konus/Create
        public ActionResult Create()
        {
            ViewBag.DersId = new SelectList(db.Ders, "Id", "Ad");
            return View();
        }

        // POST: Konus/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,DersId")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                db.Konus.Add(konu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DersId = new SelectList(db.Ders, "Id", "Ad", konu.DersId);
            return View(konu);
        }

        // GET: Konus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konu konu = db.Konus.Find(id);
            if (konu == null)
            {
                return HttpNotFound();
            }
            ViewBag.DersId = new SelectList(db.Ders, "Id", "Ad", konu.DersId);
            return View(konu);
        }

        // POST: Konus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,DersId")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DersId = new SelectList(db.Ders, "Id", "Ad", konu.DersId);
            return View(konu);
        }

        // GET: Konus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konu konu = db.Konus.Find(id);
            if (konu == null)
            {
                return HttpNotFound();
            }
            return View(konu);
        }

        // POST: Konus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Konu konu = db.Konus.Find(id);
            db.Konus.Remove(konu);
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
