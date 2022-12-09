using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Models
{
	public abstract class Account
	{
		private int id;
		private string firstname;
		private string lastname;
		private string email;
		private string password;

        public Account()
        {

        }
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

        [Required, MinLength(3), MaxLength(20)]
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

        [Required, EmailAddress]
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

        [Required, MinLength(3), MaxLength(20), RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Password must consist only of letters and numbers")]
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
