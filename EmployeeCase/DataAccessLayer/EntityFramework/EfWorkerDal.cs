using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfWorkerDal:GenericRepository<EmployeeWorker>, IWorkerDal
    {
        public List<EmployeeWorker> GetListWorkerWithEmployee()
        {
            using (var c = new Context())
            {
                return c.employeeWorkers.Include(a => a.Employee).ToList();
            }
        }

        public List<EmployeeWorker> GetListWorkerWithId(int id)
        {
            using (var c = new Context())
            {
                return c.employeeWorkers.Include(a => a.Employee).Where(b => b.EmployeeWorkerId == id).ToList();
            }
        }
    }
}
