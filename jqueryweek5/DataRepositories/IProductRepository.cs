using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// 根据Id获取产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProducts();
        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="secrch_type"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public IEnumerable<Product> SearchProducts(string search_type, string search_value);
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product Insert(Product product);
        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="updateproduct"></param>
        /// <returns></returns>
        Product Update(Product updateproduct);
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product Delete(int id);
    }
}
