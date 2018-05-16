namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDIEMDEN")]
    public partial class tblDIEMDEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDIEMDEN()
        {
            tblTOURs = new HashSet<tblTOUR>();
        }

        [Key]
        public int madd { get; set; }

        [StringLength(50)]
        [Display(Name = "Điểm đến")]
        [Required(ErrorMessage = "Bạn chưa nhập điểm đến")]
        public string diemden { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại tour")]
        public string loaitour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTOUR> tblTOURs { get; set; }
    }
}
