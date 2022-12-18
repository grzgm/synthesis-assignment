using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace WebApp.Pages
{
	[Authorize]
	public class ShippingModel : PageModel
	{
		[BindProperty]
		public Address Address { get; set; }
		[BindProperty]
		public bool useDefaultAddress { get; set; }
		[BindProperty]
		public int amountOfSpentPoints { get; set; }
		public Client client { get; set; }
		public string mess { get; private set; }

		IShoppingCartManager shoppingCartManager;
		IShoppingCartRepository shoppingCartRepository;
		IOrderRepository orderRepository;
		IOrderManager orderManager;
		IClientRepository clientRepository;
		IClientManager clientManager;

		public ShoppingCart shoppingCart;

		public ShippingModel()
		{
			shoppingCartRepository = new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);
			clientRepository = new ClientRepository();
			clientManager = new ClientManager(clientRepository);

			client = new Client();
		}
		public IActionResult OnGet()
		{
			GetClient();

			shoppingCart = shoppingCartManager.ReadShoppingCart(client.Id);
			if(!shoppingCart.AreItemsAvailable())
			{
				shoppingCartManager.UpdateShoppingCartItems(client.Id, shoppingCart);
				mess = "We don't have some items anymore, your order was adjusted";
			}

			if(shoppingCart.IsEmpty())
			{
				return RedirectToPage("/Shop");
			}

			return Page();
		}

        public IActionResult OnPost()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			GetClient();

			shoppingCart = shoppingCartManager.ReadShoppingCart(client.Id);

			if(useDefaultAddress)
			{
				Address = client.Address;
			}


			Order order = new Order(client, null, null, DateOnly.FromDateTime(DateTime.Now), null, OrderStatus.OrderPlaced, shoppingCart.AddedItems, Address);
			if (client.BonusCard != null)
			{
				order.Client.BonusCard = client.BonusCard;
				order.OrderBonusPoints = Decimal.ToInt32(Math.Floor(order.TotalPrice()));
				order.OrderSpentBonusPoints = amountOfSpentPoints;
			}
			bool orderSuccess;
			if (order.Client.BonusCard != null)
				orderSuccess = (orderManager.CreateOrder(order) && clientManager.UpdateClientBonusPoints(client.Id, order.TotalBonusPointsAfterOrder().Value));
			else
				orderSuccess = orderManager.CreateOrder(order);
			return RedirectToPage("/Index", new { OrderSuccess = orderSuccess});
		}
		public void GetClient()
		{
			client = clientManager.ReadClientById(int.Parse(User.FindFirst("Id").Value));
		}
	}
}
