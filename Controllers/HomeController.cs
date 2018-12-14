using AccountManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountManagment.Controllers
{
    public class HomeController : Controller
    {

        private AccountManagmentEntities2 db = new AccountManagmentEntities2();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,EmailID,Password")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetail);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(userDetail);
        }


        public ActionResult Autherize(AccountManagment.Models.UserDetail userModel)
        {
            using (AccountManagmentEntities2 db = new AccountManagmentEntities2())
            {
                var userDetails = db.UserDetails.Where(x => x.FirstName == userModel.FirstName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username OR Password,Please Sign Up First or use Forget Password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    Session["userName"] = userDetails.FirstName;
                    return RedirectToAction("Index", "Dashboard");
                }
            }

        }
    }
}
