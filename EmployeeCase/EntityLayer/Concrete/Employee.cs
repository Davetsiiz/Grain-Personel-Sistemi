using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public bool EmployeeStatus { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual EmployeeQuit EmployeeQuit { get; set; }
        public virtual EmployeeWorker EmployeeWorker { get; set; }
    }
}
