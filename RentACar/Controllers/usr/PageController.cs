using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.usr
{
    public class PageController : Controller
    {
        // GET: Page
        CarEntities1 db = new CarEntities1();

       [AllowAnonymous]
        public ActionResult Index()
        {
            HomPaDto model = new HomPaDto();
            model.Reklams = db.Reklams.Where(x => x.Status == true).ToList();
            model.Xidmets = db.Xidmets.Where(x => x.Status == true).ToList();
            model.Cars = db.Cars.Where(x => x.Status == true).ToList();
            model.CarTypes = db.CarTypes.Where(x => x.Status == true).ToList();
            model.customerReviews = db.CustomerReviews.Where(x => x.Status == true).ToList();
            model.Services = db.Services.Where(x => x.Status == true).ToList();
            model.CarMarkas = db.CarMarkas.Where(x => x.Status == true).ToList();
            ViewBag.MasinSay = db.Cars.Where(x => x.Status == true).Count();
            ViewBag.UserSay = db.Users.Where(x => x.Status == true).Count();
            ViewBag.RezervSay = db.Rezervs.Where(x => x.Status == true).Count();
           
            return View(model);
        }

        [HttpPost]
       
        [AllowAnonymous]
        public ActionResult CustomerReview(CustomerReview cr)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User user = db.Users.SingleOrDefault(x => x.Id == ID);
            cr.Status = true;
                

            cr.User = db.Users.SingleOrDefault(x => x.Id == ID);


            db.CustomerReviews.Add(cr);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }

        [AllowAnonymous]

        public PartialViewResult Partial()
        {
          List<Xidmet> xidmets = db.Xidmets.OrderByDescending(x => x.Id).Take(1).ToList();

            return PartialView(xidmets.ToList());
        }
    }
}