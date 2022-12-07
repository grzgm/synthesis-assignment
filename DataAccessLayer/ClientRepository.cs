using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class ClientRepository : MainRepository, IClientRepository
	{
		bool IClientRepository.CreateClient(ClientDTO clientDTO)
		{
			throw new NotImplementedException();
		}

		ClientDTO IClientRepository.ReadClient(string username, string password)
		{
			conn = new SqlConnection(constr);
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "SELECT [Account].[id], [Account].[firstname], [Account].[lastname], [Account].[email], [Account].[password], " +
				"[Client].[username], [Client].[bonusCardId], [Client].[amountOfPoints] " +
				"FROM [Account] LEFT JOIN [Client] ON [Account].id = [Client].id " +
				"WHERE [Client].username = @username AND [Account].[password] = @password;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@username", Value = username });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@password", Value = password });

			ClientDTO clientDTO;

			try
			{
				dreader = cmd.ExecuteReader();

				dreader.Read();
				clientDTO = new ClientDTO
				{
					Id = dreader.GetInt32(0),
					Firstname = dreader.GetString(1).Trim(),
					Lastname = dreader.GetString(2).Trim(),
					Email = dreader.GetString(3).Trim(),
					Password = dreader.GetString(4).Trim(),
					Username = dreader.GetString(5).Trim(),
				};

				if (!DBNull.Value.Equals(dreader.GetValue(6)))
					clientDTO.BonusCardId = dreader.GetInt32(6);
				if (!DBNull.Value.Equals(dreader.GetValue(7)))
					clientDTO.AmountOfPoints = dreader.GetInt32(7);

				//if (!DBNull.Value.Equals(dreader.GetValue(6)))
				//	bonusCardDTO.Id = dreader.GetInt32(6);
				//if (!DBNull.Value.Equals(dreader.GetValue(7)))
				//	bonusCardDTO.AmountOfPoints = dreader.GetInt32(7);

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
