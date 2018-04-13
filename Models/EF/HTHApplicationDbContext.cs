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

        public virtual DbSet<CauHinhID> CauHinhIDs { get; set; }
        public virtual DbSet<ChiTietNhap> ChiTietNhaps { get; set; }
        public virtual DbSet<ChiTietXuat> ChiTietXuats { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<GioiTinh> GioiTinhs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhachHangGiaoDich> KhachHangGiaoDiches { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<LoaiGiaoDich> LoaiGiaoDiches { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiMatHang> LoaiMatHangs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaCungCapGiaoDich> NhaCungCapGiaoDiches { get; set; }
        public virtual DbSet<NhapHang> NhapHangs { get; set; }
        public virtual DbSet<NhapXuatTon> NhapXuatTons { get; set; }
        public virtual DbSet<NuocSanXuat> NuocSanXuats { get; set; }
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public virtual DbSet<PrinterConfig> PrinterConfigs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<XuatHang> XuatHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHinhID>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.NhapID)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietNhap>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.XuatID)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXuat>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.HangHoas)
                .WithOptional(e => e.DonViTinh)
                .HasForeignKey(e => e.DVT);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.HangHoas1)
                .WithOptional(e => e.DonViTinh1)
                .HasForeignKey(e => e.DVT);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.LoaiMH)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.GiaNhapVe)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.GiaBanLe)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.GiaBanSi)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietNhaps)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietXuats)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.XuatHangs)
                .WithOptional(e => e.KhachHang1)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<KhachHangGiaoDich>()
                .Property(e => e.DonHangID)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHangGiaoDich>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Kho>()
                .HasMany(e => e.KhoHangs)
                .WithOptional(e => e.Kho)
                .HasForeignKey(e => e.MaKho);

            modelBuilder.Entity<KhoHang>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiMatHang>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiMatHang>()
                .HasMany(e => e.HangHoas)
                .WithOptional(e => e.LoaiMatHang)
                .HasForeignKey(e => e.LoaiMH);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.HangHoas)
                .WithOptional(e => e.MauSac)
                .HasForeignKey(e => e.MauID);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.DiDong)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.DienThoai)
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
                .HasMany(e => e.NhapHangs)
                .WithOptional(e => e.NhaCungCap)
                .HasForeignKey(e => e.DoiTac);

            modelBuilder.Entity<NhaCungCapGiaoDich>()
                .Property(e => e.GiaoDichID)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapGiaoDich>()
                .Property(e => e.NhaCungCapID)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapGiaoDich>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.IDNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<NhapHang>()
                .HasMany(e => e.ChiTietNhaps)
                .WithRequired(e => e.NhapHang)
                .HasForeignKey(e => e.NhapID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhapXuatTon>()
                .Property(e => e.MaHH)
                .IsUnicode(false);

            modelBuilder.Entity<NhapXuatTon>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<NuocSanXuat>()
                .HasMany(e => e.HangHoas)
                .WithOptional(e => e.NuocSanXuat)
                .HasForeignKey(e => e.NuocSXID);

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.Table)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.Column)
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
                .Property(e => e.IDXuat)
                .IsUnicode(false);

            modelBuilder.Entity<XuatHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<XuatHang>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<XuatHang>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<XuatHang>()
                .HasMany(e => e.ChiTietXuats)
                .WithRequired(e => e.XuatHang)
                .HasForeignKey(e => e.XuatID)
                .WillCascadeOnDelete(false);
        }
    }
}
