using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class BlogController : Controller
    {
        // GET: Blog

        CarEntities1 db = new CarEntities1();

        public ActionResult Index(Blog blog)
        {
            List<Blog> blogs = db.Blogs.Where(x => x.Status == true).ToList();

           

            return View(blogs);
        }

        public ActionResult CateGetir()
        {
          List<BlogCategory> blogCategory = db.BlogCategorys.Where(x => x.Status == true).ToList();
           ViewBag.Tags = db.Tegs.Where(w => w.Status == true).ToList();
            return View(blogCategory);
        }

        public ActionResult Create(Blog blog, List<int> Tags, HttpPostedFileBase Sekil)
        {
            blog.Tarix = DateTime.Now;
            blog.Status = true;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                blog.Sekil = Path.GetFileName(Sekil.FileName);

            }


            //// Taglari elave edirik!!!!! 
            foreach (int tag in Tags)
            {
                CloudBlogAndTag cloud = new CloudBlogAndTag();
                cloud.BlogId = blog.Id;
                cloud.TegId = tag;

                db.CloudBlogAndTags.Add(cloud);
            }

            db.Blogs.Add(blog);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Delate(int Id)
        {
            Blog blog = db.Blogs.FirstOrDefault(x => x.Id == Id);
            blog.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateBlog(int Id)
        {
            Blog blog = db.Blogs.FirstOrDefault(x => x.Id == Id);

            ViewBag.Categories = db.BlogCategorys.Where(w => w.Status == true).ToList();
            return View(blog);

        }

        public ActionResult Update(Blog blog, HttpPostedFileBase Sekil)
        {
            Blog nw = db.Blogs.FirstOrDefault(f => f.Id == blog.Id);
            nw.Baslig = blog.Baslig;
            nw.Metn = blog.Metn;
            nw.BlogCategorysId = blog.BlogCategorysId;
            nw.Tarix = DateTime.Now;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                nw.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            


            return RedirectToAction("Index");
        }


        //BlogCategorias

        public ActionResult BlogCateList()
        {
            List<BlogCategory> blogCategories = db.BlogCategorys.Where(x => x.Status == true).ToList();

            return View(blogCategories);

        }


        public ActionResult CreateBlogCategory(BlogCategory blogCategory)
        {
            blogCategory.Status = true;
            db.BlogCategorys.Add(blogCategory);
            db.SaveChanges();

            return RedirectToAction("BlogCateList");
        }

        public ActionResult CategoriDelate(int Id)
        {
            BlogCategory blogCategory = db.BlogCategorys.FirstOrDefault(x => x.Id == Id);
            blogCategory.Status = false;
            db.SaveChanges();

            return RedirectToAction("BlogCateList");
        }
        public ActionResult CategoryUpdate(int Id)
        {
            BlogCategory blogCategory = db.BlogCategorys.FirstOrDefault(x => x.Id == Id);

            return View(blogCategory);

        }

        public ActionResult CateUpdate(BlogCategory category)
        {
            BlogCategory blogCategory = db.BlogCategorys.FirstOrDefault(x => x.Id == category.Id);
            blogCategory.Ad = category.Ad;
            db.SaveChanges();

            return RedirectToAction("BlogCateList");
        }
    }
}