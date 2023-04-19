using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfQuitDal:GenericRepository<EmployeeQuit>,IQuitDal
    {
        public List<EmployeeQuit> GetListQuitWithEmployee()
        {
            using (var c = new Context())
            {
                return c.employeeQuits.Include(a => a.Employee).ToList();
            }
        }

        public List<EmployeeQuit> GetListQuitWithId(int id)
        {
            using (var c = new Context())
            {
                return c.employeeQuits.Include(a => a.Employee).Where(b => b.EmployeeQuitId == id).ToList();
            }
        }
    //    public List<EmployeeQuit> ListTranferQuit(int id)
    //    {
    //        using (var c=new Context())
    //        {
                
    //        }
    //    }
    }
}
