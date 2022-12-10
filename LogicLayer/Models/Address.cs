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
			throw new System.NotImplementedException();
		}

		public Address(string country, string city, string street, string postalCode, Client client)
		{
			throw new System.NotImplementedException();
		}

		public string Country { get => country; set => country = value; }
		public string City { get => city; set => city = value; }
		public string Street { get => street; set => street = value; }
		public string PostalCode { get => postalCode; set => postalCode = value; }
	}
}
