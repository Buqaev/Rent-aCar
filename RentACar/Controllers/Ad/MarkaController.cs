using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
namespace RentACar.Controllers.Ad
{
    public class MarkaController : Controller
    {
        // GET: Marka
        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
           List<CarMarka> carMarka = db.CarMarkas.Where(x => x.Status == true).ToList();

            return View(carMarka);
        }

        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create(CarMarka cm, HttpPostedFileBase Logo)
        {
            cm.Status = true;

            if (Logo != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Logo.FileName));
                Logo.SaveAs(path);
                cm.Logo = Path.GetFileName(Logo.FileName);

            }
            db.CarMarkas.Add(cm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateMarka(int Id)
        {
            CarMarka carMarka = db.CarMarkas.FirstOrDefault(x => x.Id == Id);

            return View(carMarka);
        }

        public ActionResult Update(CarMarka carMarka, HttpPostedFileBase Logo)
        {
            CarMarka cm = db.CarMarkas.FirstOrDefault(x => x.Id == carMarka.Id);
            cm.Ad = carMarka.Ad;
            if (Logo != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Logo.FileName));
                Logo.SaveAs(path);
                cm.Logo = Path.GetFileName(Logo.FileName);

            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            CarMarka carMarka = db.CarMarkas.FirstOrDefault(x => x.Id == Id);
            carMarka.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
    
