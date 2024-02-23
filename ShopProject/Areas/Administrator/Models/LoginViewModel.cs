using System.ComponentModel.DataAnnotations;

namespace ShopProject.Areas.Administrator.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public string cusFullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string password { get; set; }
    }
}
