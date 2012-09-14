using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MzM.SearchWordArticles.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to Search Word Article management";
			ViewBag.Title = "Search word articles";
			return View();
		}
	}
}
