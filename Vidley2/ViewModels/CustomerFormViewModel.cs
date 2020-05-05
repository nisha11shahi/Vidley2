using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;

namespace Vidley2.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public IEnumerable<PhoneNumberType> PhoneNumberTypes { get; set; }
        public Customer Customer { get; set; }

        


    }
}