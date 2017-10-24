using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class Xe
    {
        [Display(Name = "Mã Xe")]
        public int XeId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên xe không được quá 255 ký tự.")]
        [Display(Name = "Tên Xe")]
        public string Ten { get; set; }

        [Required]
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public decimal Gia { get; set; }

        [Required]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [Required]
        [Display(Name = "Đánh Giá")]
        public string DanhGia { get; set; }

        [Required]
        [Display(Name = "Ngày Đăng")]
        public DateTime ThoiGian { get; set; }

        public Boolean TrangThai { get; set; }

        public LoaiXe LoaiXe { get; set; }
        public int LoaiXeId { get; set; }
    }
}