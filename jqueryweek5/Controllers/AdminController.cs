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
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IActionResult Index()
        {
            ViewData.Add("url_edit", "../Admin/Edit");
            ViewData.Add("url_get", "../Admin/GetAdmin");
            ViewData.Add("url_del", "../Admin/Delete");
            return View();
        }

        [HttpPost]
        public object GetAdmin(int page, int rows, string search_type = null, string search_value = null)
        {
            IEnumerable<Admin> admins;
            if(search_value != null)
            {
                admins = _adminRepository.SearchAdmins(search_type, search_value);
            }
            else
            {
                admins = _adminRepository.GetAllAdmins();
            }
            return new
            {
                total = admins.Count(),
                rows = admins.Skip((page - 1) * rows).Take(rows)
            };
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _adminRepository.Delete(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = new AdminEditViewModel();
            if (id != null)
            {
                Admin p = _adminRepository.GetAdminById((int)id);
                model.Id = id;
                model.登录名称 = p.登录名称;
                //model.密码 = p.密码;
                model.联系电话 = p.联系电话;
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Edit(AdminEditViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Admin p;
                if(model.Id != null)
                {
                    //修改
                    p = _adminRepository.GetAdminById((int)model.Id);
                    p.登录名称 = model.登录名称;
                    p.密码 = model.密码;
                    p.联系电话 = model.联系电话;
                    _adminRepository.Update(p);
                }
                else
                {
                    //添加
                    p = new Admin
                    {
                        登录名称 = model.登录名称,
                        密码 = model.密码,
                        联系电话 = model.联系电话,
                        添加时间 = DateTime.Now
                    };
                    _adminRepository.Insert(p);
                }
                return PartialView("Editsuccessfully");
            }
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> IsNameInUse(string name, int? id)
        {
            var res = await _adminRepository.FindByNameAsync(name);

            if (res == null)
            {
                return Json(true);
            }
            if(id != null && res.Id == id)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
