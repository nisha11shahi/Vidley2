using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using System.Data.Entity;
using Vidley2.ViewModels;
namespace Vidley2.Controllers
{
    [Authorize]
    public class CustomerMovieRentalController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerMovieRentalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CustomerMovie
       
        public ActionResult CustomerMovieRentalForm(int customerId)
        {
            var viewModel = new CustomerMovieRentalViewModel
            {
                CustomerMovieRental = new CustomerMovieRental()
                {
                    CustomerId = customerId,
                },
              Movies = _context.Movies.ToList()
            };
            return View("CustomerMovieRentalForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerMovieRental customerMovieRental)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerMovieRentalViewModel
                {
                    CustomerMovieRental = customerMovieRental,
                    Movies = _context.Movies.ToList()
                };
                return View("CustomerMovieRentalForm", viewModel);
            }
            if (customerMovieRental.Id == 0)
                _context.CustomerMovieRentals.Add(customerMovieRental);

            else
            {
                var customerMovieRentalInDb = _context.CustomerMovieRentals.Single(m => m.Id == customerMovieRental.Id);
                customerMovieRentalInDb.CustomerId= customerMovieRental.CustomerId;
                customerMovieRentalInDb.MovieId = customerMovieRental.MovieId;
                customerMovieRentalInDb.Checkin = customerMovieRental.Checkin;
                customerMovieRentalInDb.Checkout = customerMovieRental.Checkout;
            }

            
            _context.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = customerMovieRental.CustomerId });
        }
        public ActionResult Edit(int id)
        {
            var customerMovieRental = _context.CustomerMovieRentals.SingleOrDefault(c => c.Id == id);
            if (customerMovieRental == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerMovieRentalViewModel
            {
                CustomerMovieRental = customerMovieRental,
                Movies = _context.Movies.ToList()
            };

            return View("CustomerMovieRentalForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var customerMovieRental = _context.CustomerMovieRentals.Include(x => x.Movies).SingleOrDefault(m => m.Id == id);
            if (customerMovieRental == null)
                return HttpNotFound();
            var viewModel = new CustomerMovieRentalViewModel
            {
                CustomerMovieRentalId = id,
                CustomerMovieRental = customerMovieRental,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int CustomerMovieRentalId)
        {
            var customerMovieRental = _context.CustomerMovieRentals.SingleOrDefault(m => m.Id == CustomerMovieRentalId);
            _context.CustomerMovieRentals.Remove(customerMovieRental);

            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = customerMovieRental.CustomerId });
        }
    }
}

