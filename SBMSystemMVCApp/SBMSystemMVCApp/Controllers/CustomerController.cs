using SBMSystemMVCApp.BLL.BLL;
using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBMSystemMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerManager _customerManager;
        public CustomerController()
        {
            _customerManager = new CustomerManager();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Customer());
        }
        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            if(ModelState.IsValid)
            {
                if(_customerManager.IsCodeDuplicate(customer))
                {
                    ViewBag.FailMsg = "Code is Duplicate";
                    customer.Code = "";
                    return View(customer);
                }
                if(_customerManager.Add(customer))
                {
                    ViewBag.SuccessMsg = "Successfully Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Save Failed";
                }
            } 
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            return View(new Customer());
        }
        [HttpGet]
        public ActionResult Search()
        {
            List<Customer> customers;
            customers = null;
            return View(customers);
        }
        [HttpPost]
        public ActionResult Search(Customer customer)
        {
            var customers = _customerManager.GetAll();
            if(customer.Code!=null)
            {
                customers = customers.Where(c => c.Code.ToLower() == customer.Code.ToLower()).ToList();
            }
            if (customer.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }
            if (customer.Address != null)
            {
                customers = customers.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower())).ToList();
            }
            if (customer.Email != null)
            {
                customers = customers.Where(c => c.Email == customer.Email).ToList();
            }
            if (customer.Contact != null)
            {
                customers = customers.Where(c => c.Contact == customer.Contact).ToList();
            }
            return View(customers);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            List<Customer> customers;
            customers = null;
            return View(customers);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customers = _customerManager.GetAll();
            if (customer.Code != null)
            {
                customers = customers.Where(c => c.Code.ToLower() == customer.Code.ToLower()).ToList();
            }
            if (customer.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }
            if (customer.Address != null)
            {
                customers = customers.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower())).ToList();
            }
            if (customer.Email != null)
            {
                customers = customers.Where(c => c.Email == customer.Email).ToList();
            }
            if (customer.Contact != null)
            {
                customers = customers.Where(c => c.Contact == customer.Contact).ToList();
            }
            return View(customers);
        }       
        [HttpGet]
        public ActionResult Update(int id)
        {
            Customer aCustomer = _customerManager.GetById(id);
            return View(aCustomer);
        }
        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var aCustomer = _customerManager.GetById(customer.Id);
                aCustomer.Name = customer.Name;
                aCustomer.Address = customer.Address;
                aCustomer.Email = customer.Email;
                aCustomer.Contact = customer.Contact;
                aCustomer.LoyaltyPoint = customer.LoyaltyPoint;
                aCustomer.Code = customer.Code;
                if (_customerManager.isUpdated(aCustomer))
                {
                    ViewBag.SuccessMsg = "Successfully Updated";
                    customer.Name = "";
                    customer.Code = "";
                    customer.Address = "";
                    customer.Email = "";
                    customer.Contact = "";
                    customer.LoyaltyPoint = 0;
                }
                else
                {
                    ViewBag.FailMsg = "Update Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            return View(customer);
        }
    }
}