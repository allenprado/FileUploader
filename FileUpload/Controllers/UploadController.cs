using System.Web;
using System.Web.Mvc;
using System.IO;
using FileUpload.Models;
using System;
using FileHelpers;
using EntityFramework.BulkInsert.Extensions;
using System.Collections.Generic;

namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {

        private FileRecords fileRecords = new FileRecords();
        private FileUploadDbContext db = new FileUploadDbContext();


        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }


        //INSTALL
        //Install-Package FileHelpers -Version 3.4.1
        //Install-Package EntityFramework.BulkInsert-ef6 -Version 6.0.1.2

        public ActionResult FileUpload()
        {

            var postedFile = Request.Files[0];
            int ver = 0;
            bool ValidationConvertion;
            var fileExt = System.IO.Path.GetExtension(postedFile.FileName).Substring(1);
            
            //Validation if is CSV
            if (fileExt != "csv")
            {
                TempData["error"] = "The File Should Be CSV";
                RedirectToAction("Index");
            }
            else
            {
                using (var reader = new StreamReader(postedFile.InputStream))
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    //Validate if Layou contain Date and Price columns
                    if (ver == 0 && values[0] != "Date" && values[1] != "Price")
                    {
                        TempData["error"] = "Layout is not compatible";
                        RedirectToAction("Index");
                    }
                    else
                    {
                        while (!reader.EndOfStream)
                        {

                            line = reader.ReadLine();
                            values = line.Split(',');

                            DateTime DateF = DateTime.Now;
                            Decimal PriceF = 0;

                            //Validation Conversion Data
                            try
                            {
                                DateF = Convert.ToDateTime(values[0]);
                                PriceF = Math.Round(Convert.ToDecimal(values[1]), 2);
                                ValidationConvertion = true;

                            }
                            catch (Exception ex)
                            {
                                ValidationConvertion = false;
                            }

                            if (ver > 0 && ValidationConvertion) // Ignore the first line
                            {

                                fileRecords.Date = DateF;
                                fileRecords.Price = PriceF;
                                fileRecords.DateUpload = DateTime.Now;

                                db.FileRecordsDB.Add(fileRecords);
                                db.SaveChanges();
                            }

                            ver++;
                        }

                        TempData["success"] = "File has been successfully updated";
                    }
                }
            }

            return View("Index");
        }
    }
}
