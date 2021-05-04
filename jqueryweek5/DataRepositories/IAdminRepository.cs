using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public interface IAdminRepository
    {
        /// <summary>
        /// 根据Id获取管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Admin GetAdminById(int id);
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        IEnumerable<Admin> GetAllAdmins();
        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="secrch_type"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public IEnumerable<Admin> SearchAdmins(string search_type, string search_value);
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="Admin"></param>
        /// <returns></returns>
        Admin Insert(Admin Admin);
        /// <summary>
        /// 更新管理员
        /// </summary>
        /// <param name="updateAdmin"></param>
        /// <returns></returns>
        Admin Update(Admin updateAdmin);
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Admin Delete(int id);

        Task<Admin> FindByNameAsync(string name);

        bool LoginCheck(string name, string pwd);
    }
}
