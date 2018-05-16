using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Models
{
    public class TourViewModel
    {
        public int matour { set; get; }

        [Display(Name = "Tên tour")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tour")]
        public string tentour { get; set; }

        public string thoigian { get; set; }

        [Display(Name = "Số chỗ")]
        [Required(ErrorMessage = "Bạn chưa nhập số chỗ")]
        public int? socho { get; set; }

        [Display(Name = "Giá tour")]
        [Required(ErrorMessage = "Bạn chưa nhập giá tour")]
        public double? giatour { get; set; }
        public double? giakhuyenmai { get; set; }
        public double? giam { get; set; }

        [Display(Name = "Khởi hành")]
        [Required(ErrorMessage = "Bạn chưa nhập khởi hành")]
        public DateTime khoihanh { get; set; }

        [Display(Name = "Kết thúc")]
        [Required(ErrorMessage = "Bạn chưa nhập kết thúc")]
        public DateTime ketthuc { get; set; }

        [Display(Name = "Chi tiết tour")]
        [Required(ErrorMessage = "Bạn chưa nhập chi tiết tour")]
        public string chitiettour { get; set; }
        public int? madd { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa chọn ảnh đại diện")]
        public string hinhanh { get; set; }

        [Display(Name = "Phương tiện")]
        [Required(ErrorMessage = "Bạn chưa nhập phương tiện")]
        public string phuongtien { get; set; }
        public string metatitle { get; set; }
        public DateTime? batdaukm { get; set; }
        public DateTime? ketthuckm { get; set; }
    }
}