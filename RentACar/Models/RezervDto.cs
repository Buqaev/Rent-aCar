using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class RezervDto
    {
        public User User { get; set; }
        public Car Car { get; set; }
        public Rezerv Rezerv { get; set; }

        public List<Car> Cars { get; set; }


        /// <summary>  
        /// DOB datetime data type property   
        /// to display date type control  
        /// </summary>  
        [Display(Name = "Alinma Tarixi")]
        [DataType(DataType.Date)]
        public DateTime? Tim { get; set; }


        [Display(Name = "Qaytarma Tarixi")]
        [DataType(DataType.Date)]
        public DateTime? Tim2 { get; set; }
    }
}