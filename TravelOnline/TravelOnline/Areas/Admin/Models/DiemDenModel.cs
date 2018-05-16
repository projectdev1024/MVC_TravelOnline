using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Areas.Admin.Models
{
    public class DiemDenModel
    {
        public int madd { set; get; }
        [Required(ErrorMessage = "Mời nhập điểm đến")]
        public string diemden { set; get; }
    }
}