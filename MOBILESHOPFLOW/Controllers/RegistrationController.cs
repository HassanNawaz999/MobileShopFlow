using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Controllers
{
    public class RegistrationController : Controller
    {
        dbMobileShopContext mydbCntxt = null;
        public RegistrationController(dbMobileShopContext _ourdbContext)
        {
            mydbCntxt = _ourdbContext;
        }
        [HttpGet]
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(tblUser tr)
        {
            mydbCntxt.tblUser.Add(tr);
            mydbCntxt.SaveChanges();
            return RedirectToAction(nameof(RegistrationController.viewAllUsers));
        }
        //HERE IS LOGIN FORM CODE
        [HttpGet]
        public IActionResult loginForm()
        {
            return View();
        }
<<<<<<< HEAD
        //  [HttpPost]
        //public IActionResult loginForm(tblUser obj)
        //{
        //    tblUser UObj = mydbCntxt.tblUser.Where(abc => abc.name == obj.name).FirstOrDefault<tblUser>();
        //    if(UObj!=null)
        //    {
        //     if(UObj.password==obj.password)
        //        {
        //            return RedirectToAction("dashboard", "dashboard");
        //        }
        //     else
        //        {
        //            ViewBag.ErrorMessage = "Incorrect Password";
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "Incorrect User Name";
        //        return View();
        //    }

        //}
        [HttpPost]
        public IActionResult loginForm(string uname, string upassword)
        {
            tblUser obj = mydbCntxt.tblUser.Where(abc => abc.name == uname).FirstOrDefault<tblUser>();
            if (obj.password == upassword)
            {
                return RedirectToAction("dashboard", "dashboard");
            }
            else
            {
                return View();
            }
        }
=======
>>>>>>> 1f469b961d7db5815e8fafb2b87cdccf442cca9c

        public IActionResult viewAllUsers()
        {
            return View(mydbCntxt.tblUser.ToList<tblUser>());
            
        }
        public IActionResult userDetails(int uNum)
        {
            tblUser tu = mydbCntxt.tblUser.Where(abc => abc.userId == uNum).FirstOrDefault<tblUser>();
            return View(tu);
        }
        public IActionResult removeUser(tblUser tu)
        {
            mydbCntxt.tblUser.Remove(tu);
            mydbCntxt.SaveChanges();
            return RedirectToAction(nameof(RegistrationController.viewAllUsers));
        }
        //for count user
        public int userCount()
        {
            return mydbCntxt.tblUser.ToList<tblUser>().Count;
        }

    }
    }