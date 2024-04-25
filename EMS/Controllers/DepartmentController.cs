using BussinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var isSucess = _departmentManager.AddDepartment(model);
                return RedirectToAction("Create", "Employee");
            }
            return View();
        }
    }
}
