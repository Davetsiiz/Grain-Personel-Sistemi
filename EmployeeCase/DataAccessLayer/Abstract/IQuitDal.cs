using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IQuitDal:IGenericDal<EmployeeQuit>
    {
        public List<EmployeeQuit> GetListQuitWithEmployee();
        public List<EmployeeQuit> GetListQuitWithId(int id);
    }
}
