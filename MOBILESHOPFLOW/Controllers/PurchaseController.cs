using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MOBILESHOPFLOW.Controllers
{
    public class PurchaseController : Controller
    {
        dbMobileShopContext ourdbcontxt = null;
        //step 02
        public PurchaseController(dbMobileShopContext _ourdbContext)
        {
            ourdbcontxt = _ourdbContext;
        }
        //code for purchase new quantity
        [HttpGet]
        public IActionResult purchaseNewQuantity()
        {
            ViewData["VendorId"] = new SelectList(ourdbcontxt.TblVendor, "VendorId", "Name" , "---Select a Vendor---");
            ViewData["ItemId"] = new SelectList(ourdbcontxt.TblItem, "ItemId", "Name", "---Select an Item---");
            ViewData["CatagoryId"] = new SelectList(ourdbcontxt.TblCatagories, "CatagoryId", "CatagoryName", "---Select a CataGory---");
            return View();

        }

        [HttpPost]
        public IActionResult purchaseNewQuantity(TblPurchase tp)
        {
            ourdbcontxt.TblPurchase.Add(tp);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(PurchaseController.purchaseHistory));
        }
      
        //DETAILS OF PURCHASE FUCNTION
        public IActionResult PurchaseDetails(int pNum)
        {
            TblPurchase tp = ourdbcontxt.TblPurchase.Where(abc => abc.PurchaseId == pNum).FirstOrDefault<TblPurchase>();
            return View(tp);
        }
        public IActionResult RemovePurchaseRecode(TblPurchase tp)
        {
            ourdbcontxt.TblPurchase.Remove(tp);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(PurchaseController.purchaseHistory));
        }
        //PURCHASE HISTORY FUNCTION
        public IActionResult purchaseHistory()
        {
            return View(ourdbcontxt.TblPurchase.ToList<TblPurchase>());
        }
        //PURCAHSE COUNTER
        public int countPurchase()
        {
            return ourdbcontxt.TblPurchase.ToList<TblPurchase>().Count;
        }


    }
}