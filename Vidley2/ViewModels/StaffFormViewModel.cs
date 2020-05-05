using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;
namespace Vidley2.ViewModels
{
    public class StaffFormViewModel
    {
        public IEnumerable<PhoneNumberType> PhoneNumberTypes { get; set; }
        public IEnumerable<AddressType> AddressTypes { get; set; }
        public Staff Staff { get; set; }

        public int StaffId { get; set; }
    }
}
