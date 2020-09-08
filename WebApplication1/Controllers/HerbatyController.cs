using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HerbatyController : Controller
    {
        private HerbataDBContext db = new HerbataDBContext();

        // GET: Herbaty
        public ActionResult Index()
        {
            return View(db.Herbaty.ToList());
        }

        // GET: Herbaty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerbatyModel herbatyModel = db.Herbaty.Find(id);
            if (herbatyModel == null)
            {
                return HttpNotFound();
            }
            return View(herbatyModel);
        }

        // GET: Herbaty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herbaty/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Cena,Zdjęcie")] HerbatyModel herbatyModel)
        {
            if (ModelState.IsValid)
            {
                db.Herbaty.Add(herbatyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herbatyModel);
        }

        // GET: Herbaty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerbatyModel herbatyModel = db.Herbaty.Find(id);
            if (herbatyModel == null)
            {
                return HttpNotFound();
            }
            return View(herbatyModel);
        }

        // POST: Herbaty/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Cena,Zdjęcie")] HerbatyModel herbatyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herbatyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herbatyModel);
        }

        // GET: Herbaty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerbatyModel herbatyModel = db.Herbaty.Find(id);
            if (herbatyModel == null)
            {
                return HttpNotFound();
            }
            return View(herbatyModel);
        }

        // POST: Herbaty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HerbatyModel herbatyModel = db.Herbaty.Find(id);
            db.Herbaty.Remove(herbatyModel);
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
