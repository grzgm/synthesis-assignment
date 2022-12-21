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
			Dictionary<int, LineItemDTO> lineItemsDict = new Dictionary<int, LineItemDTO>();

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
						DiscountDTO discountDTO = new DiscountDTO();

						int loopOrderId = reader.GetInt32(reader.GetOrdinal("id"));
						int loopLineItemId = reader.GetInt32(reader.GetOrdinal("lineItemId"));

						if (!ordersDict.ContainsKey(loopOrderId))
						{
							OrderDTO orderDTO = new OrderDTO();
							ClientDTO clientDTO = new ClientDTO();
							AddressDTO addressDTO = new AddressDTO();

							orderDTO.Id = loopOrderId;
							clientDTO.Id = reader.GetInt32(reader.GetOrdinal("clientId"));

							if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("totalBonusPointsBeforeOrder"))))
							{
								clientDTO.AmountOfPoints = reader.GetInt32(reader.GetOrdinal("totalBonusPointsBeforeOrder"));
								orderDTO.OrderBonusPoints = reader.GetInt32(reader.GetOrdinal("orderBonusPoints"));
								orderDTO.OrderSpentBonusPoints = reader.GetInt32(reader.GetOrdinal("orderSpentBonusPoints"));
							}

							orderDTO.clientDTO = clientDTO;

							orderDTO.OrderDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("orderDate")));
							if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("deliveryDate"))))
							{
								orderDTO.DeliveryDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("deliveryDate")));
							}
							else
							{
								orderDTO.DeliveryDate = null;
							}
							orderDTO.OrderStatus = reader.GetInt32(reader.GetOrdinal("orderStatus"));
							orderDTO.PaymentMethod = reader.GetInt32(reader.GetOrdinal("paymentMethodId"));

							addressDTO.Country = reader.GetString(reader.GetOrdinal("country"));
							addressDTO.City = reader.GetString(reader.GetOrdinal("city"));
							addressDTO.Street = reader.GetString(reader.GetOrdinal("street"));
							addressDTO.PostalCode = reader.GetString(reader.GetOrdinal("postalCode"));

							orderDTO.AddressDTO = addressDTO;
							orderDTO.PurchasedItems = new List<LineItemDTO>();

							ordersDict.Add(orderDTO.Id, orderDTO);
						}

						if (!lineItemsDict.ContainsKey(loopLineItemId))
						{
							lineItemDTO.Id = loopLineItemId;
							lineItemDTO.PurchasePrice = reader.GetDecimal(reader.GetOrdinal("purchasePrice"));
							lineItemDTO.Amount = reader.GetInt32(reader.GetOrdinal("amount"));

							itemDTO.Id = reader.GetInt32(reader.GetOrdinal("itemId"));
							itemDTO.Name = reader.GetString(reader.GetOrdinal("itemName"));
							itemDTO.Price = reader.GetDecimal(reader.GetOrdinal("price"));
							itemDTO.UnitType = reader.GetString(reader.GetOrdinal("unitType"));
							itemDTO.Available = reader.GetBoolean(reader.GetOrdinal("available"));
							itemDTO.StockAmount = reader.GetInt32(reader.GetOrdinal("stockAmount"));
							itemDTO.Discounts = new List<DiscountDTO>();

							itemCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("catId"));
							itemCategoryDTO.Name = reader.GetString(reader.GetOrdinal("catName"));
							itemCategoryDTO.ParentId = null;

							itemSubCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("subCatId"));
							itemSubCategoryDTO.Name = reader.GetString(reader.GetOrdinal("subCatName"));
							itemSubCategoryDTO.ParentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));

							itemDTO.Category = itemCategoryDTO;
							itemDTO.SubCategory = itemSubCategoryDTO;

							lineItemDTO.ItemDTO = itemDTO;

							if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("discountTypeId"))))
							{
								discountDTO.DiscountTypeId = reader.GetInt32(reader.GetOrdinal("discountTypeId"));
								discountDTO.StartOfDiscount = reader.GetDateTime(reader.GetOrdinal("startOfDiscount"));
								discountDTO.EndOfDiscount = reader.GetDateTime(reader.GetOrdinal("endOfDiscount"));
								discountDTO.AmountForDiscount = reader.GetInt32(reader.GetOrdinal("amountForDiscount"));
								discountDTO.DiscountValue = reader.GetDecimal(reader.GetOrdinal("discountValue"));
								discountDTO.DiscountMessage = reader.GetString(reader.GetOrdinal("discountMessage"));

								itemDTO.Discounts.Add(discountDTO);
							}

							lineItemsDict.Add(lineItemDTO.Id, lineItemDTO);
							ordersDict[loopOrderId].PurchasedItems.Add(lineItemDTO);
						}
						else
						{

							if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("discountTypeId"))))
							{
								discountDTO.DiscountTypeId = reader.GetInt32(reader.GetOrdinal("discountTypeId"));
								discountDTO.StartOfDiscount = reader.GetDateTime(reader.GetOrdinal("startOfDiscount"));
								discountDTO.EndOfDiscount = reader.GetDateTime(reader.GetOrdinal("endOfDiscount"));
								discountDTO.AmountForDiscount = reader.GetInt32(reader.GetOrdinal("amountForDiscount"));
								discountDTO.DiscountValue = reader.GetDecimal(reader.GetOrdinal("discountValue"));
								discountDTO.DiscountMessage = reader.GetString(reader.GetOrdinal("discountMessage"));

								ordersDict[loopOrderId].PurchasedItems.Find(x => x.Id == loopLineItemId).ItemDTO.Discounts.Add(discountDTO);
							}
						}

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
		bool IOrderRepository.CreateOrder(OrderDTO orderDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "BEGIN TRANSACTION;" +
						 "INSERT INTO Address VALUES (@country, @city, @street, @postalCode);" +
						 "DECLARE @addressId INT;" +
						 "SET @addressId = IDENT_CURRENT('Address')" +
						 "INSERT INTO [Order] VALUES (@clientId, @totalBonusPointsBeforeOrder, @orderBonusPoints, @orderSpentBonusPoints, @orderDate, @deliveryDate, @orderStatus, @paymentMethodId, @addressId);" +
						 "DECLARE @orderId INT;" +
						 "SET @orderId = IDENT_CURRENT('Order')" +
						 "UPDATE LineItem SET LineItem.orderId = @orderId FROM LineItem RIGHT JOIN ShoppingCart ON ShoppingCart.lineItemId = LineItem.id WHERE ShoppingCart.clientId = @clientId;" +
						 "DELETE FROM ShoppingCart WHERE clientId = @clientId;";

			for (int i = 0; i < orderDTO.PurchasedItems.Count; i++)
			{
				sql += $"UPDATE Item SET Item.stockAmount = @newStockAmount{i} WHERE Item.id = @itemId{i};";
			}

			sql += "COMMIT;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@clientId", Value = orderDTO.clientDTO.Id });
			if(orderDTO.clientDTO.AmountOfPoints != null)
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@totalBonusPointsBeforeOrder", Value = orderDTO.clientDTO.AmountOfPoints });
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderBonusPoints", Value = orderDTO.OrderBonusPoints });
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderSpentBonusPoints", Value = orderDTO.OrderSpentBonusPoints });
			}
			else
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@totalBonusPointsBeforeOrder", Value = DBNull.Value });
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderBonusPoints", Value = DBNull.Value });
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderSpentBonusPoints", Value = DBNull.Value });
			}
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderDate", Value = orderDTO.OrderDate.ToDateTime(TimeOnly.MinValue) });
			if (orderDTO.DeliveryDate != null)
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@deliveryDate", Value = orderDTO.DeliveryDate.Value.ToDateTime(TimeOnly.MinValue) });
			}
			else
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = "@deliveryDate", Value = DBNull.Value });
			}
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@orderStatus", Value = orderDTO.OrderStatus });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@paymentMethodId", Value = orderDTO.PaymentMethod });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@country", Value = orderDTO.AddressDTO.Country });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@city", Value = orderDTO.AddressDTO.City });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@street", Value = orderDTO.AddressDTO.Street });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@postalCode", Value = orderDTO.AddressDTO.PostalCode });

			for (int i = 0; i < orderDTO.PurchasedItems.Count; i++)
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = $"@newStockAmount{i}", Value = (orderDTO.PurchasedItems[i].ItemDTO.StockAmount - orderDTO.PurchasedItems[i].Amount) });
				cmd.Parameters.Add(new SqlParameter { ParameterName = $"@itemId{i}", Value = orderDTO.PurchasedItems[i].ItemDTO.Id });
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

		OrderDTO IOrderRepository.ReadOrderByClientIdOrderId(int clientId, int orderId)
		{
			string Query = "SELECT [Order].id ,clientId ,totalBonusPointsBeforeOrder ,orderBonusPoints ,orderSpentBonusPoints ,orderDate ,deliveryDate ,orderStatus, paymentMethodId, " +
				"country, city, street, postalCode, " +
				"LineItem.id AS lineItemId, LineItem.purchasePrice, LineItem.amount, " +
				"Item.id AS itemId, Item.name AS itemName, price, unitType, available, stockAmount, " +
				"Cat.id AS catId, cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM [Order] " +
				"LEFT JOIN Address ON Address.id = [Order].addressId " +
				"LEFT JOIN LineItem ON LineItem.orderId = [Order].id " +
				"LEFT JOIN Item ON Item.id = LineItem.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id AND ( Discount.id is NULL OR (Discount.startOfDiscount <= [Order].orderDate AND Discount.endOfDiscount >= [Order].orderDate)) " +
				"WHERE [Order].clientId = @clientId AND [Order].id = @orderId;";

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

		List<OrderDTO> IOrderRepository.ReadOrdersByClientId(int clientId)
		{
			string Query = "SELECT [Order].id ,clientId ,totalBonusPointsBeforeOrder ,orderBonusPoints ,orderSpentBonusPoints ,orderDate ,deliveryDate ,orderStatus, paymentMethodId, " +
				"country, city, street, postalCode, " +
				"LineItem.id AS lineItemId, LineItem.purchasePrice, LineItem.amount, " +
				"Item.id AS itemId, Item.name AS itemName, price, unitType, available, stockAmount, " +
				"Cat.id AS catId, cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM [Order] " +
				"LEFT JOIN Address ON Address.id = [Order].addressId " +
				"LEFT JOIN LineItem ON LineItem.orderId = [Order].id " +
				"LEFT JOIN Item ON Item.id = LineItem.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id AND ( Discount.id is NULL OR (Discount.startOfDiscount <= [Order].orderDate AND Discount.endOfDiscount >= [Order].orderDate)) " +
				"WHERE [Order].clientId = @clientId;";
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
