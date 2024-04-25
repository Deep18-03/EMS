using BussinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Controllers
{
    public class DesignationController : Controller
    {
        private IDesignationManager _designationManager;
        public DesignationController(IDesignationManager designationManager)
        {
            _designationManager = designationManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DesignationModel model)
        {
            if (ModelState.IsValid)
            {
                var isSucess = _designationManager.AddDesignation(model);
                return RedirectToAction("Create", "Employee");
            }
            return View();
        }
    }
}
