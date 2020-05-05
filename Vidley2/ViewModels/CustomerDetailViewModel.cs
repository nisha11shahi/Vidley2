using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;

namespace Vidley2.ViewModels
{
    public class CustomerDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<CustomerMovieRental> CustomerMovieRentals { get; set; }
        public byte[] CustomerSignature { get; set; }
    }
}