using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOBILESHOPFLOW.Models;

namespace MOBILESHOPFLOW.Controllers
{
    public class dashboardController : Controller
    {
        //here is step01 for demanding dbcontext in controller
        dbMobileShopContext ourdbContext = null;

        //step 02
        public dashboardController(dbMobileShopContext _ourdbContext)
        {
            ourdbContext = _ourdbContext;
        }
        //HERE IS DASHBOARD CODE
       
        public IActionResult dashboard()
        {
            return View();
        }
       
    }
}