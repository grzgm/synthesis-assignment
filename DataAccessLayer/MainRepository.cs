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
			constr = "Server=mssqlstud.fhict.local;Database=dbi508542_synthesis;User Id=dbi508542_synthesis;Password=123;";
		}
        public SqlConnection GetConnection()
        {
            conn = new SqlConnection(constr);
            return conn;
        }
	}
}
