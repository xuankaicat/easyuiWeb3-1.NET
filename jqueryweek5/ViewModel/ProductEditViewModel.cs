using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.ViewModel
{
    public class ProductEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string 产品名称 { get; set; }

        [Required]
        public string 产品类型 { get; set; }

        [Required]
        public int 库存数量 { get; set; }

        [Required]
        public string 单位名称 { get; set; }
    }
}
