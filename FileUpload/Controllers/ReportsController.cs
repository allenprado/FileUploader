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


        //SHOW DATA for all dates and hour
        public ActionResult GetAll()
        {
            return View(db.FileRecordsDB.ToList());
        }

        //====================================================================================================

        //GET FROM ENTITY to send date form  MAX/Min/AVG METHOD
        public List<VwFileUpload> GetList(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return db.VwFileUploadDB.Where(x => x.Date >= DateStart && x.Date <= DateEnd).ToList();
        }

        //GET FROM ENTITY to send date form  most expensive METHOD
        public List<VwFileUploadPerHour> GetListHour(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return db.VwFileUploadPerHourDB.Where(x => x.Date >= DateStart && x.Date <= DateEnd).ToList();
        }

        //====================================================================================================

        //Show View Only with fiels to select Date for MAX/Min/AVG
        public ActionResult ListMax()
        {
            return View();
        }

        [HttpPost]
        //Show MAX/Min/AVG prices per Day
        public ActionResult ListMax(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialListMax", GetList(DateStart, DateEnd));
        }

        //====================================================================================================

        //Show View Only with fiels to select Date for most expensive hour
        public ActionResult ListExp()
        {
            return View();
        }

        [HttpPost]
        //Show Expensive prices in hour per Day
        public ActionResult ListExp(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialListExp", GetListHour(DateStart, DateEnd));
        }

        //====================================================================================================

        //Send Data MAX/MIN/AVG to bind the graph
        public JsonResult BindGraphycsMax(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetList(DateStart, DateEnd));
        }

        //Send Data most Expernsive to bind the graph
        public JsonResult BindGraphycsExp(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetListHour(DateStart, DateEnd));
        }
    }
}