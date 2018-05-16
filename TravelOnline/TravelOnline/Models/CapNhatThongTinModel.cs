using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Models
{
    public class CapNhatThongTinModel
    {
        public int makh { set; get; }

        [Display(Name = "Mật khẩu cũ")]

        public string matkhaucu { set; get; }

        public string taikhoan { get; set; }

        [Display(Name = "Mật khẩu")]

        public string matkhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("matkhau",ErrorMessage="Xác nhận mật khẩu không đúng")]
        public string xacnhanmatkhau { set; get; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string hoten { set; get; }

        [Display(Name = "Số CMT")]
        [Required(ErrorMessage = "Vui lòng nhập số CMT")]
        public string cmt { set; get; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string diachi { set; get; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public DateTime ngaysinh { set; get; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập điện thoại")]
        public string dienthoai { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string email { set; get; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        public bool gioitinh { set; get; }
    }
}
