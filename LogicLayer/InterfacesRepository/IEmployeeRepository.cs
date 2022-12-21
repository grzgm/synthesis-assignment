using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IEmployeeRepository
	{
		EmployeeDTO ReadEmployeeByEmailPassword(string email);
	}
}
