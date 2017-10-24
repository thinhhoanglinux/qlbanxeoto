using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class TinTuc
    {
        public int TinTucId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tiêu đề không được quá 255 ký tự.")]
        [Display(Name = "Tiêu Đề")]
        public string TieuDe { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }

        [Required]
        [Display(Name = "Thời Gian Đăng")]
        public DateTime ThoiGianDang { get; set; }

        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        public LoaiTinTuc LoaiTinTuc { get; set; }
        public int LoaiTinTucId { get; set; }

        public ApplicationUser NhanVien { get; set; }
        public string NhanVienId { get; set; }

        public Boolean TrangThai { get; set; }
    }
}