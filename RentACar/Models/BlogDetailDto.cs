using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class BlogDetailDto
    {
        public Blog Blog { get; set; }
        public List<BlogComment> blogComments { get; set; }

        public User User { get; set; }



        public Blog Blog2 { get; set; }
        public List<Blog> Blog3 { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public BlogComment BlogComment { get; set; }

       
        public List<Blog> Blogs { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        //public List<DoctorCategory> doctorCategories { get; set; }

        public List<CloudBlogAndTag> CloudBlogAndTags { get; set; }
        public List<Teg> Tegs { get; set; }
        public List<BlogComment> blogComment { get; set; }

    }
}