using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models; 

namespace RentACar.Controllers.Ad
{
    public class RezervController : Controller
    {
        // GET: Rezerv
        CarEntities1 db = new CarEntities1();
        public ActionResult Index()
        {
            List<Rezerv> rezervs = db.Rezervs.Where(x => x.Status == true).ToList();

            return View(rezervs);
        }
    }
}