using EntityLayer.Concrete;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EREN;database=EmployeeCaseDb;Integrated Security=True");
			//optionsBuilder.UseSqlServer("Data Source=104.247.162.242\\MSSQLSERVER2019;Initial Catalog=emremura_EmployeeCaseDb;user=emremura_Grain; password=#Grain1234;");



		}
        public DbSet<Branch> branches { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<EmployeeWorker> employeeWorkers { get; set; }
        public DbSet<EmployeeQuit> employeeQuits { get; set; }
    }
}
