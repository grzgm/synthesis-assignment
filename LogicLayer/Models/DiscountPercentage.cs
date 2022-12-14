using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class DiscountPercentage : Discount, IDiscount
	{
		public DiscountPercentage(int discountValue, int amountForDiscount, DateTime endOfDiscount, DateTime startOfDiscount, string discountMessage) : base(amountForDiscount, startOfDiscount, endOfDiscount, discountValue, discountMessage)
		{

		}
		public DiscountPercentage(DiscountDTO discountDTO) : base(discountDTO.AmountForDiscount, discountDTO.StartOfDiscount, discountDTO.EndOfDiscount, discountDTO.DiscountValue, discountDTO.DiscountMessage)
		{
		}

		decimal IDiscount.CalculateDiscount(int amount, decimal price)
		{
			int howManyDiscounts = amount / amountForDiscount;
			return howManyDiscounts * price * discountValue * 0.01m * -1;
		}
	}
}
