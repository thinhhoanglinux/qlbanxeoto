using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class DangKyLaiThu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "SDT")]
        [DataType(DataType.PhoneNumber)]
        public string Sdt { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Lời nhắn")]
        [DataType(DataType.MultilineText)]
        public string LoiNhan { get; set; }

        [Display(Name = "Ngày đăng ký")]
        public string NgayDangKy { get; set; }

        [Display(Name = "Trạng thái")]
        public Boolean TrangThai { get; set; }

        public Xe Xe { get; set; }
        public int XeId { get; set; }
    }
}