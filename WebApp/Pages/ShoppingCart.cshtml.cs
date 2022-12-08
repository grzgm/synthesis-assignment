using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
	public class ShoppingCartModel : PageModel
	{
		IShoppingCartManager shoppingCartManager;
		IShoppingCartRepository shoppingCartRepository;
		public ShoppingCart shoppingCart;

		public ShoppingCartModel() {
			shoppingCartRepository= new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);
		}

		public void OnGet()
        {
			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));
		}
    }
}
