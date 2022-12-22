using LogicLayer.DTOs;
using LogicLayer.Managers;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.FakeDBs;

namespace UnitTests
{
	[TestClass]
	public class DiscountCalculationTest
	{
		[TestMethod]
		public void DiscountFixedCalculateDiscountTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 5, DateTime.Now, DateTime.Now, "test");
			decimal discountValue;

			// Act
			discountValue = discount.CalculateDiscount(5, 10);

			// Assert
			Assert.AreEqual(discountValue, 10);
		}
		[TestMethod]
		public void DiscountPercentageCalculateDiscountTest()
		{
			// Arrange
			IDiscount discount = new DiscountPercentage(50, 5, DateTime.Now, DateTime.Now, "test");
			decimal discountValue;

			// Act
			discountValue = discount.CalculateDiscount(7, 10);

			// Assert
			Assert.AreEqual(discountValue, 25);
		}

		// Assert
		[ExpectedException(typeof(DivideByZeroException))]
		[TestMethod]
		public void DiscountFixedCalculateDiscountExceptionTest()
		{
			// Arrange
			IDiscount discount = new DiscountFixed(10, 0, DateTime.Now, DateTime.Now, "test");
			decimal discountValue;

			// Act
			discountValue = discount.CalculateDiscount(5, 10);
		}

		// Assert
		[ExpectedException(typeof(DivideByZeroException))]
		[TestMethod]
		public void DiscountPercentageCalculateDiscountExceptionTest()
		{
			// Arrange
			IDiscount discount = new DiscountPercentage(50, 0, DateTime.Now, DateTime.Now, "test");
			decimal discountValue;

			// Act
			discountValue = discount.CalculateDiscount(7, 10);
		}
	}
}
