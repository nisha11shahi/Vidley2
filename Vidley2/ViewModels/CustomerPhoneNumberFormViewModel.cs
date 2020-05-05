using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;
namespace Vidley2.ViewModels
{
    public class CustomerPhoneNumberFormViewModel
    {
        public int CustomerPhoneNumberId { get; set; }
        public CustomerPhoneNumber CustomerPhoneNumber { get; set; }
        public IEnumerable<PhoneNumberType> PhoneNumberTypes { get; set; }
    }
}