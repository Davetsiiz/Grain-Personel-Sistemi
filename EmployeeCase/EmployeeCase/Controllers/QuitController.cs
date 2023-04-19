using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCase.Controllers
{
    public class QuitController : Controller
    {
        QuitManager qm = new (new EfQuitDal());
        public IActionResult Index()
        {
            var values = qm.GetListQuitWithEmployee().OrderBy(x => x.EmployeeFirstname).ToList();
            return View(values);
        }
        public IActionResult EmployeeQuitDetail(int id)
        {
            var values = qm.TGetById(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult EmployeeQuitEdit(int id)
        {
            var values = qm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EmployeeQuitEdit(EmployeeQuit employeeQuit, int id)
        {
            QuitValidator qv = new ();
            ValidationResult result = qv.Validate(employeeQuit);

            if (result.IsValid)
            {
                employeeQuit.EmployeeQuitId = id;
                qm.TUpdate(employeeQuit);
                return RedirectToAction("Index", "Quit");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        
    }
}
