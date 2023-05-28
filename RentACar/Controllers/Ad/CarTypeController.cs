using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class CarTypeController : Controller
    {
        // GET: CarType
        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<CarType> carTypes = db.CarTypes.Where(x => x.Status == true).ToList();

            return View(carTypes);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateCarType(CarType carType, HttpPostedFileBase Sekil)
        {
            carType.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                carType.Icon = Path.GetFileName(Sekil.FileName);

            }
            db.CarTypes.Add(carType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            CarType carType = db.CarTypes.SingleOrDefault(x => x.Id == Id);

            carType.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCarType(int Id)
        {
            CarType carType = db.CarTypes.FirstOrDefault(x => x.Id == Id);


            return View(carType);
        }

        public ActionResult Update(CarType crt, HttpPostedFileBase Sekil)
        {
            CarType carType = db.CarTypes.FirstOrDefault(x => x.Id == crt.Id);

            carType.Ad = crt.Ad;
           
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                carType.Icon = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();
            return RedirectToAction("Index", crt);
        }
    }
}
