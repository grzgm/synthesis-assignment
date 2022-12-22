using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class DiscountFixed : Discount, IDiscount
	{
		public DiscountFixed(int discountValue, int amountForDiscount, DateTime endOfDiscount, DateTime startOfDiscount, string discountMessage) : base(amountForDiscount, startOfDiscount, endOfDiscount, discountValue, discountMessage)
		{

		}
		public DiscountFixed(DiscountDTO discountDTO) : base(discountDTO.AmountForDiscount, discountDTO.StartOfDiscount, discountDTO.EndOfDiscount, discountDTO.DiscountValue, discountDTO.DiscountMessage)
		{

		}

		decimal IDiscount.CalculateDiscount(int amount, decimal price)
		{
			int howManyDiscounts = amount / amountForDiscount;
			return Math.Round(howManyDiscounts * discountValue, 2);
		}
	}
}
