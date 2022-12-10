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

        public void OnPost()
        {

        }
    }
}
