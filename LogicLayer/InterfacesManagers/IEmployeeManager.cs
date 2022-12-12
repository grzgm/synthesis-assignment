using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IEmployeeManager
	{
		Employee ReadEmployeeByEmailPassword(string email, string password);
	}
}
