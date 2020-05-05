using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using Vidley2.ViewModels;

namespace Vidley2.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        // GET: Customer
        public ViewResult Index()
         {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var phoneNumberTypes = _context.PhoneNumberTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
                PhoneNumberTypes = phoneNumberTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save (Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });

                // Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.StreetAddress = customer.StreetAddress;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.PhoneNumberTypeId = customer.PhoneNumberTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.CustomerSignature = customer.CustomerSignature;
            }

           // _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType)
                .Include(c=>c.CustomerPhoneNumbers.Select(x => x.PhoneNumberType))
                .Include(c => c.CustomerAddresses.Select(x => x.AddressType))
                .Include(c => c.CustomerMovieRentals.Select(x => x.Movies))
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        
    }
}