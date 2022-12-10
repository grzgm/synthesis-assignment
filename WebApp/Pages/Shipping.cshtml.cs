using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class ShippingModel : PageModel
    {
        [BindProperty]
        public Address Address { get; set; }

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
		public void OnGet()
		{
			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));
		}

        public IActionResult OnPost()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));

			Order order = new Order(null, 999, 999, 9999, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), OrderStatus.Packed, shoppingCart.AddedItems, Address);

			bool orderSuccess = orderManager.CreateOrder(int.Parse(User.FindFirst("Id").Value), shoppingCart, order);
			return RedirectToPage("/Index", new { OrderSuccess = orderSuccess});
		}
	}
}
