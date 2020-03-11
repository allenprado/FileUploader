using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FileUpload.Controllers
{

   

    public class ReportsController : Controller
    {
        private FileRecords fileRecords = new FileRecords();
        private FileUploadDbContext db = new FileUploadDbContext();

        DateTime DateStartX = Convert.ToDateTime("2013-01-02 00:00:00.000");
        DateTime DateEndX = Convert.ToDateTime("2014-01-02 00:00:00.000");

        // GET: Reports
        public ActionResult GetAll()
        {
            return View(db.FileRecordsDB.ToList());
        }

        public List<VwFileUpload> GetList(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return db.VwFileUploadDB.Where(x => x.Date >= DateStart && x.Date <= DateEnd).ToList();
        }

        public List<VwFileUploadPerHour> GetListHour(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return db.VwFileUploadPerHourDB.Where(x => x.Date >= DateStart && x.Date <= DateEnd).ToList();
        }

        //Show MAX prices per Day
        public ActionResult ListMax(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View(GetList(DateStart, DateEnd));
        }
        //Show MIN prices per Day
        public ActionResult ListMin(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialListMin", GetList(DateStart, DateEnd));
        }
        //Show AVG prices per Day
        public ActionResult ListAvg(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialListAvg", GetList(DateStart, DateEnd));
        }
        //Show Expensive prices in hour per Day
        public ActionResult ListExp(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialListExp", GetListHour(DateStart, DateEnd));
        }

        public JsonResult BindGraphycsMax(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetList(DateStart, DateEnd));
        }

        public JsonResult BindGraphycsMin(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetList(DateStart, DateEnd));
        }

        public JsonResult BindGraphycsAvg(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetList(DateStart, DateEnd));
        }

        public JsonResult BindGraphycsExp(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetListHour(DateStart, DateEnd));
        }
    }
}