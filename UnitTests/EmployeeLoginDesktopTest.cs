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
	public class EmployeeLoginWebTest
	{
		private IEmployeeRepository EmployeeRepository;
		private IEmployeeManager EmployeeManager;

		[TestMethod]
		public void CreateEmployee()
		{
			// Arrange
			EmployeeRepository = new FakeEmployeeDB();
			EmployeeManager = new EmployeeManager(EmployeeRepository);
			Employee employee;

			// Act
			employee = EmployeeManager.ReadEmployee("Email@Email", "Password");

			// Assert
			Assert.AreEqual(employee.Email, "Email@Email");

		}

		//// Assert
		[TestMethod]
		//[ExpectedException(typeof(Exception))]
		public void CreateEmployeeWithWrongCredentialsEmail()
		{
			// Arrange
			EmployeeRepository = new FakeEmployeeDB();
			EmployeeManager = new EmployeeManager(EmployeeRepository);
			Employee employee;

			// Act
			employee = EmployeeManager.ReadEmployee("WRONG", "Password");


			// Assert
			Assert.AreEqual(employee, null);
		}
	}
}
