using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TsBlog.ViewModel.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="请输入用户名")]
        [Display(Name="用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage="请输入密码")]
        [Display(Name="密码")]
        [DataType(DataType.Password), MaxLength(20, ErrorMessage = "密码最大长度为20个字符"), MinLength(6, ErrorMessage = "密码最小长度为6个字符")]
        public string Password { get; set; }

        [Required(ErrorMessage="请输入确认密码")]
        [Display(Name="确认密码")]
        [DataType(DataType.Password), Compare("Password", ErrorMessage="两次密码不一致")]
        public string ConfirmPassword { get; set; }
    }
}
