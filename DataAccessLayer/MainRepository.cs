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
			//constr = "Data Source=DESKTOP-PCL70MC\\SQLEXPRESS;Initial Catalog=synthesis;Integrated Security=True";
		}
        protected SqlConnection GetConnection()
        {
            conn = new SqlConnection(constr);
            return conn;
		}
	}
}
