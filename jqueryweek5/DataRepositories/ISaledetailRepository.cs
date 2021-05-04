using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public interface ISaledetailRepository
    {
        /// <summary>
        /// 根据Id获取订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zid"></param>
        /// <returns></returns>
        Saledetail GetSaledetailById(int id, string zid);
        /// <summary>
        /// 获取所有订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Saledetail> GetAllSaledetails(int id);
        /// <summary>
        /// 查询订单明细
        /// </summary>
        /// <param name="secrch_type"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public IEnumerable<Saledetail> SearchSaledetails(string search_type, string search_value);
        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <param name="Saledetail"></param>
        /// <returns></returns>
        Saledetail Insert(Saledetail Saledetail);
        /// <summary>
        /// 更新订单明细
        /// </summary>
        /// <param name="updateSaledetail"></param>
        /// <returns></returns>
        Saledetail Update(Saledetail updateSaledetail);
        /// <summary>
        /// 删除订单明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zid"></param>
        /// <returns></returns>
        Saledetail Delete(int id, string zid);
    }
}
