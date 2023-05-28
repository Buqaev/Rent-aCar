using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class XidmetController : Controller
    {
        // GET: Xidmet

        CarEntities1 db = new CarEntities1();

        public ActionResult Index()
        {
            List<Xidmet> xidmets = db.Xidmets.Where(x => x.Status == true).ToList();

            return View(xidmets);
        }

        public ActionResult CreateXidmet()
        {

            return View();
        }

        public ActionResult Create(Xidmet xidmet)
        {

            xidmet.Status = true;


            db.Xidmets.Add(xidmet);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delate(int Id)
        {
            Xidmet xidmet = db.Xidmets.SingleOrDefault(x => x.Id == Id);

            xidmet.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateXidmet(int Id)
        {
            Xidmet xidmet = db.Xidmets.FirstOrDefault(x => x.Id == Id);


            return View(xidmet);
        }

        public ActionResult Update(Xidmet xid)
        {
            Xidmet xidmet = db.Xidmets.FirstOrDefault(x => x.Id == xid.Id);

            xidmet.Basliq = xid.Basliq;
            xidmet.Metn = xid.Metn;
           
            db.SaveChanges();
            return RedirectToAction("Index", xidmet);
        }
    }
}