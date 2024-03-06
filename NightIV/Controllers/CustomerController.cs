using NightIV.Context;
using System.Data.Entity;
using NightIV.Models;
using NightIV.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightIV.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }








        // GET: Customer
        [Route("Customer")]
        public ActionResult Customer()

            
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            /*  var customers = new List<Customer>
              {
                  new Customer {Id=1,Name="Customer 1",Email="Customer1@gmail.com",Password="Customer 1 Password"},
                  new Customer {Id=2,Name="Customer 2",Email="Customer2@gmail.com",Password="Customer 2 Password"}
              };
              var modelView = new CustomerView
              {
                  Customer = customers
              };*/
            return View(customers);
        }
        [Route("Customer/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

          /*  if(customer !=null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
          */
            
        }

      /*  private Customer GetCustomerById(int id)
        {
            var customer = new List<Customer>
            {
                new Customer {Id=1,Name="Customer 1",Email="Customer1@gmail.com",Password="Customer 1 Password"},
                new Customer {Id=2,Name="Customer 2",Email="Customer2@gmail.com",Password="Customer 2 Password"}
            };

            return customer.FirstOrDefault(c => c.Id == id);
        }
      */
    }
}