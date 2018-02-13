using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MOBILESHOPFLOW.Controllers
{
    public class SalesController : Controller
    {
        dbMobileShopContext ourdbcontxt = null;
        //step 02
        public SalesController(dbMobileShopContext _ourdbContext)
        {
            ourdbcontxt = _ourdbContext;
        }
        //HERE IS SALE ITEM CODE
        [HttpGet]
        public IActionResult SaleItem()
        {
            ViewData["ItemId"] = new SelectList(ourdbcontxt.TblItem, "ItemId", "Name", "---Select an Item---");
            ViewData["CatagoryId"] = new SelectList(ourdbcontxt.TblCatagories, "CatagoryId", "CatagoryName", "---Select a CataGory---");
            return View();
        }
        [HttpPost]
        public IActionResult SaleItem(TblSales ts)
        {

            ourdbcontxt.TblSales.Add(ts);
            ourdbcontxt.SaveChanges();
           return RedirectToAction(nameof(SalesController.SaleHistory));
        }
        //SALES ITEMS DETAILS ONE BY ONE 
        public IActionResult SaleDetails(int sNum)
        {
            TblSales ts = ourdbcontxt.TblSales.Where(abc => abc.SaleId == sNum).FirstOrDefault<TblSales>();
            return View(ts);
        }
       
        //SALE HISTORY CODE
        public IActionResult SaleHistory()
        {
            return View(ourdbcontxt.TblSales.ToList<TblSales>());
        }
    
        //FOR COUNTER USING LOAD FUNCTION
        public int CountSale()
        {
            return ourdbcontxt.TblSales.Count<TblSales>();
        }
        
    }
}