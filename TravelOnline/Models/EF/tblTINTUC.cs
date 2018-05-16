namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTINTUC")]
    public partial class tblTINTUC
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int matin { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề")]
        public string tieude { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tóm tắt")]
        [Required(ErrorMessage = "Bạn chưa nhập tóm tắt")]
        public string tomtat { get; set; }

    
        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        public string noidung { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa chọn hình ảnh")]
        public string hinhanh { get; set; }
        public string metatitle { get; set; }

        public DateTime? ngaydang { get; set; }

        public int? solanxem { get; set; }
    }
}
