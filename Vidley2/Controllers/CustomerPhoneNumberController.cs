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
    public class CustomerPhoneNumberController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerPhoneNumberController()
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
            var customerPhoneNumber = _context.CustomerPhoneNumbers;
                //.Include(c => c.MembershipType).ToList()
            return View(customerPhoneNumber);
        }
        public ActionResult CustomerPhoneNumberTypeForm(int customerId)
        {
            var viewModel = new CustomerPhoneNumberFormViewModel
            {
                CustomerPhoneNumber = new CustomerPhoneNumber() {
                    CustomerId = customerId,
                },
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };
            return View("CustomerPhoneNumberTypeForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerPhoneNumber customerPhoneNumber)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerPhoneNumberFormViewModel
                {
                    CustomerPhoneNumber = customerPhoneNumber,
                    PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
                };
                return View("CustomerPhoneNumberForm", viewModel);
            }
            if (customerPhoneNumber.Id == 0)
                _context.CustomerPhoneNumbers.Add(customerPhoneNumber);

            else
            {
                var customerPhoneNumberInDb = _context.CustomerPhoneNumbers.Single(m => m.Id == customerPhoneNumber.Id);
                customerPhoneNumberInDb.PhoneNumberTypeId = customerPhoneNumber.PhoneNumberTypeId;
                customerPhoneNumberInDb.PhoneNumber = customerPhoneNumber.PhoneNumber;
                customerPhoneNumberInDb.PhoneExtension = customerPhoneNumber.PhoneExtension;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Customers", new { id = customerPhoneNumber.CustomerId});
        }
        public ActionResult Edit(int id)
        {
            var customerPhoneNumber = _context.CustomerPhoneNumbers.SingleOrDefault(c => c.Id == id);
            if (customerPhoneNumber == null)
                return HttpNotFound();
            var viewModel = new CustomerPhoneNumberFormViewModel
            {
                CustomerPhoneNumber = customerPhoneNumber,
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };

            return View("CustomerPhoneNumberTypeForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var customerPhoneNumber = _context.CustomerPhoneNumbers.Include(x=>x.PhoneNumberType).SingleOrDefault(m => m.Id == id);
            if (customerPhoneNumber == null)
                return HttpNotFound();
            var viewModel = new CustomerPhoneNumberFormViewModel
            {
                CustomerPhoneNumberId = id,
                CustomerPhoneNumber = customerPhoneNumber,
            };

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult DeleteConfirm(int CustomerPhoneNumberId)
        {
            var customerPhoneNumber = _context.CustomerPhoneNumbers.SingleOrDefault(m => m.Id == CustomerPhoneNumberId);
            _context.CustomerPhoneNumbers.Remove(customerPhoneNumber);

            _context.SaveChanges();

            return RedirectToAction("Details", "Customers", new { id = customerPhoneNumber.CustomerId });
        }
    }
}