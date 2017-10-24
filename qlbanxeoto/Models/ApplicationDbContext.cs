using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Xe> Xes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<LoaiTinTuc> LoaiTinTucs { get; set; }
        public DbSet<DangKyLaiThu> DangKyLaiThus { get; set; }
        public ApplicationDbContext()
            : base("qlbanxeoto", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}