using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class StaffPhoneNumber
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneExtension { get; set; }
    }
}