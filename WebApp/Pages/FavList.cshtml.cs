using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class FavListModel : PageModel
	{
		IFavListRepository favListRepository;
		IFavListManager favListManager;
		IShoppingCartRepository shoppingCartRepository;
		IShoppingCartManager shoppingCartManager;

		public FavList favList;

		public List<Item> items;

		[BindProperty]
		public int ItemId { get; set; }
		[BindProperty]
		public List<int> Amount { get; set; } = new List<int>();
		[BindProperty]
		public string mess { get; set; }

		ShoppingCart shoppingCart;


		public FavListModel()
		{
			favListRepository = new FavListRepository();
			favListManager = new FavListManager(favListRepository);
			shoppingCartRepository = new ShoppingCartRepository();
			shoppingCartManager = new ShoppingCartManager(shoppingCartRepository);
		}

		public void OnGet()
		{
			GetItems();
		}
		public void OnPostAddAll()
		{
			GetItems();
			bool success;

			shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));

			foreach (Item item in items)
			{
				if (Amount[items.IndexOf(item)] > 0 && Amount[items.IndexOf(item)] <= item.StockAmount)
				{

					LineItem addedLineItem = new LineItem(item, Amount[items.IndexOf(item)]);

					shoppingCart.IsAddedLineItemNew(addedLineItem);
				}

			}

			success = shoppingCartManager.UpdateShoppingCartItems(int.Parse(User.FindFirst("Id").Value), shoppingCart);

			if (success)
			{
				mess = "Items added to shopping cart";
			}
			else
			{
				mess = "Couldn't add items to shopping cart";
			}
		}
		public void OnPostAddItem()
		{
			GetItems();
			bool success;

			Item addedItem = items.Find(x => x.Id == ItemId);

			if (Amount[items.IndexOf(addedItem)] > 0 && Amount[items.IndexOf(addedItem)] <= addedItem.StockAmount)
			{
				shoppingCart = shoppingCartManager.ReadShoppingCart(int.Parse(User.FindFirst("Id").Value));

				LineItem addedLineItem = new LineItem(addedItem, Amount[items.IndexOf(addedItem)]);

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
			else
			{
				mess = "Select amount higher than 0";
			}
		}
		public void OnPostDeleteItem()
		{
			GetItems();
			favListManager.DeleteFavListItem(items.Find(x => x.Id == ItemId));
		}

		public void GetItems()
		{
			favList = favListManager.ReadFavList(int.Parse(User.FindFirst("Id").Value));
			items = favList.AddedItems.ToList();
		}
	}
}
