using System;
using System.Collections.Generic;

#nullable disable

namespace jqueryweek5.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string 产品名称 { get; set; }
        public string 产品类型 { get; set; }
        public int 库存数量 { get; set; }
        public string 单位名称 { get; set; }
    }
}
