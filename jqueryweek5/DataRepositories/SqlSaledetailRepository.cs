using jqueryweek5.Infrastructure;
using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public class SqlSaledetailRepository : ISaledetailRepository
    {
        private readonly jquerytestContext _context;

        public SqlSaledetailRepository(jquerytestContext context)
        {
            _context = context;
        }

        public Saledetail Delete(int id, string zid)
        {
            Saledetail Saledetail = _context.Saledetails.Find(id, zid);
            if(Saledetail != null)
            {
                _context.Saledetails.Remove(Saledetail);
                _context.SaveChanges();
            }
            return Saledetail;
        }

        public IEnumerable<Saledetail> GetAllSaledetails(int id)
        {
            return _context.Saledetails.Where("主表Id == @0", id.ToString());
        }

        public IEnumerable<Saledetail> SearchSaledetails(string search_type, string search_value)
        {
            return _context.Saledetails.Where($"{search_type}.Contains(@0)", search_value);
        }

        public Saledetail GetSaledetailById(int id, string zid)
        {
            return _context.Saledetails.Find(id, zid);
        }

        public Saledetail Insert(Saledetail Saledetail)
        {
            _context.Saledetails.Add(Saledetail);
            _context.SaveChanges();
            return Saledetail;
        }

        public Saledetail Update(Saledetail updateSaledetail)
        {
            var Saledetail = _context.Saledetails.Attach(updateSaledetail);
            Saledetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateSaledetail;
        }
    }
}
