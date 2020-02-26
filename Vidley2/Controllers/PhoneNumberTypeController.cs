using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using Vidley2.ViewModels;

namespace Vidley2.Controllers
{
    public class PhoneNumberTypeController : Controller
    {
        private ApplicationDbContext _context;
        public PhoneNumberTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Phone Number Type
        public ViewResult Index()
        {
            var phoneNumberType = _context.PhoneNumberTypes;
            return View(phoneNumberType);
        }

        public ActionResult PhoneNumberTypeForm()
        {
            var viewModel = new PhoneNumberTypeFormViewModel
            {
                PhoneNumberType = new PhoneNumberType(),

            };
            return View("PhoneNumberTypeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(PhoneNumberType phoneNumberType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PhoneNumberTypeFormViewModel
                {
                    PhoneNumberType = phoneNumberType,

                };
                return View("PhoneNumberTypeForm", viewModel);
            }
            if (phoneNumberType.Id == 0)
                _context.PhoneNumberTypes.Add(phoneNumberType);

            else
            {
                var phoneNumberTypeInDb = _context.PhoneNumberTypes.Single(m => m.Id == phoneNumberType.Id);
                phoneNumberTypeInDb.Type = phoneNumberType.Type;


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "PhoneNumberType");
        }
        public ActionResult Details(int id)
        {
            var phoneNumberType = _context.PhoneNumberTypes.SingleOrDefault(m => m.Id == id);
            if (phoneNumberType == null)
                return HttpNotFound();

            return View(phoneNumberType);
        }

        public ActionResult Edit(int id)
        {
            var phoneNumberType = _context.PhoneNumberTypes.SingleOrDefault(m => m.Id == id);
            if (phoneNumberType == null)
                return HttpNotFound();

            var viewModel = new PhoneNumberTypeFormViewModel

            {
                PhoneNumberType = phoneNumberType,
            };

            return View("PhoneNumberType", viewModel);

        }
    }
}
