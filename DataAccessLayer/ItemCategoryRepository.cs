using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LogicLayer.InterfacesRepository;
using LogicLayer.DTOs;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;

namespace DataAccessLayer
{
	public class ItemCategoryRepository : MainRepository, IItemCategoryRepository
    {
        private IEnumerable<ItemCategoryDTO> GetItemCategories(string Query, List<SqlParameter>? sqlParameters)
        {
            List<ItemCategoryDTO> itemCategories = new List<ItemCategoryDTO>();
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
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int? parentId = null;
                        if (!DBNull.Value.Equals(reader.GetValue(reader.GetOrdinal("parentCategory"))))
                            parentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));

                        itemCategories.Add(new ItemCategoryDTO
                        {
                            Id= id,
                            Name= name,
                            ParentId = parentId,
                        });

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

            return itemCategories;
        }

        public bool CreateItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public List<ItemCategoryDTO> ReadAllItemCategories()
        {
            string Query = "SELECT [id], [name], [parentCategory] FROM Category WHERE parentCategory IS NULL;";
            //Query = "SELECT t1.[id], t1.[name], t2.[id], t2.[name], t2.[parentCategory] FROM " +
            //    "Category t1 LEFT JOIN Category t2 ON t1.id = t2.parentCategory " +
            //    "WHERE t1.parentCategory IS NULL;";

            try
            {
                return GetItemCategories(Query, null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<ItemCategoryDTO> ReadAllItemSubCategories()
        {
            string Query = "SELECT [id], [name], [parentCategory] FROM Category WHERE parentCategory IS NOT NULL;";

            try
            {
                return GetItemCategories(Query, null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool UpdateItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemCategory(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
