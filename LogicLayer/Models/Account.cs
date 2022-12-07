namespace LogicLayer.Models
{
	public abstract class Account
	{
		private int id;
		private string firstname;
		private string lastname;
		private string email;
		private string password;

		protected Account(int id, string firstname, string lastname, string email, string password)
		{
			this.id = id;
			this.firstname = firstname;
			this.lastname = lastname;
			this.email = email;
			this.password = password;
		}

		public int Id
		{
			get { return this.id; }
		}

		public string Firstname
		{
			get
			{
				return this.firstname;
			}
			set
			{
				this.firstname = value;
			}
		}

		public string Lastname
		{
			get
			{
				return this.lastname;
			}
			set
			{
				this.lastname = value;
			}
		}

		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}

		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}
	}
}
