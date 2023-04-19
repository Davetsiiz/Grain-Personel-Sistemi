using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EmployeeCase.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeCase.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager em = new(new EfEmployeeDal());
        QuitManager qm = new(new EfQuitDal());
        WorkerManager wm = new(new EfWorkerDal());
        Context c = new();


        public IActionResult Index()
        {
            ViewBag.worker = c.employeeWorkers.Count().ToString();
            ViewBag.branch = c.branches.Count().ToString();
            ViewBag.info = c.employees.Count().ToString();
            return View();
        }
        [HttpGet]
        public IActionResult EmployeeEdit(int id)
        {
            var department = c.departments.ToList();
            var position = c.positions.ToList();
            var branch = c.branches.ToList();
            ViewBag.DepartmentList = new SelectList(department, "DepertmentId", "DepartmentName");
            ViewBag.PositionList = new SelectList(position, "PositionId", "PositionName");
            ViewBag.BranchList = new SelectList(branch, "BranchId", "BranchName");
            var values = em.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EmployeeEdit(Employee employee, int id)
        {
            employee.EmployeeId = id;
            var department = c.departments.ToList();
            var position = c.positions.ToList();
            var branch = c.branches.ToList();
            ViewBag.DepartmentList = new SelectList(department, "DepertmentId", "DepartmentName", employee.DepartmentId);
            ViewBag.PositionList = new SelectList(position, "PositiontId", "PositionName", employee.PositionId);
            ViewBag.BranchList = new SelectList(branch, "BranchId", "BranchName", employee.BranchId);
            employee.EmployeeStatus = true;
            em.TUpdate(employee);
            return RedirectToAction("Index", "Employee");
        }
        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            var department = c.departments.ToList();
            var position = c.positions.ToList();
            var branch = c.branches.ToList();
            ViewBag.DepartmentList = new SelectList(department, "DepertmentId", "DepartmentName");
            ViewBag.PositionList = new SelectList(position, "PositionId", "PositionName");
            ViewBag.BranchList = new SelectList(branch, "BranchId", "BranchName");
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            var department = c.departments.ToList();
            var position = c.positions.ToList();
            var branch = c.branches.ToList();
            ViewBag.DepartmentList = new SelectList(department, "DepertmentId", "DepartmentName", employee.DepartmentId);
            ViewBag.PositionList = new SelectList(position, "PositiontId", "PositionName", employee.PositionId);
            ViewBag.BranchList = new SelectList(branch, "BranchId", "BranchName", employee.BranchId);
            em.TAdd(employee);
            return RedirectToAction("EmployeeWorkerAdd", "Worker", new { @id = employee.EmployeeId });
        }
        public IActionResult EmployeeDelete(int id)
        {
            var value = em.TGetById(id);
            var valueworker = wm.TGetById(id);
            em.TDelete(value);
            wm.TDelete(valueworker);
            return RedirectToAction("Index", "Worker");
        }
        [HttpGet]
        public IActionResult EmployeeTransfer(int id)
        {
            var worker = c.employeeWorkers.FirstOrDefault(x => x.EmployeeWorkerId == id);
            var model = new EmployeeTransferModel
            {
                EmployeeTransferId = id,
                EmployeeFirstname = worker.EmployeeFirstname,
                EmployeeLastname = worker.EmployeeLastname,
                EmployeeIdentityNumber = worker.EmployeeIdentityNumber,
                EmployeeAdress1 = worker.EmployeeAdress1,
                EmployeeAdress2 = worker.EmployeeAdress2,
                EmployeeTelNo1 = worker.EmployeeTelNo1,
                EmployeeTelNo2 = worker.EmployeeTelNo2,
                EmployeeBirthDate = worker.EmployeeBirthDate,
                EmployeeBirthPlace = worker.EmployeeBirthPlace,
                EmployeeDegree = worker.EmployeeDegree,
                EmployeeWorkStartDate = worker.EmployeeWorkStartDate,
                EmployeeWorkQuittDate = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EmployeeTransfer(EmployeeQuit employeeQuit, int id)
        {
            var worker = c.employeeWorkers.FirstOrDefault(x => x.EmployeeWorkerId == id);
            employeeQuit.EmployeeQuitId = id;
            employeeQuit.EmployeeFirstname = worker.EmployeeFirstname;
            employeeQuit.EmployeeLastname = worker.EmployeeLastname;
            employeeQuit.EmployeeIdentityNumber = worker.EmployeeIdentityNumber;
            employeeQuit.EmployeeAdress1 = worker.EmployeeAdress1;
            employeeQuit.EmployeeAdress2 = worker.EmployeeAdress2;
            employeeQuit.EmployeeTelNo1 = worker.EmployeeTelNo1;
            employeeQuit.EmployeeTelNo2 = worker.EmployeeTelNo2;
            employeeQuit.EmployeeBirthDate = worker.EmployeeBirthDate;
            employeeQuit.EmployeeBirthPlace = worker.EmployeeBirthPlace;
            employeeQuit.EmployeeDegree = worker.EmployeeDegree;
            employeeQuit.EmployeeWorkStartDate = worker.EmployeeWorkStartDate;
            
            qm.TAdd(employeeQuit);
            return RedirectToAction("EmployeeWorkerDelete", "Worker", new { @id = id /*worker.EmployeeWorkerId*/ });
        }

    }
}
