using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidley2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Stock { get; set; }
        public ICollection<CustomerMovieRental> CustomerMovieRentals { get; set; }
    }
}