using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley2.Models;
using Vidley2.ViewModels;

namespace Vidley2.Controllers
{
    public class MembershipTypeController : Controller
    {
        private ApplicationDbContext _context;
        public MembershipTypeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MembershipTypes
        public ViewResult Index()
        {
            var membershiptype = _context.MembershipTypes;
            return View(membershiptype);
        }

        public ActionResult MembershipTypeForm()
        {
            var viewModel = new MembershipTypeFormViewModel
            {
                Membershiptype = new MembershipType(),

            };
            return View("MembershipTypeForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MembershipType membershipType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MembershipTypeFormViewModel
                {
                    Membershiptype = membershipType,

                };
                return View("MembershipTypeForm", viewModel);
            }
            if (membershipType.Id == 0)
                _context.MembershipTypes.Add(membershipType);

            else
            {
                var membershipTypeInDb = _context.MembershipTypes.Single(m => m.Id == membershipType.Id);
                membershipTypeInDb.Type = membershipType.Type;
                membershipTypeInDb.SignUpFee = membershipType.SignUpFee;
                membershipTypeInDb.DurationInMonths = membershipType.DurationInMonths;
                membershipTypeInDb.DiscountRate = membershipType.DiscountRate;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MembershipType");
        }
        public ActionResult Details(int id)
        {
            var membershiptype = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);
            if (membershiptype == null)
                return HttpNotFound();

            return View(membershiptype);
        }

        public ActionResult Edit(int id)
        {
            var membershiptype = _context.MembershipTypes.SingleOrDefault(m => m.Id == id);
            if (membershiptype == null)
                return HttpNotFound();

            var viewModel = new MembershipTypeFormViewModel
            {
                Membershiptype = membershiptype,
            };

            return View("MembershipTypeForm", viewModel);

        }
    }
}