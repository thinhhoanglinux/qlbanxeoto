using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class LoaiTinTuc
    {
        public int LoaiTinTucId { get; set; }

        [Required]
        [Display(Name = "Loại Tin Tức")]
        public string TenLoaiTinTuc { get; set; }
    }
}