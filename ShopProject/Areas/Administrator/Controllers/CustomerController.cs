using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopProject.Areas.Administrator.Models;

namespace ShopProject.Areas.Administrator.Controllers
{
    public class CustomerController : Controller
    {
        Models.AdminContext dbCus = new Models.AdminContext();
        Repository.ShopDAO dao = new Repository.ShopDAO();

        // GET: /Administrator/Customer/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = dbCus.Customers.FirstOrDefault(c => c.cusFullName == model.cusFullName && c.password == model.password);

                if (customer != null) // Check if customer is found
                {
                    // Lưu thông tin vào session
                    Session["cusFullName"] = customer.cusFullName;
                    Session["role"] = customer.role;
                    Session["cusPhone"] = customer.cusPhone;
                    if (customer.role == 1)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Shopper" });
                    }
                    else if (customer.role == 0)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Administrator" });


                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }

            return View(model);
        }

        [HandleError]
        public ActionResult Index(string name, string error)
        {
            if (Session["role"] == null || (int)Session["role"] != 0)
            {
                // Redirect to a different page or display an error message
                return RedirectToAction("AccessDenied", "Error");
            }
            else
            {
                ViewBag.CusError = error;
                var model = dbCus.Customers.ToList();
                if (!string.IsNullOrEmpty(name))
                {
                    model = model.Where(p => p.cusPhone.Contains(name)).ToList();
                }
                return View(model);
            }
        }
    }
}
