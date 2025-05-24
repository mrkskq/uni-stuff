using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaccinationApp.Models;

namespace VaccinationApp.Controllers
{
    [Authorize]
    public class VaccinationCentersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VaccinationCenters
        public ActionResult Index()
        {
            return View(db.VaccinationCenters.ToList());
        }

        [Authorize(Roles = "Doctor")]
        // GET: VaccinationCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        [Authorize(Roles = "Doctor")]
        // GET: VaccinationCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,MaxCapacity")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.VaccinationCenters.Add(vaccinationCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccinationCenter);
        }


        [Authorize(Roles = "Doctor")]
        public ActionResult AddPatient(int id)
        {
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.VaccinationCenterId = vaccinationCenter.Id;
            ViewBag.VaccinationCenterName = vaccinationCenter.Name;
            ViewBag.Patients = new SelectList(db.Patients.ToList(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPatient(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(vaccine.VaccinationCenterId);
                vaccinationCenter.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("Details", new {id = vaccine.VaccinationCenterId});
            }
            return View(vaccine);
        }



        [Authorize(Roles = "Doctor")]

        // GET: VaccinationCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,MaxCapacity")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinationCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccinationCenter);
        }

        [Authorize(Roles = "Doctor")]

        // GET: VaccinationCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            db.VaccinationCenters.Remove(vaccinationCenter);
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
