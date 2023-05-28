using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.usr
{
    public class CarPageController : Controller
    {
        // GET: CarPage

        CarEntities1 db = new CarEntities1();
        [AllowAnonymous]
         public ActionResult Index(int? MarkaId,int? CartypeId,int? ModelId, BlogCategory blogCategory, int? CatId, int? TagId, int? page, string p)
        {
            //CarPageDto model = new CarPageDto();

            //List<Car> data = new List<Car>();



            //if (MarkaId == null || ModelId == null)
            //{
            //    model.Cars = db.Cars.Where(x => x.Status == true).ToList();

            //}
            //if (MarkaId != null || ModelId != null)
            //{
            //    model.Cars = db.Cars.Where(w => w.Status == true && w.CarMarkalId == MarkaId).ToList();

            //    model.CarMarkas = db.CarMarkas.Where(x => x.Status == true && x.Id == MarkaId).ToList();



            //    model.Cars2 = db.Cars.Where(x => x.Status == true && x.Id == ModelId).ToList();
            //}
            //if (MarkaId != null && ModelId != null)
            //{
            //    model.Cars = db.Cars.Where(w => w.Status == true && w.CarMarkalId == MarkaId && w.Id == ModelId).ToList();



            //}

            //model.Cars = db.Cars.Where(x => x.Status == true && x.Id == ModelId).ToList();


            //model.CarMarkas = db.CarMarkas.Where(w => w.Status == true).ToList();







            //BlogPagDto model = new BlogPagDto();
            //model.Cars = db.Cars.Where(x => x.Status == true).ToList();




            //if (page == null)
            //{
            //    page = 1;
            //}
            //int skip = ((int)page - 1) * 2;

            //List<Car> data = new List<Car>();


            //if (model == null)
            //{


            //}
            //else if ()
            //{

            //    List<int> nws = db.CloudBlogAndTags.Where(w => w.TegId == TagId).Select(s => s.BlogId).ToList();
            //    data = db.Cars.Where(w => nws.Contains(w.Id)).ToList();
            //    ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
            //    ViewBag.Page = page;
            //    data = data.Skip(skip).Take(2).ToList();

            //}
            //else if (p != null && p.Length > 0)
            //{
            //    data = db.Cars.Where(x => x.Ad.Contains(p)).OrderByDescending(o => o.Id).ToList();
            //    ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
            //    ViewBag.Page = page;
            //    data = data.Skip(skip).Take(2).ToList();
            //}
            //else
            //{


            //    ViewBag.TotalPage = Math.Ceiling(model.Cars.Count / 2.00);
            //    ViewBag.Page = page;
            //    model.Cars = model.Cars.Skip(skip).Take(2).ToList();

            //    p = null;

            //}


            //if (p != null && p.Length > 0)
            //{
            //    model.Cars = db.Cars.Where(x => x.Status == true && x.CarMarka.Ad.Contains(p)).OrderByDescending(o => o.Id).ToList();

            //}

            //model.CarMarkas = db.CarMarkas.Where(x => x.Status == true).ToList();

            //model.Cars = data;

            //model.Cars2 = db.Cars.Where(x => x.Status == true || x.Id == ModelId).ToList();


            //model.CarMarkas = data;


            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<Car> data = new List<Car>();

            CarPageDto model = new CarPageDto();
            if (MarkaId != null)
            {
                //data = db.Cars.Where(w => w.CarMarkalId == MarkaId).ToList();
                if (ModelId!=null && MarkaId!=null )
                {
                    //data = db.Cars.Where(w => w.Id == MarkaId &&w.Id==ModelId).ToList();

                    data = db.Cars.Where(w => w.Status == true && w.Id == ModelId).ToList();
                }

                else
                {
                    data = db.Cars.Where(w => w.CarMarkalId == MarkaId && w.Status==true).ToList();
                }
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (ModelId != null)
            {

                //List<int> nws = db.Clouds.Where(w => w.TeqId == TagId).Select(s => s.XeberId).ToList();
                data = db.Cars.Where(w => w.Id == ModelId && w.CarMarkalId==MarkaId).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (p != null && p.Length > 0)
            {
                data = db.Cars.Where(x => x.CarMarka.Ad.Contains(p) && x.Status==true).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }
            else
            {
                data = db.Cars.OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

                p = null;

            }

            if (CartypeId!=null)
            {
                data = db.Cars.Where(x => x.Status == true && x.CarTypeId == CartypeId).ToList();
                
            }

            model.Cars = data;
            model.CarMarkas = db.CarMarkas.Where(x => x.Status == true && x.Status==true).ToList();
            //model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            model.CarMarkas = db.CarMarkas.Where(x => x.Status == true).ToList();
            model.Cars2 = db.Cars.OrderByDescending(o => o.Id ).ToList();
            model.CarTypes = db.CarTypes.Where(x => x.Status == true).ToList();
            ViewBag.Axtaris = p;
            ViewBag.CatId = CatId;
            ViewBag.TagId = TagId;


            return View(model);

            

            
        }
      
        
        [AllowAnonymous]
        public ActionResult CarPageDetail(int Id)
        {
            CarPageDetailRto model = new CarPageDetailRto();

            model.Car = db.Cars.FirstOrDefault(x => x.Id == Id);
            model.CarKarusels = db.CarKarusels.Where(x => x.Status == true && x.CarId==Id).ToList();
            model.CarsReviews = db.CarsReviews.Where(x => x.CarId == Id && x.Status==true).ToList();

            model.Cars2 = db.Cars.Where(x => x.Status == true && x.Id==Id).ToList();
            model.Cars = db.Cars.OrderByDescending(o => o.Id).Take(3).ToList();

            return View(model);
        }

        

        [HttpPost]
        public ActionResult CarReview(CarsReview cr, int id)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);

            //r.Id = ID;
            //NewsdetailDto data = new NewsdetailDto();

            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            User user = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);

            cr.Ulduzsayi = 1;
            cr.Status = true;
            cr.Car = db.Cars.SingleOrDefault(t => t.Id == id);      //olmasa c date ele

            cr.User = db.Users.SingleOrDefault(x => x.Id == ID);


            db.CarsReviews.Add(cr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        
        public ActionResult YeniRezerv(int Id)
        {
            RezervDto data = new RezervDto();
            //String Id = Session["Id"].ToString();  //olmasa burani userId ver
            //var ID = int.Parse(Id);
            data.Car = db.Cars.SingleOrDefault(x => x.Id == Id);
            //data.User = db.Users.FirstOrDefault(x => x.Id == ID);
             

            //data.Cars = db.Cars.Where(x => x.Status == true && x.Id == Id).ToList();

            return View(data);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult YeniRezerv(Rezerv r, DateTime Tim,DateTime Tim2 ,int Id/*, int rating*/)   //saba prtojenin vidyosuna bax
        {
            RezervDto data = new RezervDto();
            String id = Session["Id"].ToString();  //olmasa burani userId ver
            var ID = int.Parse(id);
            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            data.User = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            //c.Tarix = DateTime.Now;
            r.Status = true;
            r.AlinmaTarix = Tim;
            r.QaytarilmaTarix = Tim2;

            double say = (r.QaytarilmaTarix - r.AlinmaTarix).TotalDays;

           

            r.Car = db.Cars.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele

            r.User = db.Users.SingleOrDefault(x => x.Id == ID);
            if (say == 1 || say <= 3)
            {
                r.UmmiMebleg =  (Convert.ToInt32(say) * r.Car.Qiymet1_3);
            }
            else if(say>=4|| say <= 12)
            {
                r.UmmiMebleg = (Convert.ToInt32(say) * r.Car.Qiymet4_12);
            }
            else if(say>12|| say <= 30)
            {
                r.UmmiMebleg = (Convert.ToInt32(say) * r.Car.Qiymet12_30);
            }
            else if (say > 30)
            {
                r.UmmiMebleg = (Convert.ToInt32(say) * r.Car.Qiymet30GundenCox);
            }
            db.Rezervs.Add(r);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}