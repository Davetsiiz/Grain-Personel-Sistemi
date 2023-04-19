using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EmployeeCase.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace EmployeeCase.Controllers
{
	public class WorkerController : Controller
	{
		WorkerManager wm = new (new EfWorkerDal());
		WorkerValidator wv = new ();
		public IActionResult Index()
		{
			var values = wm.GetListWorkerWithEmployee().OrderBy(x => x.EmployeeFirstname).ToList();
            return View(values);
		}
		public IActionResult EmployeeWorkerDetail(int id)
		{
			var values = wm.TGetById(id);
            
            return View(values);
		}
		[HttpGet]
		public IActionResult EmployeeWorkerEdit(int id)
		{
			var values = wm.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EmployeeWorkerEdit(EmployeeWorker employeeWorker,int id)
		{
            
            ValidationResult result = wv.Validate(employeeWorker);

			if (result.IsValid)
			{
				employeeWorker.EmployeeWorkerId = id;
				wm.TUpdate(employeeWorker);
				return RedirectToAction("Index", "Worker");
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
		[HttpGet]
		public IActionResult EmployeeWorkerAdd(int id)
		{
			return View();
		}
		[HttpPost]
		public	IActionResult EmployeeWorkerAdd(EmployeeWorker employeeWorker,int id)
		{
            
            ValidationResult result = wv.Validate(employeeWorker);

			if (result.IsValid)
			{
				employeeWorker.EmployeeWorkerId = id;
				wm.TAdd(employeeWorker);
				return RedirectToAction("Index", "Worker");
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
		public IActionResult EmployeeWorkerDelete(int id)
		{
			var values = wm.TGetById(id);
			wm.TDelete(values);
			return RedirectToAction("Index","Worker");
		}
		public IActionResult ExportWorkerList()
		{
			using (var workbook=new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Çalışan Listesi");
				worksheet.Cell(1, 1).Value = "#";
				worksheet.Cell(1, 2).Value = "Ad";
				worksheet.Cell(1, 3).Value = "Soyad";
				worksheet.Cell(1, 4).Value = "T.C. No";
				worksheet.Cell(1, 5).Value = "Doğum Günü";
				worksheet.Cell(1, 6).Value = "Doğum Yeri";
				worksheet.Cell(1, 7).Value = "Adres";
				worksheet.Cell(1, 8).Value = "Telefon Numarası";
				worksheet.Cell(1, 9).Value = "Öğrenim";
				worksheet.Cell(1, 10).Value = "İşe Giriş Tarihi";

				int EmployeeRowCount = 2;
				foreach (var item in WorkerList())
				{
					worksheet.Cell(EmployeeRowCount, 1).Value = EmployeeRowCount;
					worksheet.Cell(EmployeeRowCount, 2).Value = item.EmployeeFirstname;
					worksheet.Cell(EmployeeRowCount, 3).Value = item.EmployeeLastname;
					worksheet.Cell(EmployeeRowCount, 4).Value = item.EmployeeIdentityNumber;
					worksheet.Cell(EmployeeRowCount, 5).Value = item.EmployeeBirthDate;
					worksheet.Cell(EmployeeRowCount, 6).Value = item.EmployeeBirthPlace;
					worksheet.Cell(EmployeeRowCount, 7).Value = item.EmployeeAdress1;
					worksheet.Cell(EmployeeRowCount, 8).Value = item.EmployeeTelNo1;
					worksheet.Cell(EmployeeRowCount, 9).Value = item.EmployeeDegree;
					worksheet.Cell(EmployeeRowCount, 10).Value = item.EmployeeWorkStartDate;
					EmployeeRowCount++;
				}
				
				using (var stream=new MemoryStream())
				{
					workbook.SaveAs(stream);
					//stream.Seek(0, SeekOrigin.Begin);
					//const string mediaType= "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					//return new FileStreamResult(stream, mediaType)
					//{
					//	FileDownloadName = "PersonelListesi.xlsx"
					//};
					var content = stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PersonelListesi.xlsx");
				}
			}
			
			
		}
		public List<ExportModel> WorkerList()
		{
			List<ExportModel> em = new();
			using(var c=new Context())
			{
				em= c.employeeWorkers.Select(x => new ExportModel
				{
					EmployeeFirstname=x.EmployeeFirstname,
					EmployeeLastname=x.EmployeeLastname,
					EmployeeIdentityNumber=x.EmployeeIdentityNumber,
					EmployeeBirthDate=x.EmployeeBirthDate,
					EmployeeBirthPlace=x.EmployeeBirthPlace,
					EmployeeAdress1=x.EmployeeAdress1,
					EmployeeTelNo1=x.EmployeeTelNo1,
					EmployeeDegree=x.EmployeeDegree,
					EmployeeWorkStartDate=x.EmployeeWorkStartDate
				}).ToList();
			}
			return em;
		}
        public IActionResult ExportExcelWorkerList()
		{
			return View();
		}
    }

}
