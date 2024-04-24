using BussinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeManager _employeeManager;
        private IDepartmentManager _departmentManager;
        private IDesignationManager _designationManager;
        public EmployeeController(IEmployeeManager employeeManager, IDepartmentManager departmentManager, IDesignationManager designationManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
            _designationManager = designationManager;
        }

        public IActionResult Index()
        {
            var employees = _employeeManager.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
            ViewBag.Designations = _designationManager.GetDesignationDropdownList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var isSucess = _employeeManager.AddEmployee(model);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
            ViewBag.Designations = _designationManager.GetDesignationDropdownList();
            return View();
        }
        public IActionResult Edit(int id)
        {
            EmployeeModel data = _employeeManager.GetEmployeeById(id);
            ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
            ViewBag.Designations = _designationManager.GetDesignationDropdownList();
            return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = _employeeManager.UpdateEmployee(model);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
            ViewBag.Designations = _designationManager.GetDesignationDropdownList();
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            var isSuccess = _employeeManager.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
    }
}
