using BussinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using System.Linq;
using static CommonLayer.Utility;

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

        public IActionResult Index(string sortField, string currentSortField, string currentSortOrder, string currentFilter, string SearchByEmpTag, string SearchByFirstName, string SearchByEmail, int? pageNo)
        {
            if (SearchByEmpTag != null )
            {
                pageNo = 1;
            }
            else
            {
                SearchByEmpTag = currentFilter;
            }

            ViewData["CurrentSort"] = sortField;
            ViewBag.CurrentFilter = SearchByEmpTag;

            var employees = _employeeManager.GetAllEmployees( SearchByEmpTag, SearchByFirstName, SearchByEmail);
            employees = SortEmployeeData(employees, sortField, currentSortField, currentSortOrder);

            return View(PagingList<EmployeeModel>.CreateAsync(employees.AsQueryable<EmployeeModel>(), pageNo ?? 1, 10));
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

        private IEnumerable<EmployeeModel> SortEmployeeData(IEnumerable<EmployeeModel> employees, string sortField, string currentSortField, string currentSortOrder)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "EmpTagNumber";
                ViewBag.SortOrder = "Asc";
            }
            else
            {
                if (currentSortField == sortField)
                {
                    ViewBag.SortOrder = currentSortOrder == "Asc" ? "Desc" : "Asc";
                }
                else
                {
                    ViewBag.SortOrder = "Asc";
                }
                ViewBag.SortField = sortField;
            }

            var propertyInfo = typeof(EmployeeModel).GetProperty(ViewBag.SortField);
            if (ViewBag.SortOrder == "Asc")
            {
                employees = employees.OrderBy(s => propertyInfo.GetValue(s, null)).ToList();
            }
            else
            {
                employees = employees.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();
            }
            return employees;
        }
    }
}
