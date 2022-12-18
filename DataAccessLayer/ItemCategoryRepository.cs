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
			Dictionary<int, ItemCategoryDTO> itemCategoryDict = new Dictionary<int, ItemCategoryDTO>();
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
                        ItemCategoryDTO itemCategoryDTO = new ItemCategoryDTO();
                        ItemCategoryDTO itemSubCategoryDTO = new ItemCategoryDTO();

                        int parentId = reader.GetInt32(reader.GetOrdinal("catId"));


						if (!itemCategoryDict.ContainsKey(parentId))
						{
							itemCategoryDTO.Id = parentId;
							itemCategoryDTO.Name = reader.GetString(reader.GetOrdinal("catName"));
							itemSubCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("subCatId"));
							itemSubCategoryDTO.Name = reader.GetString(reader.GetOrdinal("subCatName"));
							itemSubCategoryDTO.ParentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));

							itemCategoryDTO.SubCategories = new List<ItemCategoryDTO> { itemSubCategoryDTO };
							itemCategoryDict.Add(itemCategoryDTO.Id, itemCategoryDTO);
						}
                        else
						{
							itemSubCategoryDTO.Id = reader.GetInt32(reader.GetOrdinal("subCatId"));
							itemSubCategoryDTO.Name = reader.GetString(reader.GetOrdinal("subCatName"));
							itemSubCategoryDTO.ParentId = reader.GetInt32(reader.GetOrdinal("parentCategory"));
							itemCategoryDict[parentId].SubCategories.Add(itemSubCategoryDTO);
                        }

                    }
                    itemCategories = itemCategoryDict.Values.ToList();
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
            string Query = "SELECT t1.[id] AS catId, t1.[name] as catName, " +
                "t2.[id] AS subCatId, t2.[name] AS subCatName, t2.[parentCategory] " +
                "FROM Category t1 " +
                "LEFT JOIN Category t2 ON t1.id = t2.parentCategory " +
                "WHERE t1.parentCategory IS NULL;";

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
