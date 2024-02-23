using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace ShopProject.Areas.Shopper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Shopper/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult View1()
        {
            return View();
        }
        public ActionResult Logout()
        {
            // Xóa tất cả các biến phiên (session)
            Session.Clear();

            // Chuyển hướng người dùng đến trang đăng nhập
            return RedirectToAction("Index", "Home", new { area = "Shopper" });
        }
    }
}