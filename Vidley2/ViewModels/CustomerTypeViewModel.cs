using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;

namespace Vidley2.ViewModels
{
    public class CustomerTypeViewModel
    {
        public int CustomerTypeId { get; set; }
        public CustomerType Customertype { get; set; }
    }
}