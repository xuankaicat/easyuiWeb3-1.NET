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
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IActionResult Index()
        {
            ViewData.Add("url_edit", "../Sale/Edit");
            ViewData.Add("url_get", "../Sale/GetSale");
            ViewData.Add("url_del", "../Sale/Delete");
            ViewData.Add("url_detail", "../Saledetail/Index");
            return View();
        }

        [HttpPost]
        public object GetSale(int page, int rows, string search_type = null, string search_value = null)
        {
            IEnumerable<Sale> sales;
            if(search_value != null)
            {
                sales = _saleRepository.SearchSales(search_type, search_value);
            }
            else
            {
                sales = _saleRepository.GetAllSales();
            }
            return new
            {
                total = sales.Count(),
                rows = sales.Skip((page - 1) * rows).Take(rows)
            };
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _saleRepository.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = new SaleEditViewModel();
            if (id != null)
            {
                Sale p = _saleRepository.GetSaleById((int)id);
                model.Id = id;
                model.公司名称 = p.公司名称;
                model.销售人员 = p.销售人员;
                model.送货地址 = p.送货地址;
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Edit(SaleEditViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Sale p;
                if(model.Id != null)
                {
                    //修改
                    p = _saleRepository.GetSaleById((int)model.Id);
                    p.公司名称 = model.公司名称;
                    p.销售人员 = model.销售人员;
                    p.送货地址 = model.送货地址;
                    _saleRepository.Update(p);
                }
                else
                {
                    //添加
                    p = new Sale
                    {
                        公司名称 = model.公司名称,
                        销售人员 = model.销售人员,
                        送货地址 = model.送货地址,
                        销售时间 = DateTime.Now
                    };
                    _saleRepository.Insert(p);
                }
                return PartialView("Editsuccessfully");
            }
            return PartialView(model);
        }
    }
}
