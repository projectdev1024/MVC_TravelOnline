namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKHACHSAN")]
    public partial class tblKHACHSAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maks { get; set; }

        [StringLength(50)]
        public string tenks { get; set; }

        [Column(TypeName = "text")]
        public string diachi { get; set; }

        [Column(TypeName = "text")]
        public string gioithieu { get; set; }

        public int? madd { get; set; }

        [StringLength(50)]
        public string hinhanh { get; set; }

        public virtual tblDIEMDEN tblDIEMDEN { get; set; }
    }
}
