using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Controllers.Ad
{
    public class AdminController : Controller
    {
        // GET: Admin
        CarEntities1 db = new CarEntities1();
        public ActionResult Index()
        {
            List<Admin> admins = db.Admins.ToList();

            return View(admins);
        }

        public ActionResult UpdateAdmin(int Id)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == Id);
            return View(admin);
        }

        public ActionResult Update(Admin a)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == a.Id);

            admin.Ad = a.Ad;
            admin.Soyad = a.Soyad;
            admin.Mail = a.Mail;
            admin.Telefon = a.Telefon;
            admin.Unvan = a.Unvan;
            admin.Sifre = a.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index",admin);
        }
    }
}