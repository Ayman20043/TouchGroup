using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ContactUs
    {

        public int Id { get; set; }
        [Display(Name = "Egypt Address")]
        public string AddressEgy { get; set; }
        [Display(Name = "Egypt Telephone")]
        public string TelephoneEgy { get; set; }
        public string PhoneEgy { get; set; }
        [Display(Name = "Egypt Fax")]
        public string FaxEgy { get; set; }
        [Display(Name = "Egypt Mobile")]

        public string MobileEgy { get; set; }


        [Display(Name = "UAE Address")]

        public string AddressUAE { get; set; }
        [Display(Name = "UAE Telephone")]

        public string TelephoneUAE { get; set; }

        public string PhoneUAE { get; set; }
        [Display(Name = "UAE Fax")]

        public string FaxUAE { get; set; }
        [Display(Name = "UAE Mobile")]

        public string MobileUAE { get; set; }

    }
}