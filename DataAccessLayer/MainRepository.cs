using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class MainRepository
	{
		protected SqlConnection conn;
		protected string constr;

		public MainRepository()
		{
			constr = "Server=;Database=;User Id=;Password=;";
			//constr = "Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=synthesis;Integrated Security=True";
		}
        protected SqlConnection GetConnection()
        {
            conn = new SqlConnection(constr);
            return conn;
		}
	}
}
