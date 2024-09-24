using System.Collections.Generic;
using System.Web.Mvc;
using WebMVC_Net.Filter;

namespace WebMVC_Net.Controllers
{
	public class HomeController : Controller
	{

		[Log]
		public ActionResult Index(int ? id)
		{
			var lst = new List<BE_2505.DataAccess.DTO.Student>();
			lst = new BE_2505.DataAccess.DALImpl.StudentManager().GetStudents();
			// trả về view 
			return View(lst);
		}



		public ActionResult DemoPartialView()
		{
			return PartialView();
		}

		[ActionName("myname")]
		public ActionResult Index()
		{			
			return View();
		}


		//[NonAction]
		//[HttpPost]		



		[HttpPost]
		
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}