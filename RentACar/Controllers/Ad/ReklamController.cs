using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
namespace RentACar.Controllers.Ad
{
    public class ReklamController : Controller
    {
        // GET: Reklam

        CarEntities1 db = new CarEntities1();
        public ActionResult Index()
        {
            List<Reklam> reklams = db.Reklams.Where(x => x.Status).ToList();

            return View(reklams);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateReklam(Reklam reklam, HttpPostedFileBase Sekil)
        {
            reklam.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                reklam.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.Reklams.Add(reklam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            Reklam reklams = db.Reklams.SingleOrDefault(x => x.Id == Id);

            reklams.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateReklam(int Id)
        {
            Reklam reklam = db.Reklams.FirstOrDefault(x => x.Id == Id);


            return View(reklam);
        }

        public ActionResult Update(Reklam r, HttpPostedFileBase Sekil)
        {
            Reklam reklam = db.Reklams.FirstOrDefault(x => x.Id == r.Id);
            
            reklam.Basliq = r.Basliq;
            reklam.Metn = r.Metn;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                reklam.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();
            return RedirectToAction("Index",reklam);
        }
    }
}