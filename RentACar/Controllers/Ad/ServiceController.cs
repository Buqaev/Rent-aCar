using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class ServiceController : Controller
    {
        // GET: Service
        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<Service> services = db.Services.Where(x => x.Status == true).ToList();


            return View(services);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service, HttpPostedFileBase Sekil)
        {
            service.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                service.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.Services.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            Service service = db.Services.SingleOrDefault(x => x.Id == Id);

            service.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateService(int Id)
        {
            Service service = db.Services.FirstOrDefault(x => x.Id == Id);


            return View(service);
        }

        public ActionResult Update(Service s, HttpPostedFileBase Sekil)
        {
            Service service = db.Services.FirstOrDefault(x => x.Id == s.Id);

            service.Baslig = s.Baslig;
            service.Metn = s.Metn;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                service.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();
            return RedirectToAction("Index", service);
        }
    }
}
