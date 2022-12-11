using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class Employee : Account
	{
		private string employeeRole;

		public Employee()
		{

		}
		public Employee(EmployeeDTO employeeDTO) : base(employeeDTO.Id, employeeDTO.Firstname, employeeDTO.Lastname, employeeDTO.Email, employeeDTO.Password)
		{
			employeeRole = employeeDTO.EmployeeRole;
		}

		public string EmployeeRole { get => employeeRole; set => employeeRole = value; }
	}
}
