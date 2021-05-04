using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.ViewModel
{
    public class SaleEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string 公司名称 { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime 销售时间 { get; set; }

        [Required]
        public string 销售人员 { get; set; }

        [Required]
        public string 送货地址 { get; set; }
    }
}
