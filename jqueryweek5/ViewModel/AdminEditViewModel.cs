using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.ViewModel
{
    public class AdminEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string 登录名称 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string 密码 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("密码")]
        public string 重复密码 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string 联系电话 { get; set; }
    }
}
