using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ItemRepository : MainRepository, IItemRepository
    {
        private IEnumerable<ItemDTO> GetItems(string Query, List<SqlParameter>? sqlParameters)
        {
            List<ItemDTO> items = new List<ItemDTO>();

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


                   /*     itemDTO.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        itemDTO.Name = reader.GetString(reader.GetOrdinal("name"));
                        itemDTO.Price = reader.GetDecimal(reader.GetOrdinal("price"));
                        itemDTO.UnitType = reader.GetString(reader.GetOrdinal("unitType"));
                        itemDTO.Available = reader.GetBoolean(reader.GetOrdinal("available"));
                        itemDTO.StockAmount = reader.GetInt32(reader.GetOrdinal("stockAmount"));*/

                        itemDTO.Id = reader.GetInt32(0);
                        itemDTO.Name = reader.GetString(1);
                        itemDTO.Price = reader.GetDecimal(2);
                        itemDTO.UnitType = reader.GetString(3);
                        itemDTO.Available = reader.GetBoolean(4);
                        itemDTO.StockAmount = reader.GetInt32(5);

                        itemCategoryDTO.Id = reader.GetInt32(6);
                        itemCategoryDTO.Name = reader.GetString(7);
                        itemCategoryDTO.ParentId = null;

                        itemSubCategoryDTO.Id = reader.GetInt32(8);
                        itemSubCategoryDTO.Name = reader.GetString(9);
                        itemSubCategoryDTO.ParentId = reader.GetInt32(10);

                        itemDTO.Category = itemCategoryDTO;
                        itemDTO.SubCategory = itemSubCategoryDTO;

                        items.Add(itemDTO);

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

        public ItemDTO ReadItem(int id)
        {
            string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], Item.[stockAmount], cat.[id], cat.[name], subCat.[id], subCat.[name], subCat.[parentCategory] " +
                "FROM Item LEFT JOIN Category subCat ON Item.subCategory = subCat.id LEFT JOIN Category cat ON subCat.parentCategory = cat.id " +
                "WHERE Item.id = @id;";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@id", id));
                return GetItems(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public List<ItemDTO> ReadItems(string name, int categoryId, int subCategoryId, decimal price, bool available)
        {
            string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], Item.[stockAmount], cat.[id], cat.[name], subCat.[id], subCat.[name], subCat.[parentCategory] " +
                "FROM Item LEFT JOIN Category subCat ON Item.subCategory = subCat.id LEFT JOIN Category cat ON subCat.parentCategory = cat.id " +
                "WHERE Item.available = @available";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                if(name != "")
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
                    Query += " AND subCat.id = @categoryId";
                    sqlParameters.Add(new SqlParameter("@categoryId", categoryId));
                }
                if (subCategoryId != 0)
                {
                    Query += " AND cat.id = @subCategoryId";
                    sqlParameters.Add(new SqlParameter("@subCategoryId", subCategoryId));
                }
                return GetItems(Query, sqlParameters).ToList();
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
