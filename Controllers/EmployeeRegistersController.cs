using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountManagment.Models;

namespace AccountManagment.Controllers
{
    public class EmployeeRegistersController : Controller
    {
        private AccountManagmentEntities4 db = new AccountManagmentEntities4();

        // GET: EmployeeRegisters
        public ActionResult Index()
        {
            return View(db.EmployeeRegisters.ToList());
        }

        // GET: EmployeeRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EID,FirstName,LastName,FatherName,MotherName,PresentAddress,PermanentAddress,SSC_Year,SSC_Result,SSc_Board,HSC_Year,HSC_Result,HSC_Board,Gradute_University,Passing_Year,Result,Grade,Salary_Scale,Commision_Percentage,Increment,Birth_Date,Gender,Married_or_Unmarried,Blood_Group,Religion,Nationality,Phone_Number,Email")] EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeRegisters.Add(employeeRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // POST: EmployeeRegisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EID,FirstName,LastName,FatherName,MotherName,PresentAddress,PermanentAddress,SSC_Year,SSC_Result,SSc_Board,HSC_Year,HSC_Result,HSC_Board,Gradute_University,Passing_Year,Result,Grade,Salary_Scale,Commision_Percentage,Increment,Birth_Date,Gender,Married_or_Unmarried,Blood_Group,Religion,Nationality,Phone_Number,Email")] EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // POST: EmployeeRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            db.EmployeeRegisters.Remove(employeeRegister);
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
