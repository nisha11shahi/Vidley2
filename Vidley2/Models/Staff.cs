using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidley2.Models
{
    public class Staff
    {
        public int Id { get; set; }
    
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        
        [Display(Name = "Phone Number Type")]
  
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
       
        public string EmergencyContactName { get; set; }
        public string EmergencyContactAddress { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public ICollection<StaffPhoneNumber> StaffPhoneNumbers { get; set; }
        public ICollection<StaffAddress> StaffAddresses { get; set; }

    }
}