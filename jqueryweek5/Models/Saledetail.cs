using System;
using System.Collections.Generic;

#nullable disable

namespace jqueryweek5.Models
{
    public partial class Saledetail
    {
        public int Id { get; set; }
        public string 产品名称 { get; set; }
        public string 主表id { get; set; }
        public int 销售数量 { get; set; }
        public string 单位名称 { get; set; }
    }
}
