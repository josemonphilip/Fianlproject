using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rc.UserInterface.MVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IStaffProfileService _staffProfile;
        private readonly IPatientAppointmentService _appointments;
        public EmployeeController(IStaffProfileService staffProfile, IPatientAppointmentService appointments)
        {
            _staffProfile = staffProfile;
            _appointments = appointments;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View(_staffProfile.GetAllStaff((int)Session["CustId"]));
        }

        public ActionResult Dashboard()
        {

            return View(_appointments.ListTodaysAppoinment((int)Session["CustId"]));
        }

        public ActionResult StaffDirectory()
        {
            return View(_staffProfile.GetAllStaff((int)Session["CustId"]));
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
