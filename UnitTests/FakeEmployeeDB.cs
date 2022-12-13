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
	internal class FakeEmployeeDB : IEmployeeRepository
	{
		EmployeeDTO IEmployeeRepository.ReadEmployee(string email, string password)
		{
			if(email == "Email@Email" && password == "Password")
			{
				return new EmployeeDTO()
				{
					Id = 1,
					Firstname = "Firstname",
					Lastname = "Lastname",
					Email = "Email@Email",
					Password = "Password",
					EmployeeRole = "EmployeeRole",
				};
			}
			throw new Exception();
		}
	}
}
