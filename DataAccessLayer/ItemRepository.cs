using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ItemRepository : MainRepository, IItemRepository
    {
        private IEnumerable<ItemDTO> GetItems(string Query, List<SqlParameter>? sqlParameters = null)
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

        public bool CreateItem(ItemDTO itemDTO)
        {
            GetConnection();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader dreader;

            string sql = "INSERT INTO Item VALUES (@name, @subCategory, @price, @unitType, @available, @stockAmount);";

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@name", Value = itemDTO.Name });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@subCategory", Value = itemDTO.SubCategory.Id });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@price", Value = itemDTO.Price });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@unitType", Value = itemDTO.UnitType });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@available", Value = itemDTO.Available });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@stockAmount", Value = itemDTO.StockAmount });

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

        public ItemDTO ReadItemById(int id)
        {
            string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], Item.[stockAmount], " +
				"Cat.[id] AS catId, Cat.[name] AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM Item " +
                "LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
                "LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id " +
				"WHERE Item.id = @itemId;";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@itemId", id));
                return GetItems(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
		}
		public List<ItemDTO> ReadItems(string name, int categoryId, int subCategoryId, decimal price, bool available)
		{
			string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], Item.[stockAmount], " +
				"Cat.[id] AS catId, Cat.[name] AS catName, " +
				"SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
				"FROM Item " +
                "LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
                "LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
				"LEFT JOIN Discount ON Discount.itemId = Item.id " +
				"WHERE Item.available = @available";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();

			try
			{
				if (name != "")
				{
					Query += " AND Item.name = @name";
					sqlParameters.Add(new SqlParameter("@name", name));
				}
				if (price != 0)
				{
					Query += " AND Item.price = @price";
					sqlParameters.Add(new SqlParameter("@price", price));
				}

				sqlParameters.Add(new SqlParameter("@available", available));

				if (categoryId != 0)
				{
					Query += " AND SubCat.id = @categoryId";
					sqlParameters.Add(new SqlParameter("@categoryId", categoryId));
				}
				if (subCategoryId != 0)
				{
					Query += " AND Cat.id = @subCategoryId";
					sqlParameters.Add(new SqlParameter("@subCategoryId", subCategoryId));
				}
				return GetItems(Query, sqlParameters).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
		public List<ItemDTO> ReadAvailableItems()
		{
			string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], Item.[stockAmount], " +
                "Cat.[id] AS catId, Cat.[name] AS catName, " +
                "SubCat.id AS subCatId, SubCat.name AS subCatName, SubCat.parentCategory, " +
				"Discount.discountTypeId, Discount.startOfDiscount, Discount.endOfDiscount, Discount.amountForDiscount, Discount.discountValue, Discount.discountMessage " +
                "FROM Item " +
                "LEFT JOIN Category SubCat ON Item.subCategory = SubCat.id " +
                "LEFT JOIN Category Cat ON SubCat.parentCategory = Cat.id " +
                "LEFT JOIN Discount ON Discount.itemId = Item.id " +
                "WHERE Item.available = 1 " +
                "AND Item.stockAmount > 0 " +
                "AND ( Discount.id is NULL OR (Discount.startOfDiscount <= '2022-12-13' AND Discount.endOfDiscount >= '2022-12-13'));";

			try
			{
				return GetItems(Query).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
		public bool UpdateItem(ItemDTO itemDTO)
        {
            GetConnection();
            conn.Open();
            SqlCommand cmd;

            string sql = "UPDATE Item SET [name] = @name, subCategory = @subCategory, price = @price, unitType = @unitType, available = @available, stockAmount = @stockAmount WHERE id = @id;";

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = itemDTO.Id });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@name", Value = itemDTO.Name });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@subCategory", Value = itemDTO.SubCategory.Id });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@price", Value = itemDTO.Price });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@unitType", Value = itemDTO.UnitType });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@available", Value = itemDTO.Available });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@stockAmount", Value = itemDTO.StockAmount });

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

        public bool DeleteItem(ItemDTO itemDTO)
        {
            GetConnection();
            conn.Open();
            SqlCommand cmd;

            //string sql = "DELETE FROM Item WHERE id = @id;";
            string sql = "UPDATE Item SET available = 0, stockAmount = 0 WHERE id = @id;";


            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = itemDTO.Id });

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
