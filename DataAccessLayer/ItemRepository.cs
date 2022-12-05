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

                        itemDTO.Id = reader.GetInt32(0);
                        itemDTO.Name = reader.GetString(1);
                        itemDTO.Price = reader.GetDecimal(2);
                        itemDTO.UnitType = reader.GetString(3);
                        itemDTO.Available = reader.GetBoolean(4);

                        itemCategoryDTO.Id = reader.GetInt32(5);
                        itemCategoryDTO.Name = reader.GetString(6);
                        itemCategoryDTO.ParentId = null;

                        itemSubCategoryDTO.Id = reader.GetInt32(7);
                        itemSubCategoryDTO.Name = reader.GetString(8);
                        itemSubCategoryDTO.ParentId = reader.GetInt32(9);

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

            return items;
        }

        public bool CreateItem(ItemDTO itemDTO)
        {
            GetConnection();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader dreader;

            string sql = "INSERT INTO Item VALUES (@name, @category, @subCategory, @price, @unitType, @available);";

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@name", Value = itemDTO.Name });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@category", Value = itemDTO.Category.Id });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@subCategory", Value = itemDTO.SubCategory.Id });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@price", Value = itemDTO.Price });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@unitType", Value = itemDTO.UnitType });
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@available", Value = itemDTO.Available });

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
            string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], t1.[id], t1.[name], t2.[id], t2.[name], t2.[parentCategory] FROM Item LEFT JOIN Category t1 ON Item.category = t1.id LEFT JOIN Category t2 ON Item.subCategory = t2.id WHERE t1.parentCategory IS NULL AND t2.parentCategory IS NOT NULL AND Item.id = @id;";
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
        public List<ItemDTO> ReadItems()
        {
            string Query = "SELECT Item.[id], Item.[name], Item.[price], Item.[unitType], Item.[available], t1.[id], t1.[name], t2.[id], t2.[name], t2.[parentCategory] FROM Item LEFT JOIN Category t1 ON Item.category = t1.id LEFT JOIN Category t2 ON Item.subCategory = t2.id WHERE t1.parentCategory IS NULL AND t2.parentCategory IS NOT NULL;";

            try
            {
                return GetItems(Query, null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
