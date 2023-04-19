using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
	{
		public List<Employee> GetListWorkerEmployee()
		{
			using (var c = new Context())
			{
				return c.employees.Include(x => x.EmployeeWorker).ToList();
			}
		}
		public List<Employee> GetListWorkerİd(int id)
		{
			using (var c = new Context())
			{
				return c.employees.Include(b => b.EmployeeWorker).Where(x => x.EmployeeId == id).ToList();
			}
		}


		public List<Employee> GetListAllEmployee()
		{
			using (var c = new Context())
			{
				return c.employees.Include(x => x.Department).Include(y=>y.BranchId).Include(z=>z.Position).ToList();
			}
		}
		public List<Employee> GetListAllEmployeeİd(int id)
		{
			using (var c = new Context())
			{
				return c.employees.Include(x => x.Department).Include(y => y.BranchId).Include(z => z.Position).Where(x => x.EmployeeId == id).ToList();
			}
		}
		public List<Employee> GetListEmployee(int id)
		{
			using (var c=new Context())
			{
				return c.employees.Include(x => x.EmployeeQuit).Include(y => y.EmployeeWorker).Where(z=>z.EmployeeId==id).ToList();
			}
		}

	}
}