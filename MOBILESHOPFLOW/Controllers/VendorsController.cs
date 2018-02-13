
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Controllers
{
    public class VendorsController : Controller
    { dbMobileShopContext ourdbCntxt = null;
        public VendorsController(dbMobileShopContext _ourdbContext)
        {
            ourdbCntxt = _ourdbContext;
        }

        //HERE IS VENDORS CODE
        [HttpGet]
        public IActionResult addVendor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addVendor(TblVendor tv)
        {
            //var t = ourdbCntxt.TblVendor.Find(tv.vendorId);
            ourdbCntxt.TblVendor.Add(tv);
            ourdbCntxt.SaveChanges();
            return RedirectToAction(nameof(VendorsController.viewAllVendors));
        }
        public IActionResult vendorDetails(int vNum)
        {
            TblVendor tv = ourdbCntxt.TblVendor.Where(abc => abc.VendorId == vNum).FirstOrDefault<TblVendor>();
            return View(tv);
        }
        public IActionResult removeVendor(TblVendor tv)
        {
            ourdbCntxt.TblVendor.Remove(tv);
            ourdbCntxt.SaveChanges();
            return RedirectToAction(nameof(VendorsController.viewAllVendors));
        }
        //FUNTION FOR EDIT VENDORS 
        [HttpGet]
        public IActionResult editVendor(int vid)
        {
            TblVendor obj=ourdbCntxt.TblVendor.Where(abc => abc.VendorId == vid).FirstOrDefault<TblVendor>();
            //  return RedirectToAction(nameof(FirstController.editVendor));
            return View(obj);
        }
        [HttpPost]
        public IActionResult editVendor(TblVendor tv)
        {
            ourdbCntxt.TblVendor.Update(tv);
            ourdbCntxt.SaveChanges();
            return RedirectToAction(nameof(VendorsController.viewAllVendors));
        }
        public IActionResult viewAllVendors()
        {
            return View(ourdbCntxt.TblVendor.ToList<TblVendor>());
        }
        public int countVendor()
        {
            return ourdbCntxt.TblVendor.Count<TblVendor>();
        }
    }
}