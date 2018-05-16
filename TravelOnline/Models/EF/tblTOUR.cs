namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTOUR")]
    public partial class tblTOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTOUR()
        {
            tblKHUYENMAIs = new HashSet<tblKHUYENMAI>();
        }

        [Key]
        public int matour { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên tour")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tour")]
        public string tentour { get; set; }

        [StringLength(50)]
        public string thoigian { get; set; }

        [Display(Name = "Số chỗ")]
        [Required(ErrorMessage = "Bạn chưa nhập số chỗ")]
        public int? socho { get; set; }

        [Display(Name = "Giá tour")]
        [Required(ErrorMessage = "Bạn chưa nhập giá tour")]
        public double? giatour { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày khởi hành")]
        public DateTime khoihanh { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày kết thúc")]
        public DateTime ketthuc { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết tour")]
        [Required(ErrorMessage = "Bạn chưa nhập chi tiết tour")]
        public string chitiettour { get; set; }

        [Display(Name = "Điểm đến")]
        [Required(ErrorMessage = "Bạn chưa nhập điểm đến")]
        public int? madd { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa chọn hình ảnh")]
        public string hinhanh { get; set; }

        [StringLength(50)]
        [Display(Name = "Phương tiện")]
        [Required(ErrorMessage = "Bạn chưa nhập phương tiện")]
        public string phuongtien { get; set; }

        public string metatitle { get; set; }

        public virtual tblDIEMDEN tblDIEMDEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKHUYENMAI> tblKHUYENMAIs { get; set; }
    }
}
