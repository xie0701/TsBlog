using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TsBlog.ViewModel.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入用户")]
        [Display(Name="用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage="请输入密码")]
        [Display(Name="密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="请输入验证码")]
        [Display(Name="验证码")]
        public string ValidCode { get; set; }
    }
}
