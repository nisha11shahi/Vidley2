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
    public class StaffPhoneNumberController : Controller
    {
        private ApplicationDbContext _context;
        public StaffPhoneNumberController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: StaffPhoneNumber
        
        public ActionResult Index()
        {
            var staffPhoneNumber = _context.StaffPhoneNumbers;
            //.Include(c => c.MembershipType).ToList()
            return View(staffPhoneNumber);
        }
        public ActionResult StaffPhoneNumberForm(int staffId)
        {
            var viewModel = new StaffPhoneNumberFormViewModel
            {
                StaffPhoneNumber = new StaffPhoneNumber()
                {
                    StaffId = staffId,
                },
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };
            return View("StaffPhoneNumberForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StaffPhoneNumber staffPhoneNumber)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StaffPhoneNumberFormViewModel
                {
                    StaffPhoneNumber = staffPhoneNumber,
                    PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
                };
                return View("StaffPhoneNumberForm", viewModel);
            }
            if (staffPhoneNumber.Id == 0)
                _context.StaffPhoneNumbers.Add(staffPhoneNumber);

            else
            {
                var staffPhoneNumberInDb = _context.StaffPhoneNumbers.Single(m => m.Id == staffPhoneNumber.Id);
                staffPhoneNumberInDb.PhoneNumberTypeId = staffPhoneNumber.PhoneNumberTypeId;
                staffPhoneNumberInDb.PhoneNumber = staffPhoneNumber.PhoneNumber;
                staffPhoneNumberInDb.PhoneExtension = staffPhoneNumber.PhoneExtension;
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Staff", new { id = staffPhoneNumber.StaffId });
        }
        public ActionResult Edit(int id)
        {
            var staffPhoneNumber = _context.StaffPhoneNumbers.SingleOrDefault(c => c.Id == id);
            if (staffPhoneNumber == null)
                return HttpNotFound();
            var viewModel = new StaffPhoneNumberFormViewModel
            {
                StaffPhoneNumber = staffPhoneNumber,
                PhoneNumberTypes = _context.PhoneNumberTypes.ToList()
            };

            return View("StaffPhoneNumberForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var staffPhoneNumber = _context.StaffPhoneNumbers.Include(x => x.PhoneNumberType).SingleOrDefault(m => m.Id == id);
            if (staffPhoneNumber == null)
                return HttpNotFound();
            var viewModel = new StaffPhoneNumberFormViewModel
            {
               StaffPhoneNumberId = id,
               StaffPhoneNumber = staffPhoneNumber,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int StaffPhoneNumberId)
        {
            var staffPhoneNumber = _context.StaffPhoneNumbers.SingleOrDefault(m => m.Id == StaffPhoneNumberId);
            _context.StaffPhoneNumbers.Remove(staffPhoneNumber);

            _context.SaveChanges();

            return RedirectToAction("Details", "Staff", new { id = staffPhoneNumber.StaffId });
        }
    }
}