using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Managers
{
	public class AccountManager
	{
		public string GenerateSalt(int length = 10)
		{
			return BCrypt.Net.BCrypt.GenerateSalt(10);
		}

		public string HashPassword(string password, string salt)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, salt);
		}

		public bool ValidatePassword(string password, string hashedPassword)
		{
			return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
		}
	}
}
