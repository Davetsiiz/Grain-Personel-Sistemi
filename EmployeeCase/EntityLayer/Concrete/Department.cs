using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int DepertmentId { get; set; }
		[MaxLength(25), MinLength(5)]
		public string DepartmentName { get; set; }
        public List<Employee> employees { get; set; }
    }
}
