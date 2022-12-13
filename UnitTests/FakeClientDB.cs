using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	internal class FakeClientDB : IClientRepository
	{
		bool IClientRepository.CreateClient(ClientDTO clientDTO)
		{
			if (clientDTO.Id == 1 && clientDTO.Firstname == "FirstnameUnitTest" && clientDTO.Lastname == "LastnameUnitTest" && clientDTO.Email == "EmailUnitTest" && clientDTO.Password == "PasswordUnitTest" && clientDTO.Username == "UsernameUnitTest" && clientDTO.AmountOfPoints == null)
			{
				return true;
			}
			return false;

		}

		bool IClientRepository.DeleteClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}

		ClientDTO IClientRepository.ReadClient(string username, string password)
		{
			throw new NotImplementedException();
		}

		bool IClientRepository.UpdateClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}
	}
}
