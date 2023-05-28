using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class AboutPageDto
    {
        public OurStory OurStories { get; set; }
        public List<Xidmet> Xidmets { get; set; }
    }
}