using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class HomPaDto
    {
        public List<Reklam> Reklams { get; set; }
        public List<Xidmet> Xidmets { get; set; }
        public Xidmet Xidmets2 { get; set; }
        public List<Car> Cars { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<CustomerReview> customerReviews { get; set; }
        public List<Service> Services { get; set; }

        public List<CarMarka> CarMarkas { get; set; }
    }
}