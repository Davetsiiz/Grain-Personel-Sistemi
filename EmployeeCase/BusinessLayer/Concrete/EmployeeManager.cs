using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public List<Employee> GetList()
        {
            return _employeeDal.GetListAll();
        }

		public List<Employee> GetListAllEmployee()
		{
			return _employeeDal.GetListAllEmployee();
		}

		public List<Employee> GetListAllEmployeeİd(int id)
		{
			return _employeeDal.GetListAllEmployeeİd(id);
		}

        public List<Employee> GetListEmployee(int id)
        {
            return _employeeDal.GetListEmployee(id);
        }

        public List<Employee> GetListWorkerEmployee()
        {
            return _employeeDal.GetListWorkerEmployee();
        }

        public List<Employee> GetListWorkerİd(int id)
        {
            return _employeeDal.GetListWorkerİd(id);
        }

        public void TAdd(Employee t)
        {
            _employeeDal.Insert(t);
        }

        public void TDelete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee TGetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public void TUpdate(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
