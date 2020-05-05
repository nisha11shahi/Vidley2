using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;
namespace Vidley2.ViewModels
{
    public class StaffPhoneNumberFormViewModel
    {
        public int StaffPhoneNumberId { get; set; }
        public StaffPhoneNumber StaffPhoneNumber { get; set; }
        public IEnumerable<PhoneNumberType> PhoneNumberTypes { get; set; }
    }
}