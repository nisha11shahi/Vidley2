using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using Vidley2.ViewModels;
using System.Data.Entity;

namespace Vidley2.Controllers
{
    [Authorize]
    public class CustomerAddressController : Controller
    {
        // GET: CustomerAddress
        private ApplicationDbContext _context;
        public CustomerAddressController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CustomerPhoneNumber
        public ActionResult Index()
        {
            var customerAddress = _context.CustomerAddress;
            //.Include(c => c.MembershipType).ToList()
            return View(customerAddress);
        }
        public ActionResult CustomerAddressForm(int customerId)
        {
            var viewModel = new CustomerAddressViewModel
            {
                CustomerAddress = new CustomerAddress()
                {
                    CustomerId = customerId,
                },
                AddressTypes = _context.AddressTypes.ToList()
            };
            return View("CustomerAddressForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerAddress customerAddress)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerAddressViewModel
                {
                    CustomerAddress = customerAddress,
                    AddressTypes = _context.AddressTypes.ToList()
                };
                return View("CustomerAddressForm", viewModel);
            }
            if (customerAddress.Id == 0)
                _context.CustomerAddress.Add(customerAddress);

            else
            {
                var customerAddressInDb = _context.CustomerAddress.Single(m => m.Id == customerAddress.Id);
                customerAddressInDb.AddressTypeId = customerAddress.AddressTypeId;
                customerAddressInDb.StreetAddress = customerAddress.StreetAddress;
                customerAddressInDb.Address2 = customerAddress.Address2;
                customerAddressInDb.City = customerAddress.City;
                customerAddressInDb.State = customerAddress.State;
                customerAddressInDb.ZipCode = customerAddress.ZipCode;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = customerAddress.CustomerId });
        }
        public ActionResult Edit(int id)
        {
            var customerAddress = _context.CustomerAddress.SingleOrDefault(c => c.Id == id);
            if (customerAddress == null)
                return HttpNotFound();
            var viewModel = new CustomerAddressViewModel
            {
                CustomerAddress = customerAddress,
                AddressTypes = _context.AddressTypes.ToList()
            };

            return View("CustomerAddressForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var customerAddress = _context.CustomerAddress.Include(x => x.AddressType).SingleOrDefault(m => m.Id == id);
            if (customerAddress == null)
                return HttpNotFound();
            var viewModel = new CustomerAddressViewModel
            {
                CustomerAddressId = id,
                CustomerAddress = customerAddress,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int CustomerAddressId)
        {
            var customerAddress = _context.CustomerAddress.SingleOrDefault(m => m.Id == CustomerAddressId);
            _context.CustomerAddress.Remove(customerAddress);

            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = customerAddress.CustomerId });
        }
    }
}