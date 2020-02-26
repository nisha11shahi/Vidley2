using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer's Name.")]
        [StringLength(255)]

        public string Name { get; set; }
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }


        [Display(Name = "Phone Number Type")]
        public PhoneNumberType PhoneNumberType { get; set; }

        public int PhoneNumberTypeId { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }


        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]

        public DateTime Birthdate { get; set; }

        //public ICollection<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }
        //public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    
    }
}