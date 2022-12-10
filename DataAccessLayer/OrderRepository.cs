using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class OrderRepository : MainRepository, IOrderRepository
	{
		private IEnumerable<OrderDTO> GetOrders(string Query, List<SqlParameter>? sqlParameters)
		{
			List<OrderDTO> orders = new List<OrderDTO>();

			try
			{
				SqlConnection conn = GetConnection();
				using (SqlCommand command = new SqlCommand(Query, conn))
				{
					conn.Open();
					if (sqlParameters != null)
					{
						command.Parameters.AddRange(sqlParameters.ToArray());
					}
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						OrderDTO orderDTO = new OrderDTO();
						AddressDTO addressDTO = new AddressDTO();

						orderDTO.Id = reader.GetInt32(reader.GetOrdinal("id"));
						orderDTO.TotalBonusPointsBeforeOrder = reader.GetInt32(reader.GetOrdinal("totalBonusPointsBeforeOrder"));
						orderDTO.TotalBonusPointsAfterOrder = reader.GetInt32(reader.GetOrdinal("totalBonusPointsAfterOrder"));
						orderDTO.OrderBonusPoints = reader.GetInt32(reader.GetOrdinal("orderBonusPoints"));
						orderDTO.OrderDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("orderDate")));
						orderDTO.DeliveryDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("deliveryDate")));
						orderDTO.OrderStatus = reader.GetInt32(reader.GetOrdinal("orderStatus"));

						addressDTO.Country = reader.GetString(reader.GetOrdinal("country"));
						addressDTO.City = reader.GetString(reader.GetOrdinal("city"));
						addressDTO.Street = reader.GetString(reader.GetOrdinal("street"));
						addressDTO.PostalCode = reader.GetString(reader.GetOrdinal("postalCode"));

						orderDTO.Address = addressDTO;

						orders.Add(orderDTO);
					}
				}
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.ToString());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			finally
			{
				conn.Close();
			}

			return orders;
		}
		bool IOrderRepository.CreateOrder(OrderDTO orderDTO)
		{
			throw new NotImplementedException();
		}

		OrderDTO IOrderRepository.ReadOrder(string name, string password)
		{
			throw new NotImplementedException();
		}

		bool IOrderRepository.UpdateOrder(OrderDTO orderDTO)
		{
			throw new NotImplementedException();
		}

		bool IOrderRepository.DeleteOrder(OrderDTO orderDTO)
		{
			throw new NotImplementedException();
		}
	}
}
