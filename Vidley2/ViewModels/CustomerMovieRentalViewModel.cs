using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley2.Models;

namespace Vidley2.ViewModels
{
    public class CustomerMovieRentalViewModel
    {
        public int CustomerMovieRentalId { get; set; }
        public CustomerMovieRental CustomerMovieRental { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

    }
}