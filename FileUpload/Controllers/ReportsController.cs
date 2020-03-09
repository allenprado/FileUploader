using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{

   

    public class ReportsController : Controller
    {
        private FileRecords fileRecords = new FileRecords();
        private FileUploadDbContext db = new FileUploadDbContext();

        // GET: Reports
        public ActionResult GetAll()
        {
            return View(db.FileRecordsDB.ToList());
        }

        public List<FileRecords> GetList(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return db.FileRecordsDB.Where(x => x.Date >= DateStart && x.Date <= DateEnd).ToList();
        }

        public ActionResult ListPerDate(DateTime? DateStart = null, DateTime? DateEnd = null)
        {

            return View("_PartialList", GetList(DateStart, DateEnd));
        }

        public JsonResult BindGraphycs(DateTime? DateStart = null, DateTime? DateEnd = null)
        {
            return Json(GetList(DateStart, DateEnd));
        }
    }
}