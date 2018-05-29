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
    public class SorusController : Controller
    {
        private VerilerEntities db = new VerilerEntities();

        // GET: Sorus
        public ActionResult Index()
        {
            var sorus = db.Sorus.Include(s => s.Konu);
            return View(sorus.ToList());
        }

        // GET: Sorus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        // GET: Sorus/Create
        public ActionResult Create()
        {
            ViewBag.KonuId = new SelectList(db.Konus, "Id", "Ad");
            return View();
        }

        // POST: Sorus/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Metin,EkMetin,KonuId,Seviye")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                db.Sorus.Add(soru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KonuId = new SelectList(db.Konus, "Id", "Ad", soru.KonuId);
            return View(soru);
        }

        // GET: Sorus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            ViewBag.KonuId = new SelectList(db.Konus, "Id", "Ad", soru.KonuId);
            return View(soru);
        }

        // POST: Sorus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Metin,EkMetin,KonuId,Seviye")] Soru soru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KonuId = new SelectList(db.Konus, "Id", "Ad", soru.KonuId);
            return View(soru);
        }

        // GET: Sorus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soru soru = db.Sorus.Find(id);
            if (soru == null)
            {
                return HttpNotFound();
            }
            return View(soru);
        }

        // POST: Sorus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soru soru = db.Sorus.Find(id);
            db.Sorus.Remove(soru);
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
