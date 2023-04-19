using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEmployeeDal:IGenericDal<Employee>
    {
        public List<Employee> GetListWorkerEmployee();
        public List<Employee> GetListWorkerİd(int id);
        public List<Employee> GetListAllEmployee();
        public List<Employee> GetListAllEmployeeİd(int id);
        public List<Employee> GetListEmployee(int id);


    }
}
