using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;
namespace RentACar.Controllers.usr
{
    public class BlogPageController : Controller
    {
        // GET: BlogPage
        CarEntities1 db = new CarEntities1();

        [AllowAnonymous]
        public ActionResult Index(BlogCategory blogCategory, int? CatId, int? TagId, int? page, string p)
        {
            BlogPagDto model = new BlogPagDto();
            model.Blogs = db.Blogs.Where(x => x.Status == true).ToList();




            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<Blog> data = new List<Blog>();

          
            if (CatId != null)
            {
                data = db.Blogs.Where(w => w.BlogCategorysId == CatId).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (TagId != null)
            {

                List<int> nws = db.CloudBlogAndTags.Where(w => w.TegId == TagId).Select(s => s.BlogId).ToList();
                data = db.Blogs.Where(w => nws.Contains(w.Id)).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (p != null && p.Length > 0)
            {
                data = db.Blogs.Where(x => x.Baslig.Contains(p)).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }
            else
            {
                data = db.Blogs.OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

                p = null;

            }

            model.Blogs = data;
            model.BlogCategories = db.BlogCategorys.Where(x => x.Status == true).ToList();
            //model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            model.Tegs = db.Tegs.Where(x => x.Status == true).ToList();
            model.Blogs2 = db.Blogs.OrderByDescending(o => o.Id).Take(3).ToList();

            ViewBag.Axtaris = p;
            ViewBag.CatId = CatId;
            ViewBag.TagId = TagId;


            return View(model);


            
        }

        [AllowAnonymous]
        public ActionResult BlogDetail(int Id, int? CatId, int? TagId)
        {
            BlogDetailDto data = new BlogDetailDto();

            data.Blog = db.Blogs.FirstOrDefault(x => x.Id == Id);

            //model.blogComments = db.BlogComments.Where(x => x.Id == Id).ToList();
            //model.Blog = db.Blogs.FirstOrDefault(x => x.Id == Id);

            //model.blogComments = db.BlogComments.Where(x => x.BlogId == Id).ToList();



            if (CatId != null)
            {
                data.Blogs = db.Blogs.Where(w => w.BlogCategorysId == CatId).ToList();
            }
            else if (TagId != null)
            {

                List<int> nws = db.CloudBlogAndTags.Where(w => w.TegId == TagId).Select(s => s.BlogId).ToList();
                data.Blogs = db.Blogs.Where(w => nws.Contains(w.Id)).ToList();

            }
            else
            {
                data.Blogs = db.Blogs.ToList();
            }


            //data.Blog2 = db.Blogs.FirstOrDefault(x => x.Id == Id);

            data.BlogComments = db.BlogComments.Where(x => x.BlogId == Id).ToList();

            var deyer = db.BlogComments.Where(x => x.BlogId == Id).Count().ToString();
            ViewBag.ReviewSay = deyer;

          


            
            data.BlogCategories = db.BlogCategorys.Where(x => x.Status == true).ToList();
            data.Tegs = db.Tegs.Where(x => x.Status == true).ToList();
           
            data.Blog3 = db.Blogs.Where(x => x.Status == true).OrderByDescending(x=>x.Id).Take(3).ToList();
            return View(data);

            
        }


        [HttpPost]
        public ActionResult BlogDetay(BlogComment b, int id)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);

            //r.Id = ID;
            //NewsdetailDto data = new NewsdetailDto();

            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            User user = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);


            b.Blog = db.Blogs.SingleOrDefault(t => t.Id == id);      //olmasa c date ele

            b.User = db.Users.SingleOrDefault(x => x.Id == ID);


            db.BlogComments.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}