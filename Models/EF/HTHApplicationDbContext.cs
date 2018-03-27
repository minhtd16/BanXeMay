namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HTHApplicationDbContext : DbContext
    {
        public HTHApplicationDbContext()
            : base("name=HTHApplicationDbContext")
        {
        }

        public virtual DbSet<ChiTietNhap> ChiTietNhaps { get; set; }
        public virtual DbSet<ChiTietXuat> ChiTietXuats { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiMatHang> LoaiMatHangs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhapHang> NhapHangs { get; set; }
        public virtual DbSet<NhapXuatTon> NhapXuatTons { get; set; }
        public virtual DbSet<NuocSanXuat> NuocSanXuats { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<XuatHang> XuatHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TongTienGiaoDich)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.DiDong)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT1)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT2)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.MaSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.TongTienGiaoDich)
                .IsFixedLength();

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<NhapXuatTon>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<NhapXuatTon>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SaltPass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<XuatHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);
        }
    }
}
