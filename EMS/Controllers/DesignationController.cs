using BussinessLayer.Interface;
using EMS.Common;
using Microsoft.AspNetCore.Mvc;
using Model;

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
                var message = _designationManager.AddDesignation(model);
                if (message == AppConstant.alreadyExists)
                {
                    ViewBag.Message = message;
                    return View();
                }
                return RedirectToAction("Create", "Employee");
            }
            return View();
        }
    }
}
