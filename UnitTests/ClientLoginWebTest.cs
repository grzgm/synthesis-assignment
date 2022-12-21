using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using LogicLayer.DTOs;


namespace UnitTests
{
	[TestClass]
	public class ClientLoginWebTest
	{
		private IClientRepository clientRepository;
		private IClientManager clientManager;

		[TestMethod]
		public void CreateClient()
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
	}
}
