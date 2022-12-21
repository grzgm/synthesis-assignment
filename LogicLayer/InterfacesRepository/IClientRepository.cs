using LogicLayer.DTOs;
using LogicLayer.Models;

namespace LogicLayer.InterfacesRepository
{
	public interface IClientRepository
	{
		bool CreateClient(ClientDTO clientDTO);
		bool CreateAddress(ClientDTO clientDTO);

		ClientDTO ReadClientByUsernamePassword(string username);
        ClientDTO ReadClientById(int clientId);
        int? ReadClientBonusPointsById(int clientId);

		bool UpdateClient(ClientDTO clientDTO);
		bool UpdateClientAddBonusCardByClientId(int clientId);
		bool UpdateClientBonusPoints(int clientId, int amountOfPoints);
        bool UpdateClientAddress(ClientDTO clientDTO);

        bool DeleteClient(ClientDTO clientDTO);
	}
}
