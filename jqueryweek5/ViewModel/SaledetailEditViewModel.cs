using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.ViewModel
{
    public class SaledetailEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string 产品名称 { get; set; }

        public string 主表id { get; set; }

        [Required]
        public int 销售数量 { get; set; }

        [Required]
        public string 单位名称 { get; set; }
    }
}
