using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class CarController : Controller
    {
        // GET: Car
        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<Car> cars = db.Cars.Where(x => x.Status == true).ToList();

            return View(cars);
        }

        public ActionResult CarGetr()
        {
            CarDto model = new CarDto();
             model.CarTypes = db.CarTypes.Where(x => x.Status == true).ToList();
             model.CarClasses = db.CarClasses.Where(x => x.Status == true).ToList();
             model.CarMarkas = db.CarMarkas.Where(x => x.Status == true).ToList();

            return View(model);
        }

        public ActionResult Create(Car car, HttpPostedFileBase Sekil)
        {
            car.ElaveEdilmeTarixi = DateTime.Now;
            car.Status = true;


            car.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                car.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.Cars.Add(car);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Delate(int Id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == Id);
            car.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CarUpdate(int Id)
        {

            Car nw = db.Cars.FirstOrDefault(f => f.Id == Id);
            ViewBag.Marka = db.CarMarkas.Where(w => w.Status == true).ToList();
            ViewBag.Class = db.CarClasses.Where(w => w.Status == true).ToList();
            ViewBag.Type = db.CarTypes.Where(w => w.Status == true).ToList();

            return View(nw);
        }

        public ActionResult Update(Car car, HttpPostedFileBase Sekil)
        {
            Car cr = db.Cars.FirstOrDefault(f => f.Id == car.Id);

            cr.Model = car.Model;
            cr.SuretQutusu = car.SuretQutusu;
            cr.SernisinSayi = car.SernisinSayi;
            cr.Baqaj = car.Baqaj;
            cr.Buraxilisili = car.Buraxilisili;
            cr.ElaveEdilmeTarixi =DateTime.Now;
            cr.Klometraj = car.Klometraj;
            cr.Qiymet1_3 = car.Qiymet1_3;
            cr.Qiymet4_12 = car.Qiymet4_12;
            cr.Qiymet12_30 = car.Qiymet12_30;
            cr.Qiymet30GundenCox = car.Qiymet30GundenCox;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                cr.Sekil = Path.GetFileName(Sekil.FileName);
            }
            cr.CarMarkalId = car.CarMarkalId;
            cr.CarTypeId = car.CarTypeId;
            cr.CarClassId = car.CarClassId;

            db.SaveChanges();

            // nw.Like = news.Like +1;


            return RedirectToAction("Index");
        }
    }
}