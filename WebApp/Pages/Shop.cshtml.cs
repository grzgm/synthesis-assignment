using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
		IFavListRepository favListRepository;
		IFavListManager favListManager;

		public List<Item> items;

		[BindProperty]
		public int ItemId { get; set; }		
		[BindProperty(SupportsGet = true)]
		public int FavItemId { get; set; }
		[BindProperty]
		public int Amount { get; set; }
		[BindProperty]
		public string mess { get; set; }

		public List<Item> favListItems;
		ShoppingCart shoppingCart;


		public ShopModel()
		{
			itemRepository = new ItemRepository();
			itemManager = new ItemManager(itemRepository);
			itemCategoryRepository = new ItemCategoryRepository();
			itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);
			shoppingCartRepository = new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);
			favListRepository = new FavListRepository();
			favListManager = new FavListManager(favListRepository);

			items = itemManager.ReadAvailableItems();
		}

		public void OnGet()
		{
			favListItems = favListManager.ReadFavList(int.Parse(User.FindFirst("Id").Value)).AddedItems.ToList();
		}
		public void OnPostAddItem()
		{
			favListItems = favListManager.ReadFavList(int.Parse(User.FindFirst("Id").Value)).AddedItems.ToList();
			bool success;

			Item addedItem = items.Find(x => x.Id == ItemId);

			if (Amount > 0 && Amount <= addedItem.StockAmount)
			{
				shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));

				LineItem addedLineItem = new LineItem(addedItem, Amount);

				if (shoppingCart.IsAddedLineItemNew(addedLineItem))
				{
					success = shoppingCartManager.CreateShoppingCartItem(int.Parse(User.FindFirst("Id").Value), addedLineItem);
				}
				else
				{
					success = shoppingCartManager.UpdateShoppingCartItem(shoppingCart.LastUpdatedLineItem);
				}
				if (success)
				{
					mess = "Item added to shopping cart";
				}
				else
				{
					mess = "Couldn't add item to shopping cart";
				}
			}
		}
		public void OnGetFavItem()
		{
			favListItems = favListManager.ReadFavList(int.Parse(User.FindFirst("Id").Value)).AddedItems.ToList();
			favListManager.CreateFavListItem(int.Parse(User.FindFirst("Id").Value), items.Find(x => x.Id == FavItemId));
		}
	}
}
