using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class FavListRepository : MainRepository, IFavListRepository
	{

		private IEnumerable<ItemDTO> GetFavList(string Query, List<SqlParameter>? sqlParameters = null)
		{
			List<ItemDTO> items = new List<ItemDTO>();
			Dictionary<int, ItemDTO> itemsDict = new Dictionary<int, ItemDTO>();

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
						ItemDTO itemDTO = new ItemDTO();
						ItemCategoryDTO itemCategoryDTO = new ItemCategoryDTO();
						ItemCategoryDTO itemSubCategoryDTO = new ItemCategoryDTO();
						DiscountDTO discountDTO = new DiscountDTO();


						if (!itemsDict.ContainsKey(reader.GetInt32(reader.GetOrdinal("id"))))
						{
							itemDTO.Id = reader.GetInt32(reader.GetOrdinal("id"));
							itemDTO.Name = reader.GetString(reader.GetOrdinal("name"));
							itemDTO.Price = reader.GetDecimal(reader.GetOrdinal("price"));
							itemDTO.UnitType = reader.GetString(reader.GetOrdinal("unitType"));
							itemDTO.Available = reader.GetBoolean(reader.GetOrdinal("available"));
							itemDTO.StockAmount = reader.GetInt32(reader.GetOrdinal("stockAmount"));

							itemDTO.Discounts = new List<DiscountDTO>();

							itemsDict.Add(itemDTO.Id, itemDTO);
						}

						itemCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("catId"));
						itemCategoryDTO.Name = reader.GetString(reader.GetOrdinal("catName"));
						itemCategoryDTO.ParentId = null;

						itemSubCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("subCatId"));
						itemSubCategoryDTO.Name = reader.GetString(reader.GetOrdinal("subCatName"));
						itemSubCategoryDTO.ParentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));

						itemsDict[reader.GetInt32(reader.GetOrdinal("id"))].Category = itemCategoryDTO;
						itemsDict[reader.GetInt32(reader.GetOrdinal("id"))].SubCategory = itemSubCategoryDTO;

						if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("discountTypeId"))))
						{
							discountDTO.DiscountTypeId = reader.GetInt32(reader.GetOrdinal("discountTypeId"));
							discountDTO.StartOfDiscount = reader.GetDateTime(reader.GetOrdinal("startOfDiscount"));
							discountDTO.EndOfDiscount = reader.GetDateTime(reader.GetOrdinal("endOfDiscount"));
							discountDTO.AmountForDiscount = reader.GetInt32(reader.GetOrdinal("amountForDiscount"));
							discountDTO.DiscountValue = reader.GetDecimal(reader.GetOrdinal("discountValue"));
							discountDTO.DiscountMessage = reader.GetString(reader.GetOrdinal("discountMessage"));

							itemsDict[reader.GetInt32(reader.GetOrdinal("id"))].Discounts.Add(discountDTO);
						}
					}
				}
				items = itemsDict.Values.ToList();
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

			return items;
		}
		bool IFavListRepository.CreateFavListItem(int clientId, ItemDTO itemDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "INSERT INTO FavList VALUES (@clientId, @itemId);";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@itemId", Value = itemDTO.Id });
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
		FavListDTO IFavListRepository.ReadFavList(int clientId)
		{
			string Query = "SELECT clientId, Item.id, Item.name, Item.price, Item.unitType, Item.available, Item.stockAmount, " +
				"Cat.id AS catId, Cat.name AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM FavList " +
				"LEFT JOIN Item ON Item.id = FavList.itemId " +
				"LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
				"LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id AND ( Discount.id is NULL OR (Discount.startOfDiscount <= GETDATE() AND Discount.endOfDiscount >= GETDATE())) " +
				"WHERE FavList.clientId = @clientId " +
				"AND Item.available = 1 " +
				"AND Item.stockAmount > 0;";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();

			try
			{
				sqlParameters.Add(new SqlParameter("@clientId", clientId));
				return new FavListDTO() { AddedItems = GetFavList(Query, sqlParameters).ToHashSet() };
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		bool IFavListRepository.UpdateFavListItem(ItemDTO itemDTO)
		{
			throw new NotImplementedException();
		}

		bool IFavListRepository.DeleteFavListItem(ItemDTO itemDTO)
		{
			GetConnection();
			conn.Open();
			SqlCommand cmd;
			SqlDataReader dreader;

			string sql = "DELETE FROM FavList WHERE itemId = @itemId;";

			cmd = new SqlCommand(sql, conn);
			cmd.Parameters.Add(new SqlParameter { ParameterName = "@itemId", Value = itemDTO.Id });

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
