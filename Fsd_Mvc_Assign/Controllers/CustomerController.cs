using System;
using System.Web.Mvc;

namespace Fsd_Mvc_Assign.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer GetCustomerInstance()
        {
            return CustomerFactory.GetCustomerInstance(InstanceType.Dataset);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var custDao = GetCustomerInstance();
            return View(custDao.GetList());            
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var cust = new Models.Customer();
            return View(cust);            
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Models.Customer newCustomer)
        {
            try
            {
                // TODO: Add insert logic here
                var custDao = GetCustomerInstance();
                custDao.InsertCustomer(newCustomer);
                return RedirectToAction("Index");                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Update(Models.Customer originalCustomer)
        {
            return View(originalCustomer);            
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Update(Models.Customer modifiedCustomer, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var custDao = GetCustomerInstance();
                custDao.ModifyCustomer(modifiedCustomer);
                return RedirectToAction("Index");                
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(string custId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var custDao = GetCustomerInstance();
                custDao.DeleteCustomer(custId);
                return RedirectToAction("Index");                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Customerseach()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Customerseach(string date)
        {
            var custDao = GetCustomerInstance();
            var dateParts = date.Split('/');
            var dob = new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[0]), int.Parse(dateParts[1]));
            return View(custDao.SearchCustomer(dob));
        }

    }
}

