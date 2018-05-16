namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKHACHHANG")]
    public partial class tblKHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKHACHHANG()
        {
            tblDATTOURs = new HashSet<tblDATTOUR>();
        }

        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản")]
        public string taikhoan { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
      
        public string matkhau { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        public string hoten { get; set; }

        [StringLength(50)]
        [Display(Name = "Số CMT")]
        [Required(ErrorMessage = "Bạn chưa nhập số chứng minh thư")]
        public string cmt { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string diachi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Bạn chưa nhập ngày sinh")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập điện thoại")]
        public string dienthoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn chưa nhập email")]
        public string email { get; set; }

        public string rdcode { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Bạn chưa chọn giới tính")]

        public bool? gioitinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDATTOUR> tblDATTOURs { get; set; }
    }
}
