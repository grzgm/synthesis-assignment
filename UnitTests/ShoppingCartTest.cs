using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestClass]
	public class ShoppingCartTest
	{
		[TestMethod]
		public void CalculateShoppingCartTotalPriceTest()
		{
			// Arrange
			IDiscount discount = new DiscountPercentage(50, 7, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			Item item2 = new Item();
			item2.Price = 20;
			LineItem lineItem = new LineItem(item, 10);
			LineItem lineItem2 = new LineItem(item2, 5);
			List<LineItem> lineItems = new List<LineItem>() { lineItem, lineItem2 };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			decimal value;

			// Act
			value = shoppingCart.TotalPrice();

			// Assert
			Assert.AreEqual(value, 165);
		}
		[TestMethod]
		public void CalculateShoppingCartDiscountProfitTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 5, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			Item item2 = new Item();
			item2.Price = 20;
			LineItem lineItem = new LineItem(item, 10);
			LineItem lineItem2 = new LineItem(item2, 5);
			List<LineItem> lineItems = new List<LineItem>() { lineItem, lineItem2 };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			decimal value;

			// Act
			value = shoppingCart.DiscountProfit();

			// Assert
			Assert.AreEqual(value, 20);
		}
		[TestMethod]
		public void CalculateShoppingCartPriceWithoutDiscountTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 5, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			Item item2 = new Item();
			item2.Price = 20;
			LineItem lineItem = new LineItem(item, 10);
			LineItem lineItem2 = new LineItem(item2, 5);
			List<LineItem> lineItems = new List<LineItem>() { lineItem, lineItem2 };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			decimal value;

			// Act
			value = shoppingCart.PriceWithoutDiscount();

			// Assert
			Assert.AreEqual(value, 200);
		}
		[TestMethod]
		public void ShoppingCartAddNewItemTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 10, "kg", true, 1000);
			Item item2 = new Item(2, "df", null, null, 10, "kg", true, 1000);
			LineItem lineItem = new LineItem(item, 10);
			LineItem lineItem2 = new LineItem(item2, 5);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);

			// Act
			shoppingCart.IsAddedLineItemNew(lineItem2);

			// Assert
			Assert.AreEqual(shoppingCart.AddedItems.Count, 2);
		}
		[TestMethod]
		public void ShoppingCartAddExistingItemTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 10, "kg", true, 1000);
			Item item2 = new Item(1, "test", null, null, 10, "kg", true, 1000);
			LineItem lineItem = new LineItem(item, 10);
			LineItem lineItem2 = new LineItem(item2, 5);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);

			// Act
			shoppingCart.IsAddedLineItemNew(lineItem2);

			// Assert
			Assert.AreEqual(shoppingCart.AddedItems.Count, 1);
		}
		[TestMethod]
		public void ShoppingCartAreItemsAvailableYesTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 10, "kg", true, 10);
			LineItem lineItem = new LineItem(item, 10);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			bool check;

			// Act
			check = shoppingCart.AreItemsAvailable();

			// Assert
			Assert.AreEqual(check, true);
		}
		[TestMethod]
		public void ShoppingCartAreItemsAvailable0StockDeleteItemFromShoppingCartTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 10, "kg", true, 0);
			LineItem lineItem = new LineItem(item, 10);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			// Act
			shoppingCart.AreItemsAvailable();

			// Assert
			Assert.AreEqual(shoppingCart.AddedItems.Count, 0);
		}
		[TestMethod]
		public void ShoppingCartAreItemsAvailableUnavailableItemDeleteItemFromShoppingCartTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 10, "kg", false, 100);
			LineItem lineItem = new LineItem(item, 10);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);

			// Act
			shoppingCart.AreItemsAvailable();

			// Assert
			Assert.AreEqual(shoppingCart.AddedItems.Count, 0);
		}
		[TestMethod]
		public void ShoppingCartAreItemsAvailableAmountHigherThanStockAmoutLowerAmountOfItemInShoppingCartTest()
		{
			// Arrange
			Item item = new Item(1, "test", null, null, 110, "kg", true, 100);
			LineItem lineItem = new LineItem(item, 110);
			List<LineItem> lineItems = new List<LineItem>() { lineItem };
			ShoppingCart shoppingCart = new ShoppingCart(lineItems);
			bool check;

			// Act
			check = shoppingCart.AreItemsAvailable();

			// Assert
			Assert.AreEqual(shoppingCart.AddedItems[0].Amount, 100);
		}
	}
}
