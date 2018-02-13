using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Controllers
{
    public class CatagoriesController : Controller
    {
        dbMobileShopContext dbContet = null;
        //step 02
        public CatagoriesController(dbMobileShopContext _ourdbContext)
        {
            dbContet = _ourdbContext;
        }
        //HERE IS CATAGOIRY CODE
        [HttpGet]
        public IActionResult catagories()
        {
            return View();
        }
        [HttpPost]
        public IActionResult catagories(TblCatagories tc)
        {
            dbContet.TblCatagories.Add(tc);
            dbContet.SaveChanges();
            return RedirectToAction(nameof(CatagoriesController.viewAllCatagories));
        }
        public IActionResult viewAllCatagories()
        {
            return View(dbContet.TblCatagories.ToList<TblCatagories>());
        }
        public IActionResult CatagoryDetails(int cnum)
        {
            TblCatagories tc = dbContet.TblCatagories.Where(abc => abc.CatagoryId == cnum).FirstOrDefault<TblCatagories>();
            return View(tc);
        }
        public IActionResult removeCatagory(TblCatagories tc)
        {
            //TblCatagories tc = ourdbContext.TblCatagories.Where(abc => abc.CatagoryId == num).FirstOrDefault<TblCatagories>();
            dbContet.TblCatagories.Remove(tc);
            dbContet.SaveChanges();
            return RedirectToAction(nameof(CatagoriesController.viewAllCatagories));
        }

        public IActionResult editCatagories(int id)
        {
            // TblCatagories tbc = new TblCatagories();

            return View();
            //ourdbContext.TblCatagories.Add(tc);
            // ourdbContext.SaveChanges();

        }
        //FOR COUNTER USING LOAD FUNCTION
        public int countCatagory()
        {
            return dbContet.TblCatagories.Count<TblCatagories>();
        }
        //HERE IS EDIT CODE OF CATAGORIES
        [HttpGet]
        public IActionResult EditCatagory(int cid)
        {
            TblCatagories obj = dbContet.TblCatagories.Where(abc => abc.CatagoryId == cid).FirstOrDefault<TblCatagories>();
            return View(obj);
        }
        [HttpPost]
        public IActionResult EditCatagory(TblCatagories tc)
        {
            dbContet.TblCatagories.Update(tc);
            dbContet.SaveChanges();
            return RedirectToAction(nameof(CatagoriesController.viewAllCatagories));
        }

    }
}