using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
	[Authorize]
	public class ClientDetailsModel : PageModel
    {
        IClientRepository clientRepository;
        IClientManager clientManager;

        [BindProperty]
        public Client client { get; set; }
        [BindProperty]
        public bool NewBonusCard { get; set; }
        public string mess { get; private set; }

        public ClientDetailsModel()
        {
            clientRepository = new ClientRepository();
            clientManager = new ClientManager(clientRepository);
        }

        public void OnGet()
        {
            client = clientManager.ReadClientById(int.Parse(User.FindFirst("Id").Value));
        }

        public void OnPostAddress()
        {
            Client client2 = clientManager.ReadClientById(int.Parse(User.FindFirst("Id").Value));
            client.Id = int.Parse(User.FindFirst("Id").Value);
            client.BonusCard = client2.BonusCard;

            if(client.Address.Country == null || client.Address.City == null || client.Address.Street == null || client.Address.PostalCode == null)
            {
                return;
            }

            if(client2.Address == null)
            {
                if (clientManager.CreateAddress(client))
                    mess = "Default address added. ";
                else
                    mess = "Couldn't add address. ";
            }

            else
            {
                if (clientManager.UpdateClientAddress(client))
                    mess = "Default address changed. ";
                else
                    mess = "Couldn't change address. ";
            }
        }

        public void OnPostBonusCard()
        {
            client = clientManager.ReadClientById(int.Parse(User.FindFirst("Id").Value));

            if (NewBonusCard)
			{
				if (clientManager.UpdateClientAddBonusCardByClientId(client.Id))
				{
					mess += "Now you have bonus card ";
					client.BonusCard = new BonusCard(client.Id, 0);
				}
				else
					mess += "Couldn't create bonus card. ";
			}
		}
    }
}
