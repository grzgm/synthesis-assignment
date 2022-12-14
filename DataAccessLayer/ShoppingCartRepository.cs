using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class ShoppingCartRepository : MainRepository, IShoppingCartRepository
	{

		private IEnumerable<LineItemDTO> GetShoppingCart(string Query, List<SqlParameter>? sqlParameters)
		{
			List<LineItemDTO> lineItems = new List<LineItemDTO>();
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


						int loopLineItemId = reader.GetInt32(reader.GetOrdinal("lineItemId"));

						if (!lineItemsDict.ContainsKey(loopLineItemId))
						{
							lineItemDTO.Id = reader.GetInt32(reader.GetOrdinal("lineItemId"));
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

								lineItemsDict[loopLineItemId].ItemDTO.Discounts.Add(discountDTO);
							}
						}
					}
				}
				lineItems = lineItemsDict.Values.ToList();
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

			return lineItems;
		}
		bool IShoppingCartRepository.CreateShoppingCartItem(int clientId, LineItemDTO lineItemDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "BEGIN TRANSACTION;" +
						"INSERT INTO LineItem VALUES (@itemId, NULL, @purchasePrice, @amount);" +
						"DECLARE @id INT;" +
						"SET @id = IDENT_CURRENT('LineItem')" +
						"INSERT INTO ShoppingCart VALUES (@clientId, @id);" +
						"COMMIT;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@itemId", Value = lineItemDTO.ItemDTO.Id });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@purchasePrice", Value = lineItemDTO.ItemDTO.Price });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@amount", Value = lineItemDTO.Amount });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@clientId", Value = clientId });

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
		ShoppingCartDTO IShoppingCartRepository.ReadShoppingCart(int clientId)
		{
			string Query = "SELECT clientId, lineItemId, purchasePrice, amount, " +
				"Item.id AS itemId, Item.name AS itemName, price, unitType, available, stockAmount, " +
				"Cat.id AS catId, cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM ShoppingCart " +
				"LEFT JOIN LineItem ON LineItem.id = ShoppingCart.lineItemId " +
				"LEFT JOIN Item ON Item.id = LineItem.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id " +
				"WHERE ShoppingCart.clientId = @clientId " +
				"AND ( Discount.id is NULL OR (Discount.startOfDiscount <= GETDATE() AND Discount.endOfDiscount >= GETDATE()));";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();

			try
			{
				sqlParameters.Add(new SqlParameter("@clientId", clientId));
				return new ShoppingCartDTO() { AddedItems = GetShoppingCart(Query, sqlParameters).ToList() };
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		bool IShoppingCartRepository.UpdateShoppingCartItem(LineItemDTO lineItemDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "UPDATE LineItem SET LineItem.amount = @amount WHERE LineItem.id = @lineItemId;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@amount", Value = lineItemDTO.Amount });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@lineItemId", Value = lineItemDTO.Id });

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

		bool IShoppingCartRepository.UpdateShoppingCartItems(int clientId, ShoppingCartDTO shoppingCartDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "BEGIN TRANSACTION;" +
						 "DELETE FROM ShoppingCart WHERE clientId = @clientId;";

			for (int i = 0; i < shoppingCartDTO.AddedItems.Count; i++)
			{
				sql += $"INSERT INTO ShoppingCart VALUES (@clientId, @lineItemId{i});";
				sql += $"UPDATE LineItem SET LineItem.amount = @amount{i} WHERE LineItem.id = @lineItemId{i};";
			}
			sql += "DELETE LineItem FROM LineItem LEFT JOIN ShoppingCart ON LineItem.id = ShoppingCart.lineItemId WHERE ShoppingCart.clientId is NULL AND LineItem.orderId is NULL;" +
				   "COMMIT;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = $"@clientId", Value = clientId });

			for (int i = 0; i < shoppingCartDTO.AddedItems.Count; i++)
			{
				cmd.Parameters.Add(new SqlParameter { ParameterName = $"@amount{i}", Value = shoppingCartDTO.AddedItems[i].Amount });
				cmd.Parameters.Add(new SqlParameter { ParameterName = $"@lineItemId{i}", Value = shoppingCartDTO.AddedItems[i].Id });
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

		bool IShoppingCartRepository.DeleteShoppingCart(LineItemDTO lineItemDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "BEGIN TRANSACTION;" +
						 "DELETE FROM ShoppingCart WHERE lineItemId = @lineItemId;" +
						 "DELETE FROM LineItem WHERE id = @lineItemId;" +
						 "COMMIT;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@lineItemId", Value = lineItemDTO.Id });
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = lineItemDTO.Id });

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
	}
}
