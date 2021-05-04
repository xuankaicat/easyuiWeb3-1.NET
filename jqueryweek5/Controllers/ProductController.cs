using jqueryweek5.DataRepositories;
using jqueryweek5.Models;
using jqueryweek5.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace jqueryweek5.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            //var model = new ProductEditViewModel();
            ViewData.Add("url_edit", "../Product/Edit");
            ViewData.Add("url_get", "../Product/GetProduct");
            ViewData.Add("url_del", "../Product/Delete");
            return View();
        }

        [HttpPost]
        public object GetProduct(int page, int rows, string search_type = null, string search_value = null)
        {
            IEnumerable<Product> products;
            if(search_value != null)
            {
                products = _productRepository.SearchProducts(search_type, search_value);
            }
            else
            {
                products = _productRepository.GetAllProducts();
            }
            return new
            {
                total = products.Count(),
                rows = products.Skip((page - 1) * rows).Take(rows)
            };
        }

        [HttpPost]
        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = new ProductEditViewModel();
            if(id != null)
            {
                Product p = _productRepository.GetProductById((int)id);
                model.Id = id;
                model.产品名称 = p.产品名称;
                model.产品类型 = p.产品类型;
                model.单位名称 = p.单位名称;
                model.库存数量 = p.库存数量;
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Product p;
                if(model.Id != null)
                {
                    //修改
                    p = _productRepository.GetProductById((int)model.Id);
                    p.产品名称 = model.产品名称;
                    p.产品类型 = model.产品类型;
                    p.单位名称 = model.单位名称;
                    p.库存数量 = model.库存数量;
                    _productRepository.Update(p);
                }
                else
                {
                    //添加
                    p = new Product
                    {
                        产品名称 = model.产品名称,
                        产品类型 = model.产品类型,
                        单位名称 = model.单位名称,
                        库存数量 = model.库存数量
                    };
                    _productRepository.Insert(p);
                }
                return PartialView("Editsuccessfully");
            }
            return PartialView(model);
            //return Edit(model.Id);
        }
    }
}
