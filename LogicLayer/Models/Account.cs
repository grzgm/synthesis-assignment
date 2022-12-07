using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
	public abstract class Account
	{
		private int id;
		private string firstname;
		private string lastname;
		private string email;
		private string password;

		public int Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
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
