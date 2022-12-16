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
	public class ShippingModel : PageModel
	{
		[BindProperty]
		public Address Address { get; set; }
		public int clientAmountOfPoints { get; set; }
		[BindProperty]
		public int orderBonusPoints { get; set; }
		[BindProperty]
		public bool useDefaultAddress { get; set; }
		public Client client { get; set; }
		public string mess { get; private set; }

		IShoppingCartManager shoppingCartManager;
		IShoppingCartRepository shoppingCartRepository;
		IOrderRepository orderRepository;
		IOrderManager orderManager;

		public ShoppingCart shoppingCart;

		public ShippingModel()
		{
			shoppingCartRepository = new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);

			client = new Client();
		}
		public IActionResult OnGet()
		{
			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));
			if(!shoppingCart.AreItemsAvailable())
			{
				shoppingCartManager.UpdateShoppingCartItems(int.Parse(User.FindFirst("Id").Value), shoppingCart);
				mess = "We don't have some items anymore, your order was adjusted";
			}

			if(shoppingCart.IsEmpty())
			{
				return RedirectToPage("/Shop");
			}

			if (User.FindFirst("AmountOfPoints") != null)
			{
				clientAmountOfPoints = int.Parse(User.FindFirst("AmountOfPoints").Value);
			}

			return Page();
		}

        public IActionResult OnPost()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			client.Id = int.Parse(User.FindFirst("Id").Value);
			shoppingCart = shoppingCartManager.ReadShoppingCart(client.Id);

			if(useDefaultAddress)
			{
				Address.Country = User.FindFirst("Country").Value;
				Address.City = User.FindFirst("City").Value;
				Address.Street = User.FindFirst("Street").Value;
				Address.PostalCode = User.FindFirst("PostalCode").Value;
			}


			Order order = new Order(client, null, DateOnly.FromDateTime(DateTime.Now), null, OrderStatus.OrderPlaced, shoppingCart.AddedItems, Address);
			if (User.FindFirst("AmountOfPoints") != null)
			{
				clientAmountOfPoints = int.Parse(User.FindFirst("AmountOfPoints").Value);
				order.Client.BonusCard = new BonusCard(client.Id, clientAmountOfPoints);
				order.OrderBonusPoints = orderBonusPoints;
			}

			bool orderSuccess = orderManager.CreateOrder(client.Id, order);
			return RedirectToPage("/Index", new { OrderSuccess = orderSuccess});
		}
	}
}
