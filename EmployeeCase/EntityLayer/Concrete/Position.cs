using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Position
    {
        [Key]
        public int PositionId  { get; set; }
		[MaxLength(25), MinLength(5)]
		public string PositionName { get; set; }

        public List<Employee> employees { get; set; }
    }
}
