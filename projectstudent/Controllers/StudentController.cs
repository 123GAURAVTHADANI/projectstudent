using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using projectstudent.Models;
namespace projectstudent.Controllers
{
    public class StudentController : Controller
    {
        private masterEntities2 db = new masterEntities2();
        // GET: Student
        public ActionResult Index(string search,int? page)
        { 
                return View(db.studentnews.Where(x => x.Subject == search || search == null).ToList().ToPagedList(page ?? 1,3));
        }
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(studentnew std1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.studentnews.Add(std1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(std1);
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, studentnew std1)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(std1).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(std1);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,studentnew std1)
        {
            try
            {
                std1 = db.studentnews.Find(id);
                db.studentnews.Remove(std1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
