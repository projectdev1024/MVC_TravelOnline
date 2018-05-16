using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Models
{
    public class DangKyModel
    {
        [Key]
        public int makh { set; get; }

        [Display(Name="Tài khoản") ]
        [Required(ErrorMessage="Vui lòng nhập tài khoản")]
        public string taikhoan { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20,MinimumLength=6,ErrorMessage="Độ dài mật khẩu ít nhất 6 ký tự ")]

        public string matkhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("matkhau",ErrorMessage="Xác nhận mật khẩu không đúng")]
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu")]
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