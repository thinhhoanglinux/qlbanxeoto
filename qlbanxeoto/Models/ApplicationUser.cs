using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace qlbanxeoto.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Họ và Tên")]
        [StringLength(255, ErrorMessage = "Tên không được quá 255 ký tự.")]
        public string HoTen { get; set; }

        [Required]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }

        [Required]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Ngày Vào Làm")]
        public DateTime NgayVaoLam { get; set; }

        [Display(Name = "Trạng Thái")]
        public Boolean TrangThai { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}