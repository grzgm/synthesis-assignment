using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class EmployeeRepository : MainRepository, IEmployeeRepository
	{
		EmployeeDTO IEmployeeRepository.ReadEmployeeByEmailPassword(string email, string password)
		{
			conn = new SqlConnection(constr);
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "SELECT Account.[id], Account.[firstname], Account.[lastname], Account.[email], Account.[password], Account.[salt], " +
				"Employee.Role " +
				"FROM Account LEFT JOIN Employee ON Account.id = Employee.id " +
				"WHERE Account.email = @email";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@email", Value = email });

			EmployeeDTO employeeDTO;

			try
			{
				dreader = cmd.ExecuteReader();

				dreader.Read();

				//Password Validation

				string hashedPassword = dreader.GetString(dreader.GetOrdinal("password"));
				string salt = dreader.GetString(dreader.GetOrdinal("salt"));

				//if(!ValidatePassword(hashedPassword, HashPassword(password, salt)))
				if (!ValidatePassword(password, hashedPassword))
				{
					throw new Exception();
				}

				employeeDTO = new EmployeeDTO
				{
					Id = dreader.GetInt32(dreader.GetOrdinal("id")),
					Firstname = dreader.GetString(dreader.GetOrdinal("firstname")),
					Lastname = dreader.GetString(dreader.GetOrdinal("lastname")),
					Email = dreader.GetString(dreader.GetOrdinal("email")),
					EmployeeRole = dreader.GetString(dreader.GetOrdinal("role")),
				};

				dreader.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("There is no such user.");
			}
			finally
			{
				cmd.Dispose();
				conn.Close();
			}

			return employeeDTO;
		}
	}
}
