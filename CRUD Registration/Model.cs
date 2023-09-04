using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchWorld.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string FormattedDob => Dob.ToString("yyyy-MM-dd");
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}