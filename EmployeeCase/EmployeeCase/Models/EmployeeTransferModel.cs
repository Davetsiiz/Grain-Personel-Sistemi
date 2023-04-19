namespace EmployeeCase.Models
{
	public class EmployeeTransferModel
	{
		public int EmployeeTransferId { get; set; }
		public string EmployeeFirstname { get; set; }
		public string EmployeeLastname { get; set; }
		public string EmployeeIdentityNumber { get; set; }
		public DateTime EmployeeBirthDate { get; set; }
		public string EmployeeBirthPlace { get; set; }
		public string EmployeeAdress1 { get; set; }
		public string? EmployeeAdress2 { get; set; }
		public string EmployeeTelNo1 { get; set; }
		public string? EmployeeTelNo2 { get; set; }
		public string EmployeeDegree { get; set; }
		public DateTime EmployeeWorkStartDate { get; set; }
		public DateTime EmployeeWorkQuittDate { get; set; }
		
	}
}
