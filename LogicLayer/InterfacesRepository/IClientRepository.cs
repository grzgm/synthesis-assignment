using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IClientRepository
	{
		bool CreateClient(ClientDTO clientDTO);

		ClientDTO ReadClientByUsernamePassword(string username, string password);

		bool UpdateClient(ClientDTO clientDTO);

		bool DeleteClient(ClientDTO clientDTO);
	}
}
