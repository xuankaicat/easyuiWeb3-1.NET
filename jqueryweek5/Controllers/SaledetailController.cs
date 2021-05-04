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
    public class SaledetailController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaledetailRepository _saledetailRepository;

        public SaledetailController(ISaleRepository saleRepository, ISaledetailRepository saledetailRepository)
        {
            _saleRepository = saleRepository;
            _saledetailRepository = saledetailRepository;
        }

        public IActionResult Index(int id)
        {
            ViewData.Add("url_edit", "../Saledetail/Edit");
            ViewData.Add("url_get", "../Saledetail/GetSaledetail");
            ViewData.Add("url_del", "../Saledetail/Delete");
            return View(id);
        }

        [HttpPost]
        public object GetSaledetail(int zid, int page, int rows, string search_type = null, string search_value = null)
        {
            IEnumerable<Saledetail> saledetails;
            if(search_value != null)
            {
                saledetails = _saledetailRepository.SearchSaledetails(search_type, search_value);
            }
            else
            {
                saledetails = _saledetailRepository.GetAllSaledetails(zid);
            }
            return new
            {
                total = saledetails.Count(),
                rows = saledetails.Skip((page - 1) * rows).Take(rows)
            };
        }

        [HttpPost]
        public IActionResult Delete(int id, int zid)
        {
            _saledetailRepository.Delete(id, zid.ToString());
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int zid, int? id)
        {
            var model = new SaledetailEditViewModel();
            model.主表id = zid.ToString();
            
            if (id != null)
            {
                Saledetail p = _saledetailRepository.GetSaledetailById((int)id, zid.ToString());
                model.Id = id;
                model.产品名称 = p.产品名称;
                model.销售数量 = p.销售数量;
                model.单位名称 = p.单位名称;
            }
            else
            {
                Sale sale = _saleRepository.GetSaleById(zid);
                model.单位名称 = sale.公司名称;
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Edit(SaledetailEditViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Saledetail p;
                if(model.Id != null)
                {
                    //修改
                    p = _saledetailRepository.GetSaledetailById((int)model.Id, model.主表id);
                    p.产品名称 = model.产品名称;
                    p.销售数量 = model.销售数量;
                    p.单位名称 = model.单位名称;
                    _saledetailRepository.Update(p);
                }
                else
                {
                    //添加
                    p = new Saledetail
                    {
                        主表id = model.主表id,
                        产品名称 = model.产品名称,
                        销售数量 = model.销售数量,
                        单位名称 = model.单位名称
                    };
                    _saledetailRepository.Insert(p);
                }
                return PartialView("Editsuccessfully");
            }
            return PartialView(model);
        }
    }
}
