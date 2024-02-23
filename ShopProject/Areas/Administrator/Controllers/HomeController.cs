using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        Models.AdminContext db = new Models.AdminContext();
        Repository.ShopDAO dao = new Repository.ShopDAO();
        [HandleError]
        public ActionResult Index()
        {
          
                    return View();
              
        }
        // Hành động để xử lý đăng xuất
        [HandleError]
        public ActionResult Logout()
        {
            // Xóa tất cả các biến phiên (session)
            Session.Clear();

            // Chuyển hướng người dùng đến trang đăng nhập
            return RedirectToAction("Login", "Customer", new { area = "Administrator" });
        }
    }

}