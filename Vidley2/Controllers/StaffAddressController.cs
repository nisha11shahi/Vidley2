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
    public class StaffAddressController : Controller
    {
        private ApplicationDbContext _context;
        public StaffAddressController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: StaffAddress
        public ActionResult Index()
        {
            var customerAddress = _context.CustomerAddress;
            //.Include(c => c.MembershipType).ToList()
            return View(customerAddress);
        }
        public ActionResult StaffAddressForm(int staffId)
        {
            var viewModel = new StaffAddressViewModel
            {
                StaffAddress = new StaffAddress()
                {
                    StaffId = staffId,
                },
                AddressTypes = _context.AddressTypes.ToList()
            };
            return View("StaffAddressForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StaffAddress staffAddress)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StaffAddressViewModel
                {
                    StaffAddress = staffAddress,
                    AddressTypes = _context.AddressTypes.ToList()
                };
                return View("StaffAddressForm", viewModel);
            }
            if (staffAddress.Id == 0)
                _context.StaffAddresses.Add(staffAddress);

            else
            {
                var staffAddressInDb = _context.CustomerAddress.Single(m => m.Id == staffAddress.Id);
                staffAddressInDb.AddressTypeId = staffAddress.AddressTypeId;
                staffAddressInDb.StreetAddress = staffAddress.StreetAddress;
                staffAddressInDb.Address2 = staffAddress.Address2;
                staffAddressInDb.City = staffAddress.City;
                staffAddressInDb.State = staffAddress.State;
                staffAddressInDb.ZipCode = staffAddress.ZipCode;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Staff", new { id = staffAddress.StaffId });
        }
        public ActionResult Edit(int id)
        {
            var staffAddress = _context.StaffAddresses.SingleOrDefault(c => c.Id == id);
            if (staffAddress == null)
                return HttpNotFound();
            var viewModel = new StaffAddressViewModel
            {
                StaffAddress = staffAddress,
                AddressTypes = _context.AddressTypes.ToList()
            };

            return View("StaffAddressForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var staffAddress = _context.StaffAddresses.Include(x => x.AddressType).SingleOrDefault(m => m.Id == id);
            if (staffAddress == null)
                return HttpNotFound();
            var viewModel = new StaffAddressViewModel
            {
                StaffAddressId = id,
                StaffAddress = staffAddress,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int StaffAddressId)
        {
            var staffAddress = _context.StaffAddresses.SingleOrDefault(m => m.Id == StaffAddressId);
            _context.StaffAddresses.Remove(staffAddress);

            _context.SaveChanges();

            return RedirectToAction("Details", "Staff", new { id = staffAddress.StaffId });
        }
    }
}