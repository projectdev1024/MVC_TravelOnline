using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Models
{
    public class CapNhatMatKhauModel
    {

        public string taikhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string matkhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("matkhau", ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string xacnhanmatkhau { set; get; }
    }
}