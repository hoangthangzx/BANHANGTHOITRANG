
using ShopProject.Areas.Shopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class ThanhToanController : Controller
    {
        UserContext db = new UserContext();
        // GET: Shopper/ThanhToan
        public ActionResult Index()
        {
            // Khởi tạo đối tượng DbContext
            ShopProject.Areas.Shopper.Models.UserContext db = new ShopProject.Areas.Shopper.Models.UserContext();

            // Lấy giỏ hàng từ cơ sở dữ liệu
            List<ShopProject.Areas.Shopper.Models.ShoppingCartItems> gio = new List<ShopProject.Areas.Shopper.Models.ShoppingCartItems>();

            // Kiểm tra xem có cusPhone trong session không
            if (Session["cusPhone"] != null)
            {
                string cusPhone = Session["cusPhone"].ToString();
                // Lấy danh sách ShoppingCartItems dựa vào cusPhone
                gio = db.ShoppingCartItems.Where(item => item.cusPhone == cusPhone).ToList();
            }

            return View(gio);
        }
        [HttpPost]
        public ActionResult StepEnd()
        {
            // Nhận thông tin từ form
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];

            // Tạo đơn hàng mới
            Orders newOrder = new Orders();
            string newIDOrder = (Int32.Parse(db.Orders.OrderByDescending(p => p.orderDateTime).FirstOrDefault().orderID.Replace("HD", "")) + 1).ToString();
            newOrder.orderID = "HD" + newIDOrder;
            newOrder.cusPhonegiao = phone;
            newOrder.cusPhone = Session["cusPhone"].ToString();
            newOrder.cusFullNamegiao = fullname;
            newOrder.cusEmailgiao = email;
            newOrder.cusAddressgiao = address;
            newOrder.orderMessage = note;
            newOrder.orderDateTime = DateTime.Now.ToString();
            newOrder.orderStatus = "0";

            // Thêm đơn hàng vào cơ sở dữ liệu
            db.Orders.Add(newOrder);
            db.SaveChanges();

            // Lưu trữ thông tin giỏ hàng từ session
            List<ShoppingCartItems> gioHang = GetCartItemsFromDatabase();

            // Thêm chi tiết đơn hàng vào cơ sở dữ liệu
            foreach (var item in gioHang)
            {
                OrderDetails newOrdts = new OrderDetails();
                newOrdts.orderID = newOrder.orderID;
                newOrdts.proID = item.proID;
                newOrdts.ordtsQuantity = item.quantity;
                newOrdts.ordtsThanhTien = (item.quantity * decimal.Parse(item.price)).ToString();
                db.OrderDetails.Add(newOrdts);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            // Xóa các mục giỏ hàng khỏi cơ sở dữ liệu
            db.ShoppingCartItems.RemoveRange(gioHang);
            db.SaveChanges();

            // Lưu thông tin đơn hàng vào session
            Session["MHD"] = "HD" + newIDOrder;
            Session["Phonegiao"] = phone;

            // Chuyển hướng đến trang xác nhận
            return RedirectToAction("HoaDon", "ThanhToan");
        }

        // Phương thức lấy thông tin giỏ hàng từ cơ sở dữ liệu
        private List<ShoppingCartItems> GetCartItemsFromDatabase()
        {
            // Lấy danh sách các mục giỏ hàng từ cơ sở dữ liệu
            return db.ShoppingCartItems.ToList();
        }

        public ActionResult HoaDon()
        {
            return View();
        }
    }
}
