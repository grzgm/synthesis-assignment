using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Models
{
	public class Address
	{
		private string country;
		private string city;
		private string street;
		private string postalCode;

		public Address()
		{

		}

		public Address(string country, string city, string street, string postalCode)
		{
			this.country = country;
			this.city = city;
			this.street = street;
			this.postalCode = postalCode;
		}

		[Required]
		public string Country { get => country; set => country = value; }
		[Required]
		public string City { get => city; set => city = value; }
		[Required]
		public string Street { get => street; set => street = value; }
		[Required, DataType(DataType.PostalCode)]
		public string PostalCode { get => postalCode; set => postalCode = value; }
	}
}
