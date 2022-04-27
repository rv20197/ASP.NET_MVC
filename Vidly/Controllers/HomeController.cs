using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server,VaryByParam = "*")]
        [OutputCache(Duration = 0,VaryByParam = "*",NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }
    }
}