using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class UserDto
    {
        public User User { get; set; }
        public List<Rezerv> Rezervs { get; set; }

    }
}