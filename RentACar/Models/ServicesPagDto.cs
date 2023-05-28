using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class ServicesPagDto
    {
        public List<Xidmet> Xidmets { get; set; }
        public Service Service { get; set; }
        public List<RightSide> RightSides { get; set; }
        public List<CustomerReview> CustomerReviews { get; set; }
        public List<BlogComment> BlogComments { get; set; }

    }
}