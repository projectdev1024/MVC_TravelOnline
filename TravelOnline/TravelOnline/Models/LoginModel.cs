using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelOnline.Models
{
    public class LoginModel
    {
        [Display(Name="Tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string UserName { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string PassWord { set; get; }
    }
}