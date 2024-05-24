using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Students_CRUD.Models;

namespace Students_CRUD.Controllers
{
    public class subjectController : Controller
    {
        private StudentGradeEntities db = new StudentGradeEntities();

        // GET: subject
        public ActionResult Index()
        {
            return View(db.mst_subject.ToList());
        }

        // GET: subject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_subject mst_subject = db.mst_subject.Find(id);
            if (mst_subject == null)
            {
                return HttpNotFound();
            }
            return View(mst_subject);
        }

        // GET: subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subject_key,subject_name")] mst_subject mst_subject)
        {
            if (ModelState.IsValid)
            {
                db.mst_subject.Add(mst_subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mst_subject);
        }

        // GET: subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_subject mst_subject = db.mst_subject.Find(id);
            if (mst_subject == null)
            {
                return HttpNotFound();
            }
            return View(mst_subject);
        }

        // POST: subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subject_key,subject_name")] mst_subject mst_subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mst_subject);
        }

        // GET: subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_subject mst_subject = db.mst_subject.Find(id);
            if (mst_subject == null)
            {
                return HttpNotFound();
            }
            return View(mst_subject);
        }

        // POST: subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mst_subject mst_subject = db.mst_subject.Find(id);
            db.mst_subject.Remove(mst_subject);
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
