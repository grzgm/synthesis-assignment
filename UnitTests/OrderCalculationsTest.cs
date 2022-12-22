using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestClass]
	public class OrderCalculationsTest
	{
		[TestMethod]
		public void CalculateOrderTotalPriceTest()
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
			List<LineItem> lineItems = new List<LineItem>() { lineItem, lineItem2};
			Order order = new Order(new Client(), null, null, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), (OrderStatus)1, (PaymentMethod)1, new Address(), lineItems);
			decimal value;

			// Act
			value = order.TotalPrice();

			// Assert
			Assert.AreEqual(value, 165);
		}
		[TestMethod]
		public void CalculateOrderDiscountProfitTest()
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
			Order order = new Order(new Client(), null, null, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), (OrderStatus)1, (PaymentMethod)1, new Address(), lineItems);
			decimal value;

			// Act
			value = order.DiscountProfit();

			// Assert
			Assert.AreEqual(value, 20);
		}
		[TestMethod]
		public void CalculateOrderPriceWithoutDiscountTest()
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
			Order order = new Order(new Client(), null, null, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), (OrderStatus)1, (PaymentMethod)1, new Address(), lineItems);
			decimal value;

			// Act
			value = order.PriceWithoutDiscount();

			// Assert
			Assert.AreEqual(value, 200);
		}
	}
}
