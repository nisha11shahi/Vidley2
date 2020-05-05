using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using Vidley2.ViewModels;


namespace Vidley2.Controllers
{
    [Authorize]
    public class AddressTypeController : Controller
    {
        private ApplicationDbContext _context;
        public AddressTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: AddressType
        public ViewResult Index()
        {
            var addresstype = _context.AddressTypes;
            return View(addresstype);
        }

        public ActionResult AddressTypeForm()
        {
            var viewModel = new AddressTypeFormViewModel
            {
                AddressType = new AddressType(),

            };
            return View("AddressTypeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(AddressType addressType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddressTypeFormViewModel
                {
                    AddressType = addressType,

                };
                return View("AddressTypeForm", viewModel);
            }
            if (addressType.Id == 0)
                _context.AddressTypes.Add(addressType);

            else
            {
                var addressTypeInDb = _context.AddressTypes.Single(m => m.Id == addressType.Id);
                addressTypeInDb.Type = addressType.Type;
                

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "AddressType");
        }
        public ActionResult Details(int id)
        {
            var addresstype = _context.AddressTypes.SingleOrDefault(m => m.Id == id);
            if (addresstype == null)
                return HttpNotFound();

            return View(addresstype);
        }

        public ActionResult Edit(int id)
        {
            var addresstype = _context.AddressTypes.SingleOrDefault(m => m.Id == id);
            if (addresstype == null)
                return HttpNotFound();

            var viewModel = new AddressTypeFormViewModel
            {
                AddressType = addresstype,
            };

            return View("AddressTypeForm", viewModel);

        }
    }
}
