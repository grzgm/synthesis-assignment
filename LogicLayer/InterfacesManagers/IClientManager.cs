using LogicLayer.DTOs;
using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IClientManager
	{
		bool CreateClient(Client client);
        bool CreateAddress(Client client);

        Client ReadClientByUsernamePassword(string username, string password);
		Client ReadClientById(int clientId);
		int? ReadClientBonusPointsById(int clientId);

		bool UpdateClient(Client client);
        bool UpdateClientAddBonusCardByClientId(int clientId);
        bool UpdateClientBonusPoints(int clientId, int amountOfPoints);
		bool UpdateClientAddress(Client client);

		bool DeleteClient(Client client);
	}
}
