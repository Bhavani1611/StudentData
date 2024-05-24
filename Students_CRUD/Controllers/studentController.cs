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
    public class studentController : Controller
    {
        private StudentGradeEntities db = new StudentGradeEntities();

        //public ActionResult Index()
        //{
        //    var students = db.mst_student.Include(m => m.mst_subject)
        //        .Where(s => s.grade >= 70)
        //        .ToList();
        //    foreach (var student in students)
        //    {
        //        student.Remarks = studentController.CalculateRemark(student.grade);
        //    }
        //    return View(students);//
        //}
        public ActionResult Index()
        {
            var mst_student = db.mst_student.Include(m => m.mst_subject);
            return View(mst_student.ToList());
        }

        [HttpGet]
        public ActionResult Index(string SearchBy, string Search)
        {
            if(SearchBy == "Student_name")
            {
                return View(db.mst_student.Where(x => x.Student_name.StartsWith(Search) || Search == null).ToList());
            }
            return View(db.mst_student.Where(x => x.Remarks == Search || Search == null).ToList());
        }

        //public ActionResult Index(mst_student ms)
        //{
        //    if(ms.grade > 60)
        //    {
        //        ms.Remarks = "Pass";
        //    }
        //    else
        //    {
        //        ms.Remarks = "Fail";
        //    }
        //    return View(ms);
        //}

        

        // GET: student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_student mst_student = db.mst_student.Find(id);
            if (mst_student == null)
            {
                return HttpNotFound();
            }
            return View(mst_student);
        }

        // GET: student/Create
        public ActionResult Create()
        {
            ViewBag.Subject_key = new SelectList(db.mst_subject, "Subject_key", "subject_name");
            return View();
        }

        // POST: student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_key,Student_name,Subject_key,grade,Remarks")] mst_student mst_student)
        {
            if (ModelState.IsValid)
            {
                db.mst_student.Add(mst_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Subject_key = new SelectList(db.mst_subject, "Subject_key", "subject_name", mst_student.Subject_key);
            return View(mst_student);
        }

        //[HttpPost]
        //public ActionResult Create(mst_student student)
        //{

        //}

        // GET: student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_student mst_student = db.mst_student.Find(id);
            if (mst_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_key = new SelectList(db.mst_subject, "Subject_key", "subject_name", mst_student.Subject_key);
            return View(mst_student);
        }

        // POST: student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_key,Student_name,Subject_key,grade,Remarks")] mst_student mst_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subject_key = new SelectList(db.mst_subject, "Subject_key", "subject_name", mst_student.Subject_key);
            return View(mst_student);
        }

        // GET: student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mst_student mst_student = db.mst_student.Find(id);
            if (mst_student == null)
            {
                return HttpNotFound();
            }
            return View(mst_student);
        }

        // POST: student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mst_student mst_student = db.mst_student.Find(id);
            db.mst_student.Remove(mst_student);
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
