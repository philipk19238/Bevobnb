using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace BevobnbTeam30.Models
{
    public class AppUser:IdentityUser
    {
        
        //First name is provided as an example
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String  Address { get; set; }

        public DateTime Birthday { get; set; }



        ////TODO: Add navigational properties


    }
}
