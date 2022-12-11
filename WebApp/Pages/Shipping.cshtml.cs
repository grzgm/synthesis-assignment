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
			return Page();
		}

        public IActionResult OnPost()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));

			Order order = new Order(null, 999, 999, 9999, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), OrderStatus.OrderPlaced, shoppingCart.AddedItems, Address);

			bool orderSuccess = orderManager.CreateOrder(int.Parse(User.FindFirst("Id").Value), order);
			return RedirectToPage("/Index", new { OrderSuccess = orderSuccess});
		}
	}
}
