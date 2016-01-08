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
    public class GPController : Controller
    {
        private readonly IGPService _gpService;
        public GPController(IGPService gpService)
        {
            _gpService = gpService;
        }
        // GET: GP
        public ActionResult Index()
        {
            return View(_gpService.GetAllGpsByCustomerID((int)Session["CustId"]));
        }

        // GET: GP/Details/5
        public ActionResult Details(int id)
        {
            return View(_gpService.GetGpByID(id, (int)Session["CustId"]));
        }

        // GET: GP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GP/Create
        [HttpPost]
        public ActionResult Create(GeneralPractitioner collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.CustomerID = (int)Session["CustId"];
                _gpService.CreateGp(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GP/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_gpService.GetGpByID(id,(int)Session["CustId"]));
        }

        // POST: GP/Edit/5
        [HttpPost]
        public ActionResult Edit(GeneralPractitioner collection)
        {
            try
            {
                // TODO: Add update logic here
                _gpService.EditGp(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GP/Delete/5
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
