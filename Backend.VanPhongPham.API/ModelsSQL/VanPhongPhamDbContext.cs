using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.VanPhongPham.API.ModelsSQL;

public partial class VanPhongPhamDbContext : DbContext
{
    public VanPhongPhamDbContext()
    {
    }

    public VanPhongPhamDbContext(DbContextOptions<VanPhongPhamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbanner> Tbanners { get; set; }

    public virtual DbSet<Tblog> Tblogs { get; set; }

    public virtual DbSet<Tcategory> Tcategories { get; set; }

    public virtual DbSet<TdonHang> TdonHangs { get; set; }

    public virtual DbSet<TdonHangChiTiet> TdonHangChiTiets { get; set; }

    public virtual DbSet<ThinhThucThanhToan> ThinhThucThanhToans { get; set; }

    public virtual DbSet<Tmenu> Tmenus { get; set; }

    public virtual DbSet<TmenuGroup> TmenuGroups { get; set; }

    public virtual DbSet<TsanPham> TsanPhams { get; set; }

    public virtual DbSet<Ttopic> Ttopics { get; set; }

    public virtual DbSet<Tuser> Tusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DUNGCOOL\\SQLEXPRESS;Database=VanPhongPhamDB;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tbanner>(entity =>
        {
            entity.HasKey(e => e.Idbanner).HasName("PK__TBanner__A1B2D7B5DE42851A");

            entity.ToTable("TBanner");

            entity.Property(e => e.Idbanner)
                .ValueGeneratedNever()
                .HasColumnName("IDBanner");
            entity.Property(e => e.BannerName).HasMaxLength(200);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tblog>(entity =>
        {
            entity.HasKey(e => e.Idblog);

            entity.ToTable("TBlog");

            entity.Property(e => e.Idblog)
                .ValueGeneratedNever()
                .HasColumnName("IDBlog");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Idauthor).HasColumnName("IDAuthor");
            entity.Property(e => e.Idtopic).HasColumnName("IDTopic");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Subtitle).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Tcategory>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("PK__TCategor__1AA1EC665A0B5E68");

            entity.ToTable("TCategory");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("IDCategory");
            entity.Property(e => e.CategoryName).HasMaxLength(500);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
        });

        modelBuilder.Entity<TdonHang>(entity =>
        {
            entity.HasKey(e => e.IddonHang).HasName("PK__TDonHang__9CA232F79ACCD228");

            entity.ToTable("TDonHang");

            entity.Property(e => e.IddonHang)
                .ValueGeneratedNever()
                .HasColumnName("IDDonHang");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.IdhinhThucThanhToan).HasColumnName("IDHinhThucThanhToan");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.TongTien).HasMaxLength(200);
        });

        modelBuilder.Entity<TdonHangChiTiet>(entity =>
        {
            entity.HasKey(e => e.IddonHangChiTiet).HasName("PK__TDonHang__E6CB93D58DADC6BA");

            entity.ToTable("TDonHangChiTiet");

            entity.Property(e => e.IddonHangChiTiet)
                .ValueGeneratedNever()
                .HasColumnName("IDDonHangChiTiet");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.GiaDonHang).HasMaxLength(200);
            entity.Property(e => e.IddonHang).HasColumnName("IDDonHang");
            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
        });

        modelBuilder.Entity<ThinhThucThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdhinhThucThanhToan).HasName("PK__THinhThu__D4A641319B7220E8");

            entity.ToTable("THinhThucThanhToan");

            entity.Property(e => e.IdhinhThucThanhToan)
                .ValueGeneratedNever()
                .HasColumnName("IDHinhThucThanhToan");
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
        });

        modelBuilder.Entity<Tmenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__TMenu__C99ED2507429044D");

            entity.ToTable("TMenu");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("MenuID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.MenuGroupId).HasColumnName("MenuGroupID");
            entity.Property(e => e.MenuName).HasMaxLength(100);
        });

        modelBuilder.Entity<TmenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupId).HasName("PK__TMenuGro__1C1D79130F6DAAD1");

            entity.ToTable("TMenuGroup");

            entity.Property(e => e.MenuGroupId)
                .ValueGeneratedNever()
                .HasColumnName("MenuGroupID");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.MenuGroupName).HasMaxLength(100);
        });

        modelBuilder.Entity<TsanPham>(entity =>
        {
            entity.HasKey(e => e.IdsanPham).HasName("PK__TSanPham__9D45E58A5DB97E56");

            entity.ToTable("TSanPham");

            entity.Property(e => e.IdsanPham)
                .ValueGeneratedNever()
                .HasColumnName("IDSanPham");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.GiaDung).HasMaxLength(200);
            entity.Property(e => e.GiaGoc).HasMaxLength(200);
            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.MoTaChiTiet).HasMaxLength(500);
            entity.Property(e => e.SubTitle).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Ttopic>(entity =>
        {
            entity.HasKey(e => e.Idtopic).HasName("PK__TTopic__E0D312218977875B");

            entity.ToTable("TTopic");

            entity.Property(e => e.Idtopic)
                .ValueGeneratedNever()
                .HasColumnName("IDTopic");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.TopicName).HasMaxLength(200);
        });

        modelBuilder.Entity<Tuser>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__TUser__EAE6D9DF51D18155");

            entity.ToTable("TUser");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("IDUser");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Birth).HasColumnType("date");
            entity.Property(e => e.CreateAt).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
