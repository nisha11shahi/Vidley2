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
    public class CustomerTypeController : Controller
    { 
    private ApplicationDbContext _context;
    public CustomerTypeController()
    {
        _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
        _context.Dispose();
    }

    // GET: CustomerMembershipTypes
    public ViewResult Index()
    {
        var customertype = _context.CustomerTypes;
        return View(customertype);
    }

    public ActionResult CustomerTypeForm()
    {
        var viewModel = new CustomerTypeViewModel
        {
            Customertype = new CustomerType(),

        };
        return View("CustomerTypeForm", viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(CustomerType customerType)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new CustomerTypeViewModel
            {
                Customertype = customerType,

            };
            return View("CustomerTypeForm", viewModel);
        }
        if (customerType.Id == 0)
            _context.CustomerTypes.Add(customerType);

        else
        {
            var customerTypeInDb = _context.CustomerTypes.Single(m => m.Id == customerType.Id);
                customerTypeInDb.Type = customerType.Type;
                customerTypeInDb.SignUpFee = customerType.SignUpFee;
                customerTypeInDb.DurationInMonths = customerType.DurationInMonths;
                customerTypeInDb.DiscountRate = customerType.DiscountRate;

        }
        _context.SaveChanges();
        return RedirectToAction("Index", "CustomerType");
    }
    public ActionResult Details(int id)
    {
        var customertype = _context.CustomerTypes.SingleOrDefault(m => m.Id == id);
        if (customertype == null)
            return HttpNotFound();

        return View(customertype);
    }
    public ActionResult Edit(int id)
        {
            var customertype = _context.CustomerTypes.SingleOrDefault(m => m.Id == id);
            if (customertype == null)
                return HttpNotFound();

            var viewModel = new CustomerTypeViewModel
            {
                Customertype = customertype,
            };

            return View("CustomerTypeForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customertype = _context.CustomerTypes.SingleOrDefault(m => m.Id == id);
            if (customertype == null)
                return HttpNotFound();
            var viewModel = new CustomerTypeViewModel
            {
                CustomerTypeId = id,
                Customertype = customertype,
            };

            return View(viewModel);
        }
        

        [HttpPost]
        public ActionResult DeleteConfirm(int CustomerTypeId)
        {
            var customertype = _context.CustomerTypes.SingleOrDefault(m => m.Id == CustomerTypeId);
            _context.CustomerTypes.Remove(customertype);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}