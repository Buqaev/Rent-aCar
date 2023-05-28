using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class RightSidesController : Controller
    {
        // GET: RightSides
        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<RightSide> rightSides = db.RightSides.Where(x => x.Status == true).ToList();

            return View(rightSides);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateRightSide(RightSide rightSide)
        {
            rightSide.Status = true;

            db.RightSides.Add(rightSide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            RightSide rightSide = db.RightSides.SingleOrDefault(x => x.Id == Id);

            rightSide.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateRightSide(int Id)
        {
            RightSide rightSide = db.RightSides.FirstOrDefault(x => x.Id == Id);


            return View(rightSide);
        }

        public ActionResult Update(RightSide r)
        {
            RightSide rightSide = db.RightSides.FirstOrDefault(x => x.Id == r.Id);

            rightSide.Baslig = r.Baslig;
            rightSide.Metn = r.Metn;
            
           
            db.SaveChanges();
            return RedirectToAction("Index", rightSide);
        }
    }
}
    
