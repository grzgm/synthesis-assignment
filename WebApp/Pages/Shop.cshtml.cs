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
		IShoppingCartRepository shoppingCartRepository;
		IShoppingCartManager shoppingCartManager;

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
			shoppingCartRepository = new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);

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

			shoppingCartManager.CreateShoppingCart(int.Parse(User.FindFirst("Id").Value), new LineItem(addedItem, Amount));
		}
	}
}
