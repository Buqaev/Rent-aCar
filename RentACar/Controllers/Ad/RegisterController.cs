using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentACar.Models;
namespace RentACar.Controllers.Ad
{
    
    public class RegisterController : Controller
    {
        // GET: Register
        CarEntities1 db = new CarEntities1();

        [AllowAnonymous]
        public ActionResult Index()
        {
          
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            user.Status = true;
            user.Sekil = "Bosdur";
            user.Soyad = "Bosdur";
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserLogin()
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Mail, string Sifre)
        {
            User user = db.Users.FirstOrDefault(x => x.Mail == Mail && x.Sifre == Sifre);
            
            Admin admin = db.Admins.FirstOrDefault(x => x.Mail == Mail && x.Sifre == Sifre);
            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(user.Ad, false);
                Session["Id"] = user.Id.ToString();
                Session["Ad"] = user.Ad.ToString();
                Session["Soyad"] = user.Soyad.ToString();
                return RedirectToAction("Index", "Page");
            }
          
            if (admin != null)
            {

                FormsAuthentication.SetAuthCookie(admin.Ad, false);
                Session["Id"] = admin.Id.ToString();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public ActionResult UserProfil()
        {
            UserDto model = new UserDto();

            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
             model.User = db.Users.SingleOrDefault
                (x => x.Id == ID);

            ViewBag.MasinSay = db.Reklams.Count(x => x.Id == ID).ToString();

            model.Rezervs = db.Rezervs.Where(x => x.Status == true && x.User.Id == ID).ToList();

            return View(model);

            
            
        }
        public ActionResult UserUpdate(int Id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == Id);
            
            return View(user);
        }

        public ActionResult Update(User user, HttpPostedFileBase Sekil)
        {
            User u = db.Users.FirstOrDefault(x => x.Id == user.Id);
            u.Ad = user.Ad;
            u.Soyad = user.Soyad;
            u.Mail = user.Mail;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                u.Sekil = Path.GetFileName(Sekil.FileName);

            }
            u.Sifre = user.Sifre;

            db.SaveChanges();
            return RedirectToAction("UserProfil");
        }
        public ActionResult CixisEt()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();


            return RedirectToAction("Index", "Page");
        }

    }
}