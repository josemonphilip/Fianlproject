using rc.Domain;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rc.UserInterface.MVC.Controllers
{
    [Authorize]
    public class WardController : Controller
    {
        private IWardService _wardService;
        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }
        // GET: Ward
        public ActionResult Index()
        {
            return View(_wardService.GetAllWardsForCustomer((int)Session["CustID"]));
        }

        // GET: Ward/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ward/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ward/Create
        [HttpPost]
        public ActionResult Create(Ward ward)
        {
            // try
            // {
            // TODO: Add insert logic here
            ward.CustomerID = (int)Session["CustID"];
            _wardService.CreateWard(ward);
            return RedirectToAction("Index");
            //// }
            // catch
            // {
            //    return View();
            // }
        }

        // GET: Ward/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_wardService.GetWardByID(id,(int)Session["CustID"]));
        }

        // POST: Ward/Edit/5
        [HttpPost]
        public ActionResult Edit(Ward collection)
        {
            try
            {
                // TODO: Add update logic here
                _wardService.UpdateWard(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ward/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ward/Delete/5
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
