using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlbanxeoto.Models
{
    public class LoaiXe
    {
        [Display(Name = "Mã Loại Xe")]
        public int LoaiXeId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên loại xe không được quá 255 ký tự.")]
        [Display(Name = "Loại Xe")]
        public string Ten { get; set; }
    }
}