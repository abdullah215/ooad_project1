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
    public class RegistrationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Reistrations
        public ActionResult Index()
        {
            var Registration = db.Registrations.Include(r => r.Batch).Include(r => r.Course).Include(r => r.Registrations);
            return View(Registration);//.ToList());
        }

        // GET: Reistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration Registration = db.Registrations.Find(id);
            if (Registration == null)
            {
                return HttpNotFound();
            }
            return View(Registration);
        }

        // GET: Reistrations/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1");
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1");
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname");
            return View();
        }

        // POST: Reistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] Registration Registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", Registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", Registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", Registration.id);
            return View(Registration);
        }

        // GET: Reistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration Registration = db.Registrations.Find(id);
            if (Registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", Registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", Registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", Registration.id);
            return View(Registration);
        }

        // POST: Reistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] Registration Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", Registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", Registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", Registration.id);
            return View(Registration);
        }

        // GET: Reistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration Registration = db.Registrations.Find(id);
            if (Registration == null)
            {
                return HttpNotFound();
            }
            return View(Registration);
        }

        // POST: Reistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration Registration = db.Registrations.Find(id);
            db.Registrations.Remove(Registration);
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
