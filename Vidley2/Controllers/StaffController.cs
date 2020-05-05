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
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;
        public StaffController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Staff
        public ViewResult Index()
        {
            var staff = _context.Staffs;
            return View(staff);
        }

        public ActionResult StaffForm()
        {
            var addressTypes = _context.AddressTypes.ToList();
            var phoneNumberTypes = _context.PhoneNumberTypes.ToList();
            var viewModel = new StaffFormViewModel
            {
                Staff = new Staff(),
                AddressTypes = addressTypes,
                PhoneNumberTypes = phoneNumberTypes
            };
            return View("StaffForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StaffFormViewModel
                {
                    Staff = staff,
                    AddressTypes = _context.AddressTypes.ToList(),
                    PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
                };
                return View("StaffForm", viewModel);
            }
            if (staff.Id == 0)
                _context.Staffs.Add(staff);

            else
            {
                var staffInDb = _context.Staffs.Single(c => c.Id == staff.Id);
                staffInDb.FirstName = staff.FirstName;
                staffInDb.MiddleName = staff.MiddleName;
                staffInDb.LastName = staff.LastName;
                staffInDb.Email = staff.Email;
                staffInDb.HireDate = staff.HireDate;
                staffInDb.TerminationDate = staff.TerminationDate;
                staffInDb.StreetAddress = staff.StreetAddress;
                staffInDb.EmergencyContactName = staff.EmergencyContactName;
                staffInDb.EmergencyContactAddress = staff.EmergencyContactAddress;
                staffInDb.EmergencyContactPhone = staff.EmergencyContactPhone;
                staffInDb.EmergencyContactRelationship = staff.EmergencyContactRelationship;
            }

                        _context.SaveChanges();
            return RedirectToAction("Index", "Staff");
        }
        public ActionResult Details(int id)
        {
            var staff = _context.Staffs.Include(c => c.StaffPhoneNumbers.Select(x => x.PhoneNumberType))
                .Include(c => c.StaffAddresses.Select(x => x.AddressType)).SingleOrDefault(c => c.Id == id);
            if (staff == null)
                return HttpNotFound();

            return View(staff);
        }

        public ActionResult Edit(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(c => c.Id == id);
            if (staff == null)
                return HttpNotFound();

            var viewModel = new StaffFormViewModel
            {
                Staff = staff,
                AddressTypes = _context.AddressTypes.ToList(),
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };

            return View("StaffForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(m => m.Id == id);
            if (staff == null)
                return HttpNotFound();
            var viewModel = new StaffFormViewModel
            {
                StaffId = id,
                Staff = staff,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int StaffId)
        {
            var staff = _context.Staffs.SingleOrDefault(m => m.Id == StaffId);
            _context.Staffs.Remove(staff);
            _context.SaveChanges();

            return RedirectToAction("Index", "Staff");
            //RedirectToAction("Index", "Staffs", new { id = customerMovieRental.CustomerId });
        }

    }
}