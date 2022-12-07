using LogicLayer.DTOs;

namespace LogicLayer.Models
{
    public class Client : Account
    {
        //private List<Order> previousOrders;
        private string username;
        private BonusCard bonusCard;

        public Client(ClientDTO clientDTO) : base(clientDTO.Id, clientDTO.Firstname, clientDTO.Lastname, clientDTO.Email, clientDTO.Password)
        {
            username= clientDTO.Username;
            bonusCard = new BonusCard(clientDTO.BonusCardId, clientDTO.AmountOfPoints);
        }

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
		public BonusCard BonusCard
		{
			get { return this.bonusCard; }
		}
	}
}
