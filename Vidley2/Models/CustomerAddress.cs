﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public AddressType AddressType { get; set; }
        public int AddressTypeId { get; set; }

        public string StreetAddress { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}