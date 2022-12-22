using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class EmployeeManager : AccountManager, IEmployeeManager
	{
		private readonly IEmployeeRepository employeeRepository;

		public EmployeeManager(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository
				?? throw new ArgumentNullException(nameof(employeeRepository));
		}

		Employee IEmployeeManager.ReadEmployeeByEmailPassword(string email, string password)
		{
			try
			{
				EmployeeDTO employeeDTO = employeeRepository.ReadEmployeeByEmailPassword(email);

				if (!ValidatePassword(password, employeeDTO.Password))
				{
					throw new Exception();
				}

				return new Employee(employeeDTO);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
