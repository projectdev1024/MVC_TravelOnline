using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Areas.Admin.Models
{
    public class KhachHangModel
    {
        [Required(ErrorMessage = "Mời nhập họ tên")]
        public string hoten { get; set; }

        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        public string diachi { get; set; }

        [Required(ErrorMessage = "Mời nhập ngày sinh")]
        public DateTime? ngaysinh { get; set; }

        [Required(ErrorMessage = "Mời nhập điện thoại")]
        public string dienthoai { get; set; }

        [Required(ErrorMessage = "Mời nhập email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mời nhập giới tính")]
        public bool? gioitinh { get; set; }

        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string taikhoan { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string matkhau { get; set; }
    }
}