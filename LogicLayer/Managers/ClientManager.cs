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
				ClientDTO clientDTO= ConvertToClientDTO(client);
				clientDTO.Salt = AccountManager.GenerateSalt();
				clientDTO.Password = AccountManager.HashPassword(client.Password, clientDTO.Salt);

				return clientRepository.CreateClient(clientDTO);
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		bool IClientManager.CreateAddress(Client client)
		{
			try
			{
				return clientRepository.CreateAddress(ConvertToClientDTO(client));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		Client IClientManager.ReadClientByUsernamePassword(string username, string password)
		{
			try
			{
				ClientDTO clientDTO = clientRepository.ReadClientByUsernamePassword(username);

				if (!AccountManager.ValidatePassword(password, clientDTO.Password))
				{
					throw new Exception();
				}

				return new Client(clientDTO);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

        Client IClientManager.ReadClientById(int clientId)
        {
            try
            {
                return new Client(clientRepository.ReadClientById(clientId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        int? IClientManager.ReadClientBonusPointsById(int clientId)
		{
			try
			{
				return clientRepository.ReadClientBonusPointsById(clientId);
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
		bool IClientManager.UpdateClientAddBonusCardByClientId(int clientId)
        {
			try
			{
				return clientRepository.UpdateClientAddBonusCardByClientId(clientId);
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		bool IClientManager.UpdateClientBonusPoints(int clientId, int amountOfPoints)
		{
			try
			{
				return clientRepository.UpdateClientBonusPoints(clientId, amountOfPoints);
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		bool IClientManager.UpdateClientAddress(Client client)
        {
			try
			{
				return clientRepository.UpdateClientAddress(ConvertToClientDTO(client));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		bool IClientManager.DeleteClient(Client client)
		{
			throw new NotImplementedException();
		}

		public static ClientDTO ConvertToClientDTO(Client client)
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
            if (client.Address != null)
            {
				clientDTO.AddressDTO = new AddressDTO()
                {
                    Country = client.Address.Country,
                    City = client.Address.City,
                    Street = client.Address.Street,
                    PostalCode = client.Address.PostalCode,
                };
            }
            return clientDTO;
		}
	}
}
