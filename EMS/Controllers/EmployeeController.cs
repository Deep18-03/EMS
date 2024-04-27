using BussinessLayer.Interface;
using EMS.Common;
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
            try
            {
                if (SearchByEmpTag != null)
                {
                    pageNo = 1;
                }
                else
                {
                    SearchByEmpTag = currentFilter;
                }

                var message = TempData["DeleteMessage"] as string;
                ViewBag.DeleteMessage = message;

                ViewData["CurrentSort"] = sortField;
                ViewBag.CurrentFilter = SearchByEmpTag;

                var employees = _employeeManager.GetAllEmployees(SearchByEmpTag, SearchByFirstName, SearchByEmail);
                employees = SortEmployeeData(employees, sortField, currentSortField, currentSortOrder);

                return View(PagingList<EmployeeModel>.CreateAsync(employees.AsQueryable<EmployeeModel>(), pageNo ?? 1, 10));
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    var message = _employeeManager.AddEmployee(model);
                    if (message == AppConstant.alreadyExists)
                    {
                        ViewBag.Message = message;
                        return View();
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
                ViewBag.Designations = _designationManager.GetDesignationDropdownList();
                return View();
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
           
        }
        public IActionResult Edit(int id)
        {
            try
            {
                EmployeeModel data = _employeeManager.GetEmployeeById(id);
                ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
                ViewBag.Designations = _designationManager.GetDesignationDropdownList();
                return View("Create", data);
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
          
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var message = _employeeManager.UpdateEmployee(model);

                    if (message == AppConstant.alreadyExists)
                    {
                        ViewBag.Message = message;
                        return View();
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Departments = _departmentManager.GetDepartmentDropdownList();
                ViewBag.Designations = _designationManager.GetDesignationDropdownList();
                return View("Create", model);
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
           
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var message = _employeeManager.DeleteEmployee(id);
                TempData["DeleteMessage"] = message;
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View("Error");
                throw;
            }
           
        }

        private IEnumerable<EmployeeModel> SortEmployeeData(IEnumerable<EmployeeModel> employees, string sortField, string currentSortField, string currentSortOrder)
        {
            try
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
            catch (System.Exception)
            {
                throw;
            }
           
        }
    }
}
