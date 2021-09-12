using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignmentv2.Models;

namespace assignmentv2.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        DBcontext db = new DBcontext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.message = new SelectList(db.Roles, "RoleId", "Description");

            return View();
        }
            //create account
        public ActionResult CreateAccount(Account account)
        {
            using (DBcontext db = new DBcontext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            if ((string)Session["Role"] == "admin")
            {
                return RedirectToAction("TrainingTraineelist", "Manage");
            }
            else
            {
                return RedirectToAction("Traineelist", "Manage");
            }
            
        }

        //delete account
        public ActionResult Delete(int ID)
        {
            using (DBcontext db = new DBcontext())
            {
                var account = db.Accounts.Find(ID);
                db.Accounts.Remove(account);
                db.SaveChanges();
                return RedirectToAction("TrainingTraineelist","Manage");
            }
        }
        //show list users
        public ActionResult TrainingTraineelist()
        {
            
                var list = (from x in db.Accounts
                            join y in db.Roles
                            on x.RoleId equals y.RoleId
                            where y.Description == "trainer" || y.Description == "training"
                            select x).ToList();


 

            return View(list);
        }
        // list of trainee
        public ActionResult Traineelist()
        {
            var list = (from x in db.Accounts
                        join y in db.Roles
                        on x.RoleId equals y.RoleId
                        where y.Description == "student"
                        select x).ToList();
            return View(list);
        }
        //list of trainer
        public ActionResult TrainerList()
        {
            var list = (from x in db.Accounts
                        join y in db.Roles
                        on x.RoleId equals y.RoleId
                        where y.Description == "trainer"
                        select x).ToList();
            return View(list);
        }
        //edit account
        public ActionResult Edit(int ID)
        {
            var model = db.Accounts.Find(ID);
            return View(model);
        }
        public ActionResult EditAccount(Account person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TrainingTraineelist", "Manage");
        }
        //list of course
        public ActionResult ListOfCourse()
        {
            var list = (from x in db.courses
                        select x).ToList();
            return View(list);
        }
        // create course
        public ActionResult CreateCourse()
        {
            return View();
        }
        public ActionResult FuncCreateCourse(course course)
        {
            db.courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("ListOfCourse");
        }

        //list of category course
        public ActionResult ListOfCategoryCourse()
        {
            var list = (from x in db.CategoryCourses
                        select x).ToList();
            return View(list);
        }
        public ActionResult CreateCategoryCourse()
        {
            return View();
        }
        public ActionResult FuncCreateCategoryCourse(CategoryCourse categoryCourse)
        {
            db.CategoryCourses.Add(categoryCourse);
            db.SaveChanges();
            return RedirectToAction("ListOfCategoryCourse");
        }
    }
}