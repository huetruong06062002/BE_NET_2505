using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_NetFrameWork.Models;

namespace WebMVC_NetFrameWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Định dạng ngày tháng theo ý muốn
            string formattedDate = currentDate.ToString("yyyyMMdd HH:mm:ss");

            // Truyền ngày tháng đến view thông qua ViewBag
            ViewBag.CurrentDate = formattedDate;


            var listStudent = new List<StudentModels>();


            return View();




         
        }

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