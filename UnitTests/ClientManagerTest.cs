using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using LogicLayer.DTOs;
using UnitTests.FakeDBs;

namespace UnitTests
{
	[TestClass]
	public class ClientManagerTest
	{
		private IClientRepository clientRepository;
		private IClientManager clientManager;

		[TestMethod]
		public void CreateClientTest()
		{
			// Arrange
			clientRepository = new FakeClientDB();
			clientManager = new ClientManager(clientRepository);
			ClientDTO clientDTO = new ClientDTO { Username = "UsernameUnitTest", AmountOfPoints = null, Id = 1, Firstname = "FirstnameUnitTest", Lastname = "LastnameUnitTest", Email = "Email@UnitTest" };
			Client client = new Client(clientDTO);
			client.Password = "Passwrod";

			// Act
			bool outcome = clientManager.CreateClient(client);

			// Assert
			Assert.AreEqual(outcome, true);

		}

		[TestMethod]
		public void ConvertToClientDTOTest()
		{
			// Arrange
			clientRepository = new FakeClientDB();
			clientManager = new ClientManager(clientRepository);
			Client client = new Client
			{
				Id = 1,
				Username = "UsernameUnitTest",
				BonusCard = new BonusCard(1, 100),
				Firstname = "FirstnameUnitTest",
				Lastname = "LastnameUnitTest",
				Email = "Email@UnitTest",
				Address = new Address() { Country = "test", City = "test", Street = "test", PostalCode = "test" }
			};
			ClientDTO clientDTOcontrol = new ClientDTO
			{
				Id = 1,
				Username = "UsernameUnitTest",
				AmountOfPoints = 100,
				Firstname = "FirstnameUnitTest",
				Lastname = "LastnameUnitTest",
				Email = "Email@UnitTest",
				AddressDTO = new AddressDTO() { Country = "test", City = "test", Street = "test", PostalCode = "test" }
			};
			bool outcome = true;

			// Act
			ClientDTO clientDTO = ClientManager.ConvertToClientDTO(client);

			// Assert
			if (clientDTO.Id != clientDTOcontrol.Id)
			{
				outcome = false;
			}
			if (clientDTO.Username != clientDTOcontrol.Username)
			{
				outcome = false;
			}
			if (clientDTO.AmountOfPoints != clientDTOcontrol.AmountOfPoints)
			{
				outcome = false;
			}
			if (clientDTO.Firstname != clientDTOcontrol.Firstname)
			{
				outcome = false;
			}
			if (clientDTO.Lastname != clientDTOcontrol.Lastname)
			{
				outcome = false;
			}
			if (clientDTO.Firstname != clientDTOcontrol.Firstname)
			{
				outcome = false;
			}
			if (clientDTO.Email != clientDTOcontrol.Email)
			{
				outcome = false;
			}
			if (clientDTO.AddressDTO.Country != clientDTOcontrol.AddressDTO.Country)
			{
				outcome = false;
			}
			if (clientDTO.AddressDTO.City != clientDTOcontrol.AddressDTO.City)
			{
				outcome = false;
			}
			if (clientDTO.AddressDTO.Street != clientDTOcontrol.AddressDTO.Street)
			{
				outcome = false;
			}
			if (clientDTO.AddressDTO.PostalCode != clientDTOcontrol.AddressDTO.PostalCode)
			{
				outcome = false;
			}
			Assert.AreEqual(outcome, true);
		}
	}
}
