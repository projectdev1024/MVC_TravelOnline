namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelOnlineDbContext : DbContext
    {
        public TravelOnlineDbContext()
            : base("name=TravelOnlineDbContext")
        {
        }

        public virtual DbSet<tblADMIN> tblADMINs { get; set; }
        public virtual DbSet<tblDATTOUR> tblDATTOURs { get; set; }
        public virtual DbSet<tblDIEMDEN> tblDIEMDENs { get; set; }
        public virtual DbSet<tblKHACHHANG> tblKHACHHANGs { get; set; }
        public virtual DbSet<tblKHUYENMAI> tblKHUYENMAIs { get; set; }
        public virtual DbSet<tblLIENHE> tblLIENHEs { get; set; }
        public virtual DbSet<tblQUANGCAO> tblQUANGCAOs { get; set; }
        public virtual DbSet<tblTINTUC> tblTINTUCs { get; set; }
        public virtual DbSet<tblTOUR> tblTOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblADMIN>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<tblADMIN>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<tblDATTOUR>()
                .Property(e => e.cmt)
                .IsFixedLength();

            modelBuilder.Entity<tblKHACHHANG>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<tblKHACHHANG>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<tblKHACHHANG>()
                .Property(e => e.cmt)
                .IsUnicode(false);

            modelBuilder.Entity<tblKHACHHANG>()
                .Property(e => e.rdcode)
                .IsUnicode(false);

            modelBuilder.Entity<tblLIENHE>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<tblTOUR>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);
        }
    }
}
