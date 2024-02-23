using ShopProject.Areas.Shopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShopProject.Areas.Shopper.Controllers
{
    public class GioHangController : Controller
    {
        private UserContext db = new UserContext();

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


        public ActionResult ThemVaoGio(string SanPhamID)
        {
            // Kiểm tra xem đã có người dùng đăng nhập chưa
            if (Session["cusPhone"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập hoặc đăng ký
                return RedirectToAction("Login", "Account"); // Thay "Login" và "Account" bằng tên controller và action tương ứng
            }

            // Lấy mã khách hàng từ Session
            string cusPhone = Session["cusPhone"].ToString();

            // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng của khách hàng chưa
            var cartItem = db.ShoppingCartItems.FirstOrDefault(m => m.proID == SanPhamID && m.cusPhone == cusPhone);
            if (cartItem == null)
            {
                // Nếu chưa tồn tại, thêm mới vào giỏ hàng
                var product = db.Products.Find(SanPhamID);
                if (product != null)
                {
                    var newItem = new ShoppingCartItems
                    {
                        proID = SanPhamID,
                        cusPhone = cusPhone,
                        quantity = 1,
                        price = (Int32.Parse(product.proPrice) - (Int32.Parse(product.proPrice) * product.proDiscount) / 100).ToString(),
                        discount = product.proDiscount // Thêm thông tin giảm giá vào giỏ hàng
                    };
                    db.ShoppingCartItems.Add(newItem);
                }
            }
            else
            {
                // Nếu đã tồn tại, tăng số lượng lên 1
                cartItem.quantity++;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "GioHang");

        }


        public ActionResult SuaSoLuong(string SanPhamID, int soluongmoi)
        {
            // Tìm sản phẩm trong giỏ hàng
            var cartItem = db.ShoppingCartItems.FirstOrDefault(m => m.proID.Equals(SanPhamID));
            if (cartItem != null)
            {
                // Kiểm tra số lượng mới hợp lệ
                if (soluongmoi >= 1 && soluongmoi <= 100)
                {
                    cartItem.quantity = soluongmoi;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult XoaKhoiGio(string SanPhamID)
        {
            // Tìm và xóa sản phẩm khỏi giỏ hàng
            var cartItem = db.ShoppingCartItems.FirstOrDefault(m => m.proID.Equals(SanPhamID));
            if (cartItem != null)
            {
                db.ShoppingCartItems.Remove(cartItem);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
