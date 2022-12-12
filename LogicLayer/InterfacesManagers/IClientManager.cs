using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IClientManager
	{
		bool CreateClient(Client client);

		Client ReadClientByUsernamePassword(string username, string password);

		bool UpdateClient(Client client);

		bool DeleteClient(Client client);
	}
}
