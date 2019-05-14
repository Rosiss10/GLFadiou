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
    public class LitsController : Controller
    {
        private GlFadiouContext db = new GlFadiouContext();

        // GET: Lits
        public ActionResult Index()
        {
            var lits = db.Lits.Include(l => l.chambre);
            return View(lits.ToList());
        }

        // GET: Lits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.Lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            return View(lit);
        }

        // GET: Lits/Create
        public ActionResult Create()
        {
            ViewBag.idChambre = new SelectList(db.Chambres, "idCh", "libelle");
            return View();
        }

        // POST: Lits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLit,codeLit,idChambre")] Lit lit)
        {
            if (ModelState.IsValid)
            {
                db.Lits.Add(lit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChambre = new SelectList(db.Chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // GET: Lits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.Lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChambre = new SelectList(db.Chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // POST: Lits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLit,codeLit,idChambre")] Lit lit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChambre = new SelectList(db.Chambres, "idCh", "codeCh", lit.idChambre);
            return View(lit);
        }

        // GET: Lits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lit lit = db.Lits.Find(id);
            if (lit == null)
            {
                return HttpNotFound();
            }
            return View(lit);
        }

        // POST: Lits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lit lit = db.Lits.Find(id);
            db.Lits.Remove(lit);
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
