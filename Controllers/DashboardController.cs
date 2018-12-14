using AccountManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AccountManagment.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

       
      


        public ActionResult Details(int? id)
        {
            AccountManagmentEntities3 db = new AccountManagmentEntities3();
            return View(db.UserAccounts.ToList());
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser([Bind(Include = "UserID,UserName,AccountNo,ACopenDate,AccountBalance,Email,PhoneNumber,Comments")] UserAccount userAccount)
        {
            AccountManagmentEntities3 db = new AccountManagmentEntities3();
            if (ModelState.IsValid)
            {
                db.UserAccounts.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }


        public ActionResult DeleteUser(int? id)
        {
            AccountManagmentEntities3 db = new AccountManagmentEntities3();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);


        }
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountManagmentEntities3 db = new AccountManagmentEntities3();

            UserAccount userAccount = db.UserAccounts.Find(id);
            db.UserAccounts.Remove(userAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            AccountManagmentEntities3 db = new AccountManagmentEntities3();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}