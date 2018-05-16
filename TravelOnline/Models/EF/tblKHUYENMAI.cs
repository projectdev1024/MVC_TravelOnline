namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKHUYENMAI")]
    public partial class tblKHUYENMAI
    {
        [Key]
        public int matourkm { get; set; }

        [Display(Name = "Giảm")]
        [Required(ErrorMessage = "Bạn chưa nhập giảm")]
        public double? giam { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày bắt đầu")]
        public DateTime? batdau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày kết thúc")]
        public DateTime? kethuc { get; set; }

        [Display(Name = "Tên tour")]
        [Required(ErrorMessage = "Bạn chưa chọn tour khuyến mại")]
        public int? matour { get; set; }

        public virtual tblTOUR tblTOUR { get; set; }
    }
}
