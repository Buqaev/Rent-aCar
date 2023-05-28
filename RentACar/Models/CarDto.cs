using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class CarDto
    {
        public List<CarClass> CarClasses { get; set; }
        public List<CarMarka> CarMarkas { get; set; }
        public List<CarType> CarTypes { get; set; }
    }
}