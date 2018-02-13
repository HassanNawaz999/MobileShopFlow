using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Controllers
{
    public class CustomerController : Controller
    {
        dbMobileShopContext ourdbcontxt = null;
        //step 02
        public CustomerController(dbMobileShopContext _ourdbContext)
        {
            ourdbcontxt = _ourdbContext;
        }
        //HERE IS CUSTOMERS CODE
        [HttpGet]
        public IActionResult addCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addCustomer(TblCustomer tc)
        {
            ourdbcontxt.TblCustomer.Add(tc);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(CustomerController.viewAllCustomers));
        }
        public IActionResult viewAllCustomers()
        {
            return View(ourdbcontxt.TblCustomer.ToList<TblCustomer>());
        }
        //count function with .load
        public int countCustomers()
        {
            return ourdbcontxt.TblCustomer.Count<TblCustomer>();
        }
        //Function for customer details 
        public IActionResult customerDetail(int cnum)
        {
            TblCustomer tc = ourdbcontxt.TblCustomer.Where(abc => abc.Cusotmer_id == cnum).FirstOrDefault<TblCustomer>();
            return View(tc);
        }

        //Function for customer remove
        public IActionResult removeCusotmer(TblCustomer tc)
        {
            ourdbcontxt.TblCustomer.Remove(tc);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(CustomerController.viewAllCustomers));   
            
        }
        //FUNTION FOR EDIT Cusotmer
        [HttpGet]
        public IActionResult EditCustomer(int cid)
        {
            TblCustomer obj = ourdbcontxt.TblCustomer.Where(abc => abc.Cusotmer_id == cid).FirstOrDefault<TblCustomer>();
            return View(obj);
        }
        [HttpPost]
        public IActionResult EditCustomer(TblCustomer tc)
        {
            ourdbcontxt.TblCustomer.Update(tc);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(CustomerController.viewAllCustomers));
        }


    }
}