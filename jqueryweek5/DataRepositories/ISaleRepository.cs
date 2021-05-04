using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// 根据Id获取订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Sale GetSaleById(int id);
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        IEnumerable<Sale> GetAllSales();
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="secrch_type"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public IEnumerable<Sale> SearchSales(string search_type, string search_value);
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="Sale"></param>
        /// <returns></returns>
        Sale Insert(Sale Sale);
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="updateSale"></param>
        /// <returns></returns>
        Sale Update(Sale updateSale);
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Sale Delete(int id);
    }
}
