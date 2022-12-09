using LogicLayer.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LogicLayer.Models
{
    public class Client : Account
    {
        //private List<Order> previousOrders;
        private string username;
        private BonusCard? bonusCard;

        public Client()
        {

        }
        public Client(ClientDTO clientDTO) : base(clientDTO.Id, clientDTO.Firstname, clientDTO.Lastname, clientDTO.Email, clientDTO.Password)
        {
            username = clientDTO.Username;
            bonusCard = new BonusCard(clientDTO.Id, clientDTO.AmountOfPoints);
        }

        [Required, MinLength(3), MaxLength(20), RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username must consist only of letters and numbers")]
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
		}
		public BonusCard? BonusCard
		{
			get { return this.bonusCard; }
            set { this.bonusCard = value; }
		}
	}
}
