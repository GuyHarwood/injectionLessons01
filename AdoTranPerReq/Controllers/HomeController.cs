using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Core;

namespace ContactManager.Web.Controllers
{
    public class HomeController : Controller
    {
	    private readonly Logger logger;

	    public HomeController(Logger logger)
	    {
		    this.logger = logger;
	    }

	    public ActionResult Index()
        {
            return View();
        }

	    public ActionResult Logs()
	    {
		    return View(new HomeLogsModel()
		    {
			    Logs = logger.CurrentSnapshot()
		    });
	    }
    }

	public class HomeLogsModel
	{
		public IEnumerable<string> Logs { get; set; }
	}
}
