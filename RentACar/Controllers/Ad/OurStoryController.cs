using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class OurStoryController : Controller
    {
        // GET: OurStory

        CarEntities1 db = new CarEntities1();
        public ActionResult Index()
        {
            List<OurStory> ourStories = db.OurStorys.Where(x => x.Status == true).ToList();

            return View(ourStories);
        }

        [HttpGet]
        public ActionResult CreateOurStory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(OurStory ourStory, HttpPostedFileBase Sekil)
        {
            ourStory.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                ourStory.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.OurStorys.Add(ourStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delate(int Id)
        {
            OurStory ourStory = db.OurStorys.SingleOrDefault(x => x.Id == Id);

            ourStory.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateOurStory(int Id)
        {
            OurStory ourStory = db.OurStorys.FirstOrDefault(x => x.Id == Id);


            return View(ourStory);
        }

        public ActionResult Update(OurStory o, HttpPostedFileBase Sekil)
        {
            OurStory ourStory = db.OurStorys.FirstOrDefault(x => x.Id == o.Id);

            ourStory.Basliq = o.Basliq;
            ourStory.Metn = o.Metn;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                ourStory.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();
            return RedirectToAction("Index", ourStory);
        }
    }
}

    
