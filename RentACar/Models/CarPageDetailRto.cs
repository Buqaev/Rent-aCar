using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class CarPageDetailRto
    {
        public Car Car { get; set; }
        public List<Car> Cars2 { get; set; }
        public List<Car> Cars { get; set; }
        public List<CarKarusel> CarKarusels { get; set; }
        public List<CarsReview> CarsReviews { get; set; }
        public List<CarMarka> CarMarkas { get; set; }

    }
}