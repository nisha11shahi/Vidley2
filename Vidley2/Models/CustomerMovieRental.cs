using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class CustomerMovieRental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Movie Movies { get; set; }
        public int MovieId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime? Checkout { get; set; }
    }
}