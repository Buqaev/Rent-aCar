using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.usr
{
    public class AboutPageController : Controller
    {
        // GET: AboutPage
        CarEntities1 db = new CarEntities1();

        [AllowAnonymous]
        public ActionResult Index()
        {
            AboutPageDto model = new AboutPageDto();
            
            model.OurStories = db.OurStorys.FirstOrDefault(x=>x.Status==true);
            model.Xidmets = db.Xidmets.Where(x => x.Status == true).ToList();

            ViewBag.MasinSay = db.Cars.Where(x => x.Status == true).Count();
            ViewBag.UserSay = db.Users.Where(x => x.Status == true).Count();
            ViewBag.RezervSay = db.Rezervs.Where(x => x.Status == true).Count();

            return View(model);
        }
    }
}