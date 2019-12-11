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
    public class CourseMangementsController : Controller
    {
        private CourseMangeEntities db = new CourseMangeEntities();

        //
        // GET: /CourseMangements/

        public ActionResult Index()
        {
            return View(db.CourseMangements.ToList());
        }

        //
        // GET: /CourseMangements/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseMangements coursemangements = db.CourseMangements.Find(id);
            if (coursemangements == null)
            {
                return HttpNotFound();
            }
            return View(coursemangements);
        }

        //
        // GET: /CourseMangements/Create

        public ActionResult Create()
        {
            var classes = db.Classes.ToList();
            ViewBag.Classes = classes;

            var teachers = db.Teachers.ToList();
            ViewBag.Teachers = teachers;

            var course =db.Course.ToList();
            ViewBag.Courses = course;
            return View();
        }

        //
        // POST: /CourseMangements/Create

        [HttpPost]
        public ActionResult Create(CourseMangements coursemangements)
        {
            if (ModelState.IsValid)
            {
                db.CourseMangements.Add(coursemangements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemangements);
        }

        //
        // GET: /CourseMangements/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CourseMangements coursemangements = db.CourseMangements.Find(id);
            if (coursemangements == null)
            {
                return HttpNotFound();
            }
            return View(coursemangements);
        }

        //
        // POST: /CourseMangements/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseMangements coursemangements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemangements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemangements);
        }

        //
        // GET: /CourseMangements/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseMangements coursemangements = db.CourseMangements.Find(id);
            if (coursemangements == null)
            {
                return HttpNotFound();
            }
            return View(coursemangements);
        }

        //
        // POST: /CourseMangements/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseMangements coursemangements = db.CourseMangements.Find(id);
            db.CourseMangements.Remove(coursemangements);
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