namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLIENHE")]
    public partial class tblLIENHE
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        public string noidung { get; set; }

        public bool? status { get; set; }
    }
}
