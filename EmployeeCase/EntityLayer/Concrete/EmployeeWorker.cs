using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EmployeeWorker
    {
        [ForeignKey("Employee")]
        [Key]
        public int EmployeeWorkerId { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public string EmployeeFirstname { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public string EmployeeLastname { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string EmployeeIdentityNumber { get; set; }
        public DateTime EmployeeBirthDate { get; set; }
        [StringLength(25, MinimumLength = 3)]
        public string EmployeeBirthPlace { get; set; }
        [StringLength(50)]
        public string EmployeeAdress1 { get; set; }
        [StringLength(50)]
        public string? EmployeeAdress2 { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string EmployeeTelNo1 { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string? EmployeeTelNo2 { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string EmployeeDegree { get; set; }
        public DateTime EmployeeWorkStartDate { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
