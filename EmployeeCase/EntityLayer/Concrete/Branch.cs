using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
		[MaxLength(20), MinLength(5)]
		public string BranchName { get; set; }
		[MaxLength(50), MinLength(20)]
		public string BranchAdress { get; set; }
        public List<Employee> employees { get; set; }
    }
}
