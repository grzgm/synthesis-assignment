using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebApp.Pages
{
	public class ShoppingCartModel : PageModel
	{
		public ShoppingCart shoppingCart;

		public void OnGet()
        {
			if (Request.Cookies.ContainsKey("shoppingCart"))
			{
				shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(Request.Cookies["shoppingCart"]);
			}
			else
			{
				shoppingCart = new ShoppingCart();
			}
		}
    }
}
