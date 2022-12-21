using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using UnitTests.FakeDBs;

namespace UnitTests
{
	[TestClass]
	public class EmployeeLoginWebTest
	{
		private IEmployeeRepository EmployeeRepository;
		private IEmployeeManager EmployeeManager;

		[TestMethod]
		public void ReadEmployeeTest()
		{
			// Arrange
			EmployeeRepository = new FakeEmployeeDB();
			EmployeeManager = new EmployeeManager(EmployeeRepository);
			Employee employee;

			// Act
			employee = EmployeeManager.ReadEmployeeByEmailPassword("Email@Email", "asdf");

			// Assert
			Assert.AreEqual(employee.Email, "Email@Email");

		}

		//// Assert
		[TestMethod]
		//[ExpectedException(typeof(Exception))]
		public void ReadEmployeeWithWrongCredentialsEmailTest()
		{
			// Arrange
			EmployeeRepository = new FakeEmployeeDB();
			EmployeeManager = new EmployeeManager(EmployeeRepository);
			Employee employee;

			// Act
			employee = EmployeeManager.ReadEmployeeByEmailPassword("WRONG", "Password");


			// Assert
			Assert.AreEqual(employee, null);
		}
	}
}
