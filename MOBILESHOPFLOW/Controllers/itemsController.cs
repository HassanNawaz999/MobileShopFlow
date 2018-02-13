using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MOBILESHOPFLOW.Controllers
{
    public class itemsController : Controller
    {
        dbMobileShopContext ourdbcontxt = null;
        //step 02
        public itemsController(dbMobileShopContext _ourdbContext)
        {
            ourdbcontxt = _ourdbContext;
        }
        //HERE IS ITEM CODE
        [HttpGet]
        public IActionResult addItem()
        {
            ViewData["CatagoryId"] = new SelectList(ourdbcontxt.TblCatagories, "CatagoryId", "CatagoryName", "---Select a CataGory---");
            return View();
        }
        [HttpPost]
        public IActionResult addItem(TblItem ti)
        {
            ourdbcontxt.TblItem.Add(ti);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(itemsController.viewAllItems));
        }
        public IActionResult viewAllItems()
        {
            return View(ourdbcontxt.TblItem.ToList<TblItem>());
        }
        //FOR SOWING DETAILS ON ONE ITEM
        public IActionResult itemDetails(int id)
        {
            TblItem ti = ourdbcontxt.TblItem.Where(abc => abc.ItemId == id).FirstOrDefault<TblItem>();
            return View(ti);
        }
        //FOR DELETING ITEMS
        public IActionResult removeItem(TblItem ti)
        {
            ourdbcontxt.TblItem.Remove(ti);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(itemsController.viewAllItems));
        }
        //CODE FOR EDIT ITEM DETAILS
        [HttpGet]
        public IActionResult EditItem(int iid)
        {
            TblItem iObj = ourdbcontxt.TblItem.Where(abc => abc.ItemId == iid).FirstOrDefault<TblItem>();
            return View(iObj);
        }
        [HttpPost]
        public IActionResult EditItem(TblItem ti)
        {
            ourdbcontxt.TblItem.Update(ti);
            ourdbcontxt.SaveChanges();
            return RedirectToAction(nameof(itemsController.viewAllItems));
        }
        //FOR COUNT USING .LAOD FUNCTION
        public int countItems()
        {
            return ourdbcontxt.TblItem.Count<TblItem>();
        }

    }
}