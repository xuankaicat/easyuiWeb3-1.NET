using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="用户名不能为空")]
        [Display(Name = "用户名")]
        //[Remote(action: "CheckLogin", controller: "Account", AdditionalFields = nameof(Password))]
        public string Name { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        [Remote(action: "CheckLogin", controller: "Account", AdditionalFields = nameof(Name))]
        public string Password { get; set; }
    }
}
