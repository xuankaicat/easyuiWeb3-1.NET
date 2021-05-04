using jqueryweek5.Infrastructure;
using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public class SqlSaleRepository : ISaleRepository
    {
        private readonly jquerytestContext _context;

        public SqlSaleRepository(jquerytestContext context)
        {
            _context = context;
        }

        public Sale Delete(int id)
        {
            Sale Sale = _context.Sales.Find(id);
            if(Sale != null)
            {
                _context.Sales.Remove(Sale);
                _context.SaveChanges();
            }
            return Sale;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _context.Sales;
        }

        public IEnumerable<Sale> SearchSales(string search_type, string search_value)
        {
            return _context.Sales.Where($"{search_type}.Contains(@0)", search_value);
        }

        public Sale GetSaleById(int id)
        {
            return _context.Sales.Find(id);
        }

        public Sale Insert(Sale Sale)
        {
            _context.Sales.Add(Sale);
            _context.SaveChanges();
            return Sale;
        }

        public Sale Update(Sale updateSale)
        {
            var Sale = _context.Sales.Attach(updateSale);
            Sale.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateSale;
        }
    }
}
