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
       
        public ActionResult New()
        {
            var memberShipTypes = _context.MembershipsTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = memberShipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var memberShipTypes = _context.MembershipsTypes.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = memberShipTypes

                };
                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                    // Mapper.Map(customer, customerInDb);

                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                    customerInDb.MemberShipType = customer.MemberShipType;
                    customerInDb.IsSubscribed = customer.IsSubscribed;
                }
                _context.SaveChanges();

                return RedirectToAction("Customer");
            
            
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MembershipsTypes.ToList()
            };

            return View("CustomerForm",viewModel);
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