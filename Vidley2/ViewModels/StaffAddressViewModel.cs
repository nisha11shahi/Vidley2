﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;
namespace Vidley2.ViewModels
{
    public class StaffAddressViewModel
    {
        public int StaffAddressId { get; set; }
        public StaffAddress StaffAddress { get; set; }
        public IEnumerable<AddressType> AddressTypes { get; set; }
    }
}
