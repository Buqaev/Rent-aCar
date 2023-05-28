using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class CloudDto
    {
        public List<Blog> Blogs { get; set; }
        public List<Teg> Tegs { get; set; }
        public List<CloudBlogAndTag> Clouds { get; set; }
    }
}