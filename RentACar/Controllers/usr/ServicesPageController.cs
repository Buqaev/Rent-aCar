using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
namespace RentACar.Controllers.usr
{
    public class ServicesPageController : Controller
    {
        // GET: ServicesPage
        CarEntities1 db = new CarEntities1();
        [AllowAnonymous]
        public ActionResult Index()
        {
            ServicesPagDto model = new ServicesPagDto();

            model.Xidmets = db.Xidmets.Where(x => x.Status == true).ToList();
            model.RightSides = db.RightSides.Where(x => x.Status == true).ToList();
            model.CustomerReviews = db.CustomerReviews.Where(x => x.Status == true).ToList();
            model.Service = db.Services.FirstOrDefault(x => x.Status == true);
            model.BlogComments = db.BlogComments.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(model);
        }
    }
}