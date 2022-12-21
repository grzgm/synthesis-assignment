using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;

namespace UnitTests.FakeDBs
{
    internal class FakeClientDB : IClientRepository
    {
        bool IClientRepository.CreateAddress(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.CreateClient(ClientDTO clientDTO)
        {
            if (clientDTO.Id == 1 && clientDTO.Firstname == "FirstnameUnitTest" && clientDTO.Lastname == "LastnameUnitTest" && clientDTO.Email == "Email@UnitTest" && clientDTO.Username == "UsernameUnitTest" && clientDTO.AmountOfPoints == null)
            {
                return true;
            }
            return false;

        }

        int? IClientRepository.ReadClientBonusPointsById(int clientId)
        {
            throw new NotImplementedException();
        }

        ClientDTO IClientRepository.ReadClientById(int clientId)
        {
            throw new NotImplementedException();
        }

        ClientDTO IClientRepository.ReadClientByUsernamePassword(string username)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.UpdateClient(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.UpdateClientAddBonusCardByClientId(int clientId)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.UpdateClientAddress(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        bool IClientRepository.UpdateClientBonusPoints(int clientId, int amountOfPoints)
        {
            throw new NotImplementedException();
        }
        bool IClientRepository.DeleteClient(ClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
