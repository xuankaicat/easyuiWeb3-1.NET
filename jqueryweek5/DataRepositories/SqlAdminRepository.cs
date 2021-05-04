using jqueryweek5.Infrastructure;
using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public class SqlAdminRepository : IAdminRepository
    {
        private readonly jquerytestContext _context;

        public SqlAdminRepository(jquerytestContext context)
        {
            _context = context;
        }

        public Admin Delete(int id)
        {
            Admin Admin = _context.Admins.Find(id);
            if(Admin != null)
            {
                _context.Admins.Remove(Admin);
                _context.SaveChanges();
            }
            return Admin;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins;
        }

        public IEnumerable<Admin> SearchAdmins(string search_type, string search_value)
        {
            return _context.Admins.Where($"{search_type}.Contains(@0)", search_value);
        }

        public Admin GetAdminById(int id)
        {
            return _context.Admins.Find(id);
        }

        public Admin Insert(Admin Admin)
        {
            _context.Admins.Add(Admin);
            _context.SaveChanges();
            return Admin;
        }

        public Admin Update(Admin updateAdmin)
        {
            var Admin = _context.Admins.Attach(updateAdmin);
            Admin.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateAdmin;
        }

        public async Task<Admin> FindByNameAsync(string name)
        {
            return await Task.Run(() =>
            {
                var res = _context.Admins.Where($"登录名称 == @0", name);
                if(res.Any())
                {
                    return res.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            });
        }

        public bool LoginCheck(string name, string pwd)
        {
            return _context.Admins.Where("登录名称 == @0 && 密码 == @1", name, pwd).Any();
        }
    }
}
