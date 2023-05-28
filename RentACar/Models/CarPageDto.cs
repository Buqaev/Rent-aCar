using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class CarPageDto
    {
        public List<Car> Cars { get; set; }
        public List<CarMarka> CarMarkas { get; set; }

        public List<Car> Cars2 { get; set; }

        public List<CarType> CarTypes { get; set; }
    }
}