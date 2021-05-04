using System;
using System.Collections.Generic;

#nullable disable

namespace jqueryweek5.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public string 公司名称 { get; set; }
        public DateTime 销售时间 { get; set; }
        public string 销售人员 { get; set; }
        public string 送货地址 { get; set; }
    }
}
