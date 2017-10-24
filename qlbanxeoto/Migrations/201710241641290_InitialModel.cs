namespace qlbanxeoto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangKyLaiThus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false),
                        Sdt = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        LoiNhan = c.String(nullable: false),
                        NgayDangKy = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                        XeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Xes", t => t.XeId, cascadeDelete: true)
                .Index(t => t.XeId);
            
            CreateTable(
                "dbo.Xes",
                c => new
                    {
                        XeId = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 255),
                        MoTa = c.String(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hinh = c.String(nullable: false),
                        DanhGia = c.String(nullable: false),
                        ThoiGian = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        LoaiXeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.XeId)
                .ForeignKey("dbo.LoaiXes", t => t.LoaiXeId, cascadeDelete: true)
                .Index(t => t.LoaiXeId);
            
            CreateTable(
                "dbo.LoaiXes",
                c => new
                    {
                        LoaiXeId = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.LoaiXeId);
            
            CreateTable(
                "dbo.LoaiTinTucs",
                c => new
                    {
                        LoaiTinTucId = c.Int(nullable: false, identity: true),
                        TenLoaiTinTuc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoaiTinTucId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        TinTucId = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 255),
                        NoiDung = c.String(nullable: false),
                        ThoiGianDang = c.DateTime(nullable: false),
                        Hinh = c.String(),
                        LoaiTinTucId = c.Int(nullable: false),
                        NhanVienId = c.String(maxLength: 128),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TinTucId)
                .ForeignKey("dbo.LoaiTinTucs", t => t.LoaiTinTucId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.NhanVienId)
                .Index(t => t.LoaiTinTucId)
                .Index(t => t.NhanVienId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(nullable: false, maxLength: 255),
                        NgaySinh = c.DateTime(nullable: false),
                        Sdt = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        NgayVaoLam = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TinTucs", "NhanVienId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TinTucs", "LoaiTinTucId", "dbo.LoaiTinTucs");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DangKyLaiThus", "XeId", "dbo.Xes");
            DropForeignKey("dbo.Xes", "LoaiXeId", "dbo.LoaiXes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TinTucs", new[] { "NhanVienId" });
            DropIndex("dbo.TinTucs", new[] { "LoaiTinTucId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Xes", new[] { "LoaiXeId" });
            DropIndex("dbo.DangKyLaiThus", new[] { "XeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TinTucs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LoaiTinTucs");
            DropTable("dbo.LoaiXes");
            DropTable("dbo.Xes");
            DropTable("dbo.DangKyLaiThus");
        }
    }
}
