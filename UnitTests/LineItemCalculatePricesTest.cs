using LogicLayer.Models;

namespace UnitTests
{
	[TestClass]
	public class LineItemCalculatePricesTest
	{
		[TestMethod]
		public void CalculateLineItemTotalPriceTest()
		{
			// Arrange
			IDiscount discount = new DiscountPercentage(50, 7, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			LineItem lineItem = new LineItem(item, 10);
			decimal value;

			// Act
			value = lineItem.TotalPrice();

			// Assert
			Assert.AreEqual(value, 65);
		}
		[TestMethod]
		public void CalculateLineItemDiscountProfitTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 5, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			LineItem lineItem = new LineItem(item, 10);
			decimal value;

			// Act
			value = lineItem.DiscountProfit();

			// Assert
			Assert.AreEqual(value, 20);
		}
		[TestMethod]
		public void CalculateLineItemPriceWithoutDiscountTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 5, DateTime.Now, DateTime.Now, "test");
			Item item = new Item();
			item.Price = 10;
			item.Discounts = new List<IDiscount> { discount };
			LineItem lineItem = new LineItem(item, 10);
			decimal value;

			// Act
			value = lineItem.PriceWithoutDiscount();

			// Assert
			Assert.AreEqual(value, 100);
		}
	}
}
