using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;
namespace Vidley2.ViewModels
{
    public class CustomerAddressViewModel
    {
        public int CustomerAddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public IEnumerable<AddressType> AddressTypes { get; set; }
    }
}
