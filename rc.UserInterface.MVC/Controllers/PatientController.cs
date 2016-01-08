using rc.Domain;
using rc.Domain.ViewModel;
using rc.ServiceLayer;
using rc.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace rc.UserInterface.MVC.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private IGPService _GPService;
        private IWardService _ward;
        private IPatientService _patientService;
        private IPatientDailyDiaryService _patientDailyDiaryService;
        private ICarePlanService _carePlan;
        private IPatientVitalSignService _patientVital;
        private IAssesmentQuestionService _assesment;
        private IPatientAppointmentService _appointment;

        public PatientController(IGPService GPService, IWardService ward, IPatientService patientService,
                                IPatientDailyDiaryService patientDailyDiaryService, ICarePlanService carePlan,
                                IPatientVitalSignService patientVital, IAssesmentQuestionService assesment,
                                IPatientAppointmentService appointment)
        {
            this._GPService = GPService;
            this._ward = ward;
            this._patientService = patientService;
            this._patientDailyDiaryService = patientDailyDiaryService;
            this._carePlan = carePlan;
            _patientVital = patientVital;
            _assesment = assesment;
            _appointment = appointment;
        }
        // GET: PatientAdmission
        public ActionResult Index(int id)
        {
            Session["PatientID"] = id;
            return View(_patientService.getPatientDetailsById(id));

        }
        // GET: PatientAdmission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult PatientList()
        {
            return View(_patientService.GetPatientList((int)Session["CustID"]));
        }

        // GET: PatientAdmission/Create
        public ActionResult Admission()
        {
            ViewBag.AdmissionType = new SelectList(new[]{
                new SelectListItem{Text="PRIVATE",Value="PRIVATE"},
                new SelectListItem{Text="CONVALESCING",Value="CONVALESCING"}
            }, "Text", "Value", "PRIVATE");

            ViewBag.Sex = new SelectList(new[]{
                new SelectListItem{Text="MALE",Value="MALE"},
                new SelectListItem{Text="FEMALE",Value="FEMALE"}
            }, "Text", "Value", "MALE");

            ViewBag.MartialStatus = new SelectList(new[]{
                new SelectListItem{Text="SINGLE",Value="SINGLE"},
                new SelectListItem{Text="MARRIED",Value="MARRIED"},
                 new SelectListItem{Text="DIVORCED",Value="DIVORCED"},
                 new SelectListItem{Text="WIDOW",Value="WIDOW"}
            }, "Text", "Value", "MARRIED");

            ViewBag.GeneralPractitionerID = _GPService.GetAllGpsByCustomerID((int)Session["CustID"]).Select(g => new SelectListItem { Text = g.FirstName, Value = g.GeneralPractitionerID.ToString() });
            ViewBag.WardID = _ward.GetAllWardsForCustomer((int)Session["CustID"]).Select(w => new SelectListItem { Text = w.Description, Value = w.WardID.ToString() });
            return View();
        }

        // POST: PatientAdmission/Create
        [HttpPost]
        public ActionResult Admission(PatientAdmission patientAdmission)
        {
            //try
            //{
            // TODO: Add insert logic here
            patientAdmission.CustomerID =(int)Session["CustID"];
            var doc = Request.Files["photo"];
            var reader = new BinaryReader(doc.InputStream);
            if (doc.ContentLength != 0)
            {
                byte[] filebytes = reader.ReadBytes(doc.ContentLength);
                patientAdmission.ProfilePicture = filebytes;
            }
            _patientService.CreatePatientAdmission(patientAdmission);
            return RedirectToAction("patientlist");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: DailyDiary/5
        public ActionResult DailyDiary(int id)
        {
            int custId = (int)Session["CustID"];
            PatientDiaryViewModel patientDiaryViewModel = _patientDailyDiaryService.DiaryDetails(id,custId);

            ViewBag.Priority = new SelectList(new[]{
                new SelectListItem{Text="Normal",Value="0"},
                new SelectListItem{Text="Medium",Value="1"},
                 new SelectListItem{Text="High",Value="2"}
            }, "Value", "Text", "0");
            return View(patientDiaryViewModel);
        }


        // GET: Assesment/5
        [HttpPost]
        public ActionResult DailyDiary(PatientDiaryViewModel PatientDiaryViewModel)
        {

            if (ModelState.IsValid)
            {
                PatientDailyDiary patientDailyDiary = PatientDiaryViewModel.PatientDailyDiary;
                patientDailyDiary.CustomerID = (int)Session["CustID"];
                patientDailyDiary.PatientID = (int)Session["PatientID"];
                patientDailyDiary.EntryDate = DateTime.Now;
                _patientDailyDiaryService.Save(patientDailyDiary);
            }
            PatientDiaryViewModel patientDiaryViewModel = _patientDailyDiaryService.DiaryDetails(PatientDiaryViewModel.PatientAdmission.PatientAdmissionID, (int)Session["CustID"]);
            ViewBag.Priority = new SelectList(new[]{
                new SelectListItem{Text="Normal",Value="0"},
                new SelectListItem{Text="Medium",Value="1"},
                 new SelectListItem{Text="High",Value="2"}
            }, "Value", "Text", "0");
            return View(patientDiaryViewModel);
        }

        public ActionResult DailyDiaryJson(string DiaryNotes, string Priority)
        {

            PatientDailyDiary patientDailyDiary = new PatientDailyDiary();
            patientDailyDiary.CustomerID = (int)Session["CustID"];
            patientDailyDiary.DiaryNotes = DiaryNotes;
            patientDailyDiary.Priority = Convert.ToInt16(Priority);
            patientDailyDiary.PatientID = (int)Session["PatientID"];
            patientDailyDiary.EntryDate = DateTime.Now;
            _patientDailyDiaryService.Save(patientDailyDiary);

            return new EmptyResult();
        }

        public ActionResult ListDailyDiaryJson(int id)
        {
            return PartialView("_dairyDetails", _patientDailyDiaryService.ListDailyNote((int)Session["PatientID"]));
        }

        public ActionResult CarePlan(int id)
        {
            int custId = (int)Session["CustID"];
            return View(_carePlan.CarePlanDetails(id, custId));
        }

        [HttpPost]
        public ActionResult CarePlan(CarePlanViewModel CarePlanViewModel)
        {
            CarePlan cp = CarePlanViewModel.CarePlan;
            cp.PatientID = (int)Session["PatientID"];
            cp.CustomerID = (int)Session["CustID"];
            _carePlan.SaveCarePlan(cp);
            return RedirectToAction("ListCarePlan", "patient", new { id = (int)Session["PatientID"] });
        }


        public ActionResult CarePlanEdit(int id)
        {
            int custId = (int)Session["CustID"];
            return View(_carePlan.CarePlanEdit((int)Session["PatientID"], custId,id));
        }

        [HttpPost]
        public ActionResult CarePlanEdit(CarePlanViewModel CarePlanViewModel)
        {
            CarePlan cp = CarePlanViewModel.CarePlan;
            cp.PatientID = (int)Session["PatientID"];
            cp.CustomerID = (int)Session["CustID"];
            _carePlan.UpdateCarePlan(cp);
            return RedirectToAction("ListCarePlan", "patient", new { id = (int)Session["PatientID"] });
        }

        //public ActionResult CarePlanEdit(int id)
        //{
        //    int custId=(int)Session["CustID"];
        //    return View(_carePlan.CarePlanDetails(id,custId));
        //}

        public ActionResult ListCarePlan(int id)
        {
            int custId = (int)Session["CustID"];
            return View(_carePlan.CarePlanList(id, custId));
        }


        public ActionResult VitalSign(int id)
        {
            int custId = (int)Session["CustID"];
            return View(_patientVital.VitalSignDetails(id, custId));
        }


        public ActionResult VitaSignSaveJson(string EntryDate,
                    string BP1,
                    string BP2,
                    string Pulse,
                    string Respiration,
                    string Tempeature,
                    string Weight)
        {
            PatientVitalSign pv = new PatientVitalSign
            {
                EntryDate = DateTime.Parse(EntryDate),
                BP1 = Convert.ToInt16("0" + BP1),
                BP2 = Convert.ToInt16("0" + BP2),
                Pulse = Convert.ToInt16("0" + Pulse),
                Respiration = Convert.ToInt16("0" + Respiration),
                Tempeature = Convert.ToInt16("0" + Tempeature),
                Weight = Convert.ToInt16("0"+Weight),
                PatientID = (int)Session["PatientID"],
                CompanyID = (int)Session["CustID"]

            };

            _patientVital.Save(pv);
            return new EmptyResult();
        }

        public ActionResult ListVitalSignJson()
        {
            return PartialView("_VitalSignDetails", _patientVital.ListVitalSign((int)Session["PatientID"], (int)Session["CustID"]));
        }
        public ActionResult DrawWtChart()
        {
            var data = _patientVital.ListVitalSign((int)Session["PatientID"], (int)Session["CustID"]).Where(p=>p.Weight>0);
            string[] dt=data.Select(d=>d.EntryDate.ToString()).ToList().ToArray();
            string[] val = data.Select(d => d.Weight.ToString()).ToList().ToArray();

            var mychart = new Chart(width: 500, height: 300, theme: ChartTheme.Blue)
                  .AddTitle("Weight Chart")
                  .AddSeries(name: "Weight",
                  chartType: "Line",
                  xValue: dt,
                  yValues: val
                  ).Write();
            return null;
        }


        public ActionResult Assessment(int id)
        {
            Session["Image"] = _patientService.getPatientDetailsById(id).patientAdmission.ProfilePicture;
            return View(_assesment.getWaterLowQuestion());
        }

        [HttpPost]
        public ActionResult Assessment(Evaluation model)
        {
            if (ModelState.IsValid)
            {
                foreach (var q in model.Questions)
                {
                    var qId = q.ID;
                    var selectedAnswer = q.SelectedAnswer;
                    //Save

                }
            }
            return View();
        }


        public ActionResult Appointment()
        {

            return View(_appointment.GetAppointmentDetails((int)Session["PatientID"], (int)Session["CustID"]));
        }

        [HttpPost]
        public ActionResult Appointment(PatientAppointmentViewModel model)
        {
            var app=model.PatientAppointment;
            app.PatientID = (int)Session["PatientID"];
            app.CustID=(int)Session["CustID"];
            _appointment.Create(app);
            return RedirectToAction("AppointmentList", "Patient");
        }
        public ActionResult AppointmentList()
        {
            return View(_appointment.GetAppointmentList((int)Session["PatientID"], (int)Session["CustID"]));
        }

        public ActionResult AppointmentEdit(int id)
        {
            return View(_appointment.GetAppointmentForEdit((int)Session["PatientID"], (int)Session["CustID"],id));
        }

        public ActionResult GetCurrentDateAppointment()
        {
            return View();
        }
        // GET: PatientAdmission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientAdmission/Delete/5
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
