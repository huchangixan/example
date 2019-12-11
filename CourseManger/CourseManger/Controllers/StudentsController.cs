using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManger.Models;

namespace CourseManger.Controllers
{
    public class StudentsController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /Students/Details/5

        public ActionResult Details(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // GET: /Students/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Students/Create

        [HttpPost]
        public ActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        //
        // GET: /Students/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /Students/Edit/5

        [HttpPost]
        public ActionResult Edit(Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        //
        // GET: /Students/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /Students/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}