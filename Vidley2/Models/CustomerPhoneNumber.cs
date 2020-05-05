using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class CustomerPhoneNumber
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneExtension { get; set; }

    }
}