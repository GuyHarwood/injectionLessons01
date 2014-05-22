using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Web.Controllers
{
    public class ClosureController : Controller
    {
        private readonly string _myDesiredSetting;

        public ClosureController()
        {
            _myDesiredSetting = System.Configuration.ConfigurationManager.ConnectionStrings["branchFlag_doSoemthing"].ConnectionString;
        }

        public ClosureController(string myDesiredSetting)
        {
            this._myDesiredSetting = myDesiredSetting;
        }

        public ActionResult Index()
        {
            
            return View();
        }

    }
}
