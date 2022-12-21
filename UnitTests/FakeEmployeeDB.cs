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
		EmployeeDTO IEmployeeRepository.ReadEmployeeByEmailPassword(string email)
		{
			if(email == "Email@Email")
			{
				return new EmployeeDTO()
				{
					Id = 1,
					Firstname = "Firstname",
					Lastname = "Lastname",
					Email = "Email@Email",
					Password = "$2a$10$iMKnRelMY5LMGsU5a6lAGOC4gwHBq4FaKCVN//YDFQBI7tO9QHQji",
					EmployeeRole = "EmployeeRole",
				};
			}
			throw new Exception();
		}
	}
}
