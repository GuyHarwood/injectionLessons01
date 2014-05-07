using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Core;

namespace ContactManager.Web.Controllers
{
    public class HomeController : Controller
    {
	    private readonly Logger logger;
	    private readonly UnitOfWork unitOfWork;

	    public HomeController(Logger logger, UnitOfWork unitOfWork)
	    {
		    this.logger = logger;
		    this.unitOfWork = unitOfWork;
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
