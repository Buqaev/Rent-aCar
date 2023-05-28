using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    

    public class TegController : Controller
    {
        // GET: Teg
        CarEntities1 db = new CarEntities1();
        public ActionResult Index()
        {
            List<Teg> clouds = db.Tegs.Where(x => x.Status == true).ToList();

            return View(clouds);
        }

        public ActionResult CreateTeq(Teg teg)
        {
            teg.Status = true;
            db.Tegs.Add(teg);


            db.SaveChanges();

            return RedirectToAction("Index");


        }

        public ActionResult Delete(int Id)
        {
            Teg teg = db.Tegs.FirstOrDefault(x => x.Id == Id);
            teg.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TegCreate()
        {
            CloudDto data = new CloudDto();

            data.Blogs = db.Blogs.ToList();
            data.Tegs = db.Tegs.Where(x => x.Status == true).ToList();

            return View(data);
        }
        public ActionResult Create(CloudBlogAndTag cl, int Id)
        {
            CloudBlogAndTag cloud = new CloudBlogAndTag();
            cloud.Blog = db.Blogs.SingleOrDefault(x => x.Id == Id);
            cl.Blog = db.Blogs.SingleOrDefault(t => t.Id == Id);

            cloud.Teg = db.Tegs.SingleOrDefault(x => x.Id == Id);
            cl.Teg = db.Tegs.SingleOrDefault(t => t.Id == Id);


            db.CloudBlogAndTags.Add(cl);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}