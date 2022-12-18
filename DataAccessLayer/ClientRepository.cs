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
                        "INSERT INTO Client VALUES (@id, @username, @amountOfPoints, NULL);" +
                        "COMMIT;";

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@firstname", Value = clientDTO.Firstname});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@lastname", Value =  clientDTO.Lastname});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@email", Value =  clientDTO.Email});
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = clientDTO.Username });

            cmd.Parameters.Add(new SqlParameter { ParameterName = "@password", Value =  clientDTO.Password });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@salt", Value = clientDTO.Salt });
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
				"[Client].[username], [Client].[amountOfPoints], Client.addressId, " +
				"Address.country, Address.city, Address.street, Address.postalCode " +
				"FROM [Account] " +
				"LEFT JOIN [Client] ON [Account].id = [Client].id " +
				"LEFT JOIN Address ON Address.id = Client.addressId " +
				"WHERE [Client].username = @username";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = username });

			ClientDTO clientDTO;

			try
			{
				dreader = cmd.ExecuteReader();

				dreader.Read();

				clientDTO = new ClientDTO
				{
					Id = dreader.GetInt32(dreader.GetOrdinal("id")),
					Firstname = dreader.GetString(dreader.GetOrdinal("firstname")),
					Lastname = dreader.GetString(dreader.GetOrdinal("lastname")),
					Email = dreader.GetString(dreader.GetOrdinal("email")),
					Username = dreader.GetString(dreader.GetOrdinal("username")),
					Password = dreader.GetString(dreader.GetOrdinal("password")),
					Salt = dreader.GetString(dreader.GetOrdinal("salt")),
				};

				if (!dreader.IsDBNull(dreader.GetOrdinal("amountOfPoints")))
					clientDTO.AmountOfPoints = dreader.GetInt32(dreader.GetOrdinal("amountOfPoints"));

				if (!dreader.IsDBNull(dreader.GetOrdinal("addressId")))
				{
					clientDTO.AddressDTO = new AddressDTO();
					clientDTO.AddressDTO.Country = dreader.GetString(dreader.GetOrdinal("country"));
					clientDTO.AddressDTO.City = dreader.GetString(dreader.GetOrdinal("city"));
					clientDTO.AddressDTO.Street = dreader.GetString(dreader.GetOrdinal("street"));
					clientDTO.AddressDTO.PostalCode = dreader.GetString(dreader.GetOrdinal("postalCode"));
				}

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
		int? IClientRepository.ReadClientBonusPointsById(int clientId)
		{
			conn = new SqlConnection(constr);
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "SELECT [Client].[id], [Client].[username], [Client].[amountOfPoints], Client.addressId " +
				"FROM [Client] " +
				"WHERE [Client].id = @id";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = clientId });

			int? amountOfPoints = null;

			try
			{
				dreader = cmd.ExecuteReader();

				dreader.Read();
				if (!dreader.IsDBNull(dreader.GetOrdinal("amountOfPoints")))
					amountOfPoints = dreader.GetInt32(dreader.GetOrdinal("amountOfPoints"));

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

			return amountOfPoints;
		}

		bool IClientRepository.UpdateClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}
		bool IClientRepository.UpdateClientBonusPoints(int clientId, int amountOfPoints)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;

			string sql = "UPDATE Client SET amountOfPoints = @amountOfPoints WHERE id = @id;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = clientId });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@amountOfPoints", Value = amountOfPoints });

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

		bool IClientRepository.DeleteClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}
    }
}
