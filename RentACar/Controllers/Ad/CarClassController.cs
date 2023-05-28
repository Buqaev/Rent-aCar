using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
namespace RentACar.Controllers.Ad
{
    public class CarClassController : Controller
    {
        // GET: CarClass
        CarEntities1 db = new CarEntities1();


        public ActionResult Index()
        {
            List<CarClass> carClasses = db.CarClasses.Where(x => x.Status == true).ToList();
            

            return View(carClasses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Create(CarClass cl)
        {
            cl.Status = true;
            db.CarClasses.Add(cl);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateClass(int Id)
        {
            CarClass carClass = db.CarClasses.FirstOrDefault(x => x.Id == Id);

            return View(carClass);
        }

        public ActionResult Update(CarClass carClass)
        {
            CarClass cl = db.CarClasses.FirstOrDefault(x => x.Id == carClass.Id);
            cl.Ad = carClass.Ad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            CarClass carClass = db.CarClasses.FirstOrDefault(x => x.Id == Id);
            carClass.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}