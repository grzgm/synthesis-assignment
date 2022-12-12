using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;
using BCrypt;
using System.Reflection.PortableExecutable;

namespace DataAccessLayer
{
	public class ClientRepository : MainRepository, IClientRepository
	{
		bool IClientRepository.CreateClient(ClientDTO clientDTO)
        {
            GetConnection();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader dreader;

            string sql = "BEGIN TRANSACTION;" +
                        "INSERT INTO Account VALUES (@firstname, @lastname, @email, @password, @salt);" +
                        "DECLARE @id INT;" +
                        "SET @id = IDENT_CURRENT('Account')" +
                        "INSERT INTO Client VALUES (@id, @username, @amountOfPoints);" +
                        "COMMIT;";

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@firstname", Value = clientDTO.Firstname});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@lastname", Value =  clientDTO.Lastname});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@email", Value =  clientDTO.Email});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = clientDTO.Username });

			string salt = GenerateSalt();
			string hashedPassword = HashPassword(clientDTO.Password, salt);

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@password", Value =  hashedPassword });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@salt", Value = salt });
			if(clientDTO.AmountOfPoints == null)
			{
				cmd.Parameters.AddWithValue("@amountOfPoints", DBNull.Value);
			}
			else
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@amountOfPoints", Value = clientDTO.AmountOfPoints });
			}

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error");
            }
            catch (Exception ex)
            {
                throw new Exception("Application error");
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return true;
        }

		ClientDTO IClientRepository.ReadClientByUsernamePassword(string username, string password)
		{
			conn = new SqlConnection(constr);
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "SELECT [Account].[id], [Account].[firstname], [Account].[lastname], [Account].[email], [Account].[password], [Account].[salt], " +
				"[Client].[username], [Client].[amountOfPoints] " +
				"FROM [Account] LEFT JOIN [Client] ON [Account].id = [Client].id " +
				"WHERE [Client].username = @username";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = username });

			ClientDTO clientDTO;

			try
			{
				dreader = cmd.ExecuteReader();

				dreader.Read();

				//Password Validation

				string hashedPassword = dreader.GetString(dreader.GetOrdinal("password"));
				string salt = dreader.GetString(dreader.GetOrdinal("salt"));

				//if(!ValidatePassword(hashedPassword, HashPassword(password, salt)))
				if(!ValidatePassword(password, hashedPassword))
				{
					throw new Exception();
				}

				clientDTO = new ClientDTO
				{
					Id = dreader.GetInt32(dreader.GetOrdinal("id")),
					Firstname = dreader.GetString(dreader.GetOrdinal("firstname")),
					Lastname = dreader.GetString(dreader.GetOrdinal("lastname")),
					Email = dreader.GetString(dreader.GetOrdinal("email")),
					Username = dreader.GetString(dreader.GetOrdinal("username")),
				};
                if(!dreader.IsDBNull(dreader.GetOrdinal("amountOfPoints")))
                    clientDTO.AmountOfPoints = dreader.GetInt32(dreader.GetOrdinal("amountOfPoints"));

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

			return clientDTO;
		}

		bool IClientRepository.UpdateClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}

		bool IClientRepository.DeleteClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}
    }
}
