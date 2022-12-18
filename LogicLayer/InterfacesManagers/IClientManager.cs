using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IClientManager
	{
		bool CreateClient(Client client);

		Client ReadClientByUsernamePassword(string username, string password);
		int? ReadClientBonusPointsById(int clientId);

		bool UpdateClient(Client client); 
		bool UpdateClientBonusPoints(int clientId, int amountOfPoints);

		bool DeleteClient(Client client);
	}
}
