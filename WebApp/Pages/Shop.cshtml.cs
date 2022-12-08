using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using System.Text.Json;

namespace WebApp.Pages
{
    public class ShopModel : PageModel
    {
        IItemRepository itemRepository;
        IItemManager itemManager;
        IItemCategoryRepository itemCategoryRepository;
        IItemCategoryManager itemCategoryManager;

        public List<Item> items;

		//TESTING
		[BindProperty]
		public int ItemId { get; set; }
		[BindProperty]
		public int Amount { get; set; }

		ShoppingCart shoppingCart;


		public ShopModel()
		{
			itemRepository = new ItemRepository();
			itemManager = new ItemManager(itemRepository);
			itemCategoryRepository = new ItemCategoryRepository();
			itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);

			items = itemManager.ReadItems("", null, null, 0, true);

			shoppingCart = new ShoppingCart();
		}

        public void OnGet()
        {

		}
		public void OnPost()
		{

		}
		public void OnPostAddItem()
		{
			Item addedItem = items.Find(item => item.Id == ItemId);
			shoppingCart.AddedItems.Add(new LineItem(addedItem, Amount));


			if (Request.Cookies.ContainsKey("shoppingCart"))
			{
				ShoppingCart shoppingCartOld = JsonSerializer.Deserialize<ShoppingCart>(Request.Cookies["shoppingCart"]);
				shoppingCart.AddedItems.AddRange(shoppingCartOld.AddedItems);

				string shoppingCartCookie = JsonSerializer.Serialize((ShoppingCart)shoppingCart);
				CookieOptions cookieOptions = new CookieOptions();
				cookieOptions.Expires = DateTime.Now.AddDays(7);
				Response.Cookies.Append("shoppingCart", shoppingCartCookie, cookieOptions);
			}
			else
			{
				string shoppingCartCookie = JsonSerializer.Serialize((ShoppingCart)shoppingCart);
				CookieOptions cookieOptions = new CookieOptions();
				cookieOptions.Expires = DateTime.Now.AddDays(7);
				Response.Cookies.Append("shoppingCart", shoppingCartCookie, cookieOptions);
			}
		}
	}
}
