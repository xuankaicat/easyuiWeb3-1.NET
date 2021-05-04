using System;
using System.Collections.Generic;

#nullable disable

namespace jqueryweek5.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string 登录名称 { get; set; }
        public string 密码 { get; set; }
        public string 联系电话 { get; set; }
        public DateTime 添加时间 { get; set; }
    }
}
