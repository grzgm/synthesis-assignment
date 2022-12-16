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
			constr = "Data Source=DESKTOP-PCL70MC\\SQLEXPRESS;Initial Catalog=synthesis;Integrated Security=True";
		}
        protected SqlConnection GetConnection()
        {
            conn = new SqlConnection(constr);
            return conn;
		}
		public static string GenerateSalt(int length = 10)
		{
			return BCrypt.Net.BCrypt.GenerateSalt(10);
		}

		public static string HashPassword(string password, string salt)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, salt);
		}

		public static bool ValidatePassword(string password, string hashedPassword)
		{
			return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
		}
	}
}
