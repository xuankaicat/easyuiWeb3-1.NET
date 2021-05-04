using jqueryweek5.Infrastructure;
using jqueryweek5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace jqueryweek5.DataRepositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly jquerytestContext _context;

        public SqlProductRepository(jquerytestContext context)
        {
            _context = context;
        }

        public Product Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public IEnumerable<Product> SearchProducts(string search_type, string search_value)
        {
            return _context.Products.Where($"{search_type}.Contains(@0)", search_value);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product updateproduct)
        {
            var product = _context.Products.Attach(updateproduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateproduct;
        }
    }
}
