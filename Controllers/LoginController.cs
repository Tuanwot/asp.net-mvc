using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignmentv2.Models;

namespace assignmentv2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Account account)
        {
            using (DBcontext db = new DBcontext())
            {

                var check = db.Accounts.Where(x => x.Username == account.Username && x.Password == account.Password).FirstOrDefault();

                if (check == null)
                {

                    return RedirectToAction("About", "Home", account);

                }
                //get role

                string role = (from x in db.Accounts
                             join y in db.Roles
                             on x.RoleId equals y.RoleId
                             where x.Username == account.Username && x.Password == account.Password
                             select y.Description).FirstOrDefault();
                int Id = (from accountid in db.Accounts
                          where accountid.Username == account.Username && accountid.Password == account.Password
                          select accountid.AccountId).FirstOrDefault();
                Session["ID"] = Id;
                Session["Username"] = account.Username;
                Session["Role"] = role;
                
                return RedirectToAction("Index", "Home", ViewData["username"]);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}