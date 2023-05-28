using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class AboutController : Controller
    {
        // GET: About

        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.Where(x => x.Status == true).ToList();

            return View(abouts);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            about.Status = true;

            
            db.Abouts.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            About about = db.Abouts.SingleOrDefault(x => x.Id == Id);

            about.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAbout(int Id)
        {
            About about = db.Abouts.FirstOrDefault(x => x.Id == Id);


            return View(about);
        }

        public ActionResult Update(About a)
        {
            About about = db.Abouts.FirstOrDefault(x => x.Id == a.Id);

            about.Basliq = a.Basliq;
            about.Metn = a.Metn;
            db.SaveChanges();
            return RedirectToAction("Index", about);
        }
    }
}
    
