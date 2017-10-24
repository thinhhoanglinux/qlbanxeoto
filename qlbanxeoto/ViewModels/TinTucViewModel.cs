using qlbanxeoto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.ViewModels
{
    public class TinTucViewModel
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

        public TinTucViewModel()
        {
            Hinh = "~/Content/images/addnews.png";
        }

        public IEnumerable<LoaiTinTuc> LoaiTinTucs { get; set; }
        [Required]
        [Display(Name = "Loại Tin Tức")]
        public int LoaiTinTuc { get; set; }

        public string Heading { get; set; }
        public string Action
        {
            get { return (TinTucId != 0) ? "Update" : "Create"; }
        }
    }
}