﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarEntities1 : DbContext
    {
        public CarEntities1()
            : base("name=CarEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BlogCategory> BlogCategorys { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CarClass> CarClasses { get; set; }
        public virtual DbSet<CarKarusel> CarKarusels { get; set; }
        public virtual DbSet<CarMarka> CarMarkas { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarsReview> CarsReviews { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<ChechBox> ChechBoxes { get; set; }
        public virtual DbSet<CloudBlogAndTag> CloudBlogAndTags { get; set; }
        public virtual DbSet<CloudRezervChechBox> CloudRezervChechBoxes { get; set; }
        public virtual DbSet<CustomerReview> CustomerReviews { get; set; }
        public virtual DbSet<Mundericat> Mundericats { get; set; }
        public virtual DbSet<OurStory> OurStorys { get; set; }
        public virtual DbSet<Reklam> Reklams { get; set; }
        public virtual DbSet<RightSide> RightSides { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Teg> Tegs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Xidmet> Xidmets { get; set; }
        public virtual DbSet<Rezerv> Rezervs { get; set; }
    }
}
