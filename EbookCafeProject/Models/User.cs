using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbookCafeProject.Models
{
    public class User
    {
        public string userId { get; set; }  
        public string userName { get; set; }
        public string userEmail { get; set; }   
        public string userPassword { get; set; }
        public string userType { get; set; }

        //public DateTime userDOB { get; set; }
        //public string EmailConfirmed { get; set; }
        //public string PasswordConfirmed { get; set; }

    }
}