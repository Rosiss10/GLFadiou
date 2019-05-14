using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GLFadiou.Models;

namespace GLFadiou.Controllers
{
    public class ChambresController : Controller
    {
        private GlFadiouContext db = new GlFadiouContext();

        // GET: Chambres
        public ActionResult Index()
        {
            return View(db.Chambres.ToList());
        }

        // GET: Chambres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.Chambres.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // GET: Chambres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chambres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCh,codeCh,libelle")] Chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.Chambres.Add(chambre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chambre);
        }

        // GET: Chambres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.Chambres.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // POST: Chambres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCh,codeCh,libelle")] Chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chambre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chambre);
        }

        // GET: Chambres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.Chambres.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // POST: Chambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chambre chambre = db.Chambres.Find(id);
            db.Chambres.Remove(chambre);
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
