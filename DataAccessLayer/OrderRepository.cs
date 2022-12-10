using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class OrderRepository : MainRepository, IOrderRepository
	{
		private IEnumerable<OrderDTO> GetOrders(string Query, List<SqlParameter>? sqlParameters)
		{
			List<OrderDTO> orders = new List<OrderDTO>();
			Dictionary<int, OrderDTO> ordersDict = new Dictionary<int, OrderDTO>();

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
						LineItemDTO lineItemDTO = new LineItemDTO();
						ItemDTO itemDTO = new ItemDTO();
						ItemCategoryDTO itemCategoryDTO = new ItemCategoryDTO();
						ItemCategoryDTO itemSubCategoryDTO = new ItemCategoryDTO();

						if(!ordersDict.ContainsKey(reader.GetInt32(reader.GetOrdinal("id"))))
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

							orderDTO.AddressDTO = addressDTO;
							orderDTO.PurchasedItems = new List<LineItemDTO>();

							ordersDict.Add(orderDTO.Id, orderDTO);
						}

						lineItemDTO.Id = reader.GetInt32(reader.GetOrdinal("lineItemId"));
						lineItemDTO.PurchasePrice = reader.GetDecimal(reader.GetOrdinal("purchasePrice"));
						lineItemDTO.Amount = reader.GetInt32(reader.GetOrdinal("amount"));

						itemDTO.Id = reader.GetInt32(reader.GetOrdinal("itemId"));
						itemDTO.Name = reader.GetString(reader.GetOrdinal("itemName"));
						itemDTO.Price = reader.GetDecimal(reader.GetOrdinal("price"));
						itemDTO.UnitType = reader.GetString(reader.GetOrdinal("unitType"));
						itemDTO.Available = reader.GetBoolean(reader.GetOrdinal("available"));
						itemDTO.StockAmount = reader.GetInt32(reader.GetOrdinal("stockAmount"));

						itemCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("catId"));
						itemCategoryDTO.Name = reader.GetString(reader.GetOrdinal("catName"));
						itemCategoryDTO.ParentId = null;

						itemSubCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("subCatId"));
						itemSubCategoryDTO.Name = reader.GetString(reader.GetOrdinal("subCatName"));
						itemSubCategoryDTO.ParentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));

						itemDTO.Category = itemCategoryDTO;
						itemDTO.SubCategory = itemSubCategoryDTO;

						lineItemDTO.ItemDTO = itemDTO;

						//lineItems.Add(lineItemDTO);

						ordersDict[reader.GetInt32(reader.GetOrdinal("id"))].PurchasedItems.Add(lineItemDTO);
					}
				}
				orders = ordersDict.Values.ToList();
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
		bool IOrderRepository.CreateOrder(int clientId, ShoppingCartDTO shoppingCartDTO, OrderDTO orderDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "BEGIN TRANSACTION;" +
						 "INSERT INTO [Order] VALUES (@clientId, @totalBonusPointsBeforeOrder, @totalBonusPointsAfterOrder, @orderBonusPoints, @orderDate, @deliveryDate, @orderStatus);" +
						 "DECLARE @orderId INT;" +
						 "SET @orderId = IDENT_CURRENT('Order')" +
						 "INSERT INTO Address VALUES (@orderId, @country, @city, @street, @postalCode);" +
						 "UPDATE LineItem SET LineItem.orderId = @orderId FROM LineItem RIGHT JOIN ShoppingCart ON ShoppingCart.lineItemId = LineItem.id WHERE ShoppingCart.clientId = @clientId;" +
						 "DELETE FROM ShoppingCart WHERE clientId = @clientId;" +
						 "COMMIT;"; 

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@clientId", Value = clientId });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@totalBonusPointsBeforeOrder", Value = orderDTO.TotalBonusPointsBeforeOrder });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@totalBonusPointsAfterOrder", Value = orderDTO.TotalBonusPointsBeforeOrder });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderBonusPoints", Value = orderDTO.OrderBonusPoints });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderDate", Value = orderDTO.OrderDate.ToDateTime(TimeOnly.MinValue) });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@deliveryDate", Value = orderDTO.DeliveryDate.ToDateTime(TimeOnly.MinValue) });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderStatus", Value = orderDTO.OrderStatus });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@country", Value = orderDTO.AddressDTO.Country });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@city", Value = orderDTO.AddressDTO.City });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@street", Value = orderDTO.AddressDTO.Street });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@postalCode", Value = orderDTO.AddressDTO.PostalCode });

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

		OrderDTO IOrderRepository.ReadOrder(int clientId, int orderId)
		{
			string Query = "SELECT [Order].id ,clientId ,totalBonusPointsBeforeOrder ,totalBonusPointsAfterOrder ,orderBonusPoints ,orderDate ,deliveryDate ,orderStatus, " +
				"country, city, street, postalCode, " +
				"LineItem.id AS lineItemId, LineItem.purchasePrice, LineItem.amount, " +
				"Item.id AS itemId, Item.name AS itemName, price, unitType, available, stockAmount, " +
				"Cat.id AS catId, cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory " +
				"FROM [Order] " +
				"LEFT JOIN Address ON Address.orderId = [Order].id " +
				"LEFT JOIN LineItem ON LineItem.orderId = [Order].id " +
				"LEFT JOIN Item ON Item.id = LineItem.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"WHERE [Order].clientId = @clientId AND [Order].id = @orderId";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();

			try
			{
				sqlParameters.Add(new SqlParameter("@clientId", clientId));
				sqlParameters.Add(new SqlParameter("@orderId", orderId));
				return GetOrders(Query, sqlParameters).First();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		List<OrderDTO> IOrderRepository.ReadOrders(int clientId)
		{
			string Query = "SELECT [Order].id ,clientId ,totalBonusPointsBeforeOrder ,totalBonusPointsAfterOrder ,orderBonusPoints ,orderDate ,deliveryDate ,orderStatus, " +
				"LineItem.id AS lineItemId, LineItem.purchasePrice, LineItem.amount, " +
				"Item.id AS itemId, Item.name AS itemName, price, unitType, available, stockAmount, " +
				"Cat.id AS catId, cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory " +
				"FROM [Order] " +
				"LEFT JOIN Address ON Address.orderId = [Order].id " +
				"LEFT JOIN LineItem ON LineItem.orderId = [Order].id " +
				"LEFT JOIN Item ON Item.id = LineItem.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"WHERE [Order].clientId = @clientId";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();

			try
			{
				sqlParameters.Add(new SqlParameter("@clientId", clientId));
				return GetOrders(Query, sqlParameters).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
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
