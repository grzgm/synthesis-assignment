using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IEmployeeRepository
	{
		EmployeeDTO ReadEmployee(string email, string password);
	}
}
