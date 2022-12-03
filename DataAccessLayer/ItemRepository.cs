using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LogicLayer.InterfacesRepository;
using LogicLayer.DTOs;
using System.Xml.Linq;

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
                        int timeblockid = reader.GetInt32(0);
                        TimeSpan startingtime = reader.GetTimeSpan(1);
                        TimeSpan endingtime = reader.GetTimeSpan(2);

                        items.Add(new ItemDTO
                        {

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

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemDTO ReadItem(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
