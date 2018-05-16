namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDATTOUR")]
    public partial class tblDATTOUR
    {
        [Key]
        public int madattour { get; set; }
        public int matour { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng người lớn")]
        public int? songuoilon { get; set; }
         [Required(ErrorMessage = "Vui lòng nhập số trẻ em")]
        public int? sotreem { get; set; }
        public int? makh { get; set; }
         [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string hoten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số cmt")]
        public string cmt { get; set; }
         [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string diachi { get; set; }
         [Required(ErrorMessage = "Vui lòng nhập điện thoại")]
        public string dienthoai { get; set; }
         [Required(ErrorMessage = "Vui lòng nhập email")]
        public string email { get; set; }
        public double tongtien { get; set; }
        public bool? dathanhtoan { get; set; }
        public DateTime ngaydattour { get; set; }
        public virtual tblKHACHHANG tblKHACHHANG { get; set; }
    }
}
