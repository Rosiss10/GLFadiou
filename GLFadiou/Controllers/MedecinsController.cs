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
    public class MedecinsController : Controller
    {
        private GlFadiouContext db = new GlFadiouContext();

        // GET: Medecins
        public ActionResult Index()
        {
            return View(ListeMedicin().ToList());
        }

        // GET: Medecins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = ListeMedicin().Where(a=>a.idPers==id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        // GET: Medecins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medecins/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialiteMed")] MedecinViewModel m)
        {
            if (ModelState.IsValid)
            {
                Personne p = new Personne();
                p.adressePers = m.adressePers;
                p.cniPers = m.cniPers;
                p.dateNaissancePers = m.dateNaissancePers;
                p.emailPers = m.emailPers;
                p.nomPers = m.nomPers;
                p.prenomPers = m.prenomPers;
                p.sexePers = m.sexePers;
                p.situationMatPers = m.situationMatPers;
                p.telPers = m.telPers;
                db.Personnes.Add(p);
                db.SaveChanges();
                Medecin mm = new Medecin();
                mm.idMed = p.idPers;
                mm.specialiteMed = m.specialiteMed;
                db.Medecins.Add(mm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m);
        }

        // GET: Medecins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = ListeMedicin().Where(a => a.idPers == id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        // POST: Medecins/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPers,nomPers,prenomPers,adressePers,dateNaissancePers,sexePers,cniPers,situationMatPers,emailPers,telPers,specialiteMed")] MedecinViewModel medecinViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medecinViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medecinViewModel);
        }

        // GET: Medecins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedecinViewModel medecinViewModel = ListeMedicin().Where(a => a.idPers == id).FirstOrDefault();
            if (medecinViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medecinViewModel);
        }

        // POST: Medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //MedecinViewModel medecinViewModel = db.MedecinViewModels.Find(id);
            //db.MedecinViewModels.Remove(medecinViewModel);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public List<MedecinViewModel> ListeMedicin()
        {
            List<MedecinViewModel> liste = new List<MedecinViewModel>();
            var lesMedecin = db.Medecins.ToList();
            foreach(var leMedcin in lesMedecin)
            {
                MedecinViewModel m = new MedecinViewModel();
                var p = db.Personnes.Find(leMedcin.idMed);
                m.idPers = leMedcin.idMed;
                m.nomPers = p.nomPers;
                m.prenomPers = p.prenomPers;
                m.adressePers = p.adressePers;
                m.cniPers = p.cniPers;
                m.dateNaissancePers = p.dateNaissancePers;
                m.emailPers = p.emailPers;
                m.sexePers = p.sexePers;
                m.situationMatPers = p.situationMatPers;
                m.telPers = p.telPers;
                m.specialiteMed = leMedcin.specialiteMed;
                liste.Add(m);
            }
            return liste;
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
