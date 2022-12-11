using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IEmployeeManager
	{
		Employee ReadEmployee(string email, string password);
	}
}
