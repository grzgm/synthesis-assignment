using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Client client = new Client("UsernameUnitTest", null, 1, "FirstnameUnitTest", "LastnameUnitTest", "EmailUnitTest", "PasswordUnitTest");

			// Act
			bool outcome = clientManager.CreateClient(client);

			// Assert
			Assert.AreEqual(outcome, true);

		}
	}
}
