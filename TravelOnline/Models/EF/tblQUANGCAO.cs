namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblQUANGCAO")]
    public partial class tblQUANGCAO
    {
        [Key]
        public int maqc { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề")]
        public string tenqc { get; set; }

        [StringLength(50)]
        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "Bạn chưa nhập đường dẫn")]
        public string url { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa nhập hình ảnh")]
        public string urlanh { get; set; }
    }
}
