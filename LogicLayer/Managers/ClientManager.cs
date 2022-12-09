using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class ClientManager : IClientManager
	{
		private readonly IClientRepository clientRepository;

		public ClientManager(IClientRepository clientRepository)
		{
			this.clientRepository = clientRepository
				?? throw new ArgumentNullException(nameof(clientRepository));
		}

		bool IClientManager.CreateClient(Client client)
		{
			try
			{
				return clientRepository.CreateClient(ConvertToClientDTO(client));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		Client IClientManager.ReadClient(string username, string password)
		{
			try
			{
				return new Client(clientRepository.ReadClient(username, password));
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		bool IClientManager.UpdateClient(Client client)
		{
			throw new NotImplementedException();
		}

		bool IClientManager.DeleteClient(Client client)
		{
			throw new NotImplementedException();
		}

		private ClientDTO ConvertToClientDTO(Client client)
		{
			ClientDTO clientDTO = new ClientDTO()
			{
				Id = client.Id,
				Firstname = client.Firstname,
				Lastname = client.Lastname,
				Email = client.Email,
				Password = client.Password,
				Username = client.Username,
			};
			if(client.BonusCard != null)
			{
				clientDTO.AmountOfPoints = client.BonusCard.AmountOfPoints;
			}
			else
			{
				clientDTO.AmountOfPoints = null;
			}
			return clientDTO;
		}
	}
}
