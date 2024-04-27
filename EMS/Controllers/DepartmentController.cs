using BussinessLayer.Interface;
using EMS.Common;
using Microsoft.AspNetCore.Mvc;
using Model;

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
            try
            {
                if (ModelState.IsValid)
                {
                    string message = _departmentManager.AddDepartment(model);
                    if (message == AppConstant.alreadyExists)
                    {
                        ViewBag.Message = message;
                        return View();
                    }
                    return RedirectToAction("Create", "Employee");
                }
                return View();
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
           
        }
    }
}
