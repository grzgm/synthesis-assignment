using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class DiscountPercentage : Discount, IDiscount
	{
		private decimal percentageDiscount;

		public DiscountPercentage(int percentageDiscount, int amountForDiscount, DateTime endOfDiscount, DateTime startOfDiscount) : base(amountForDiscount, startOfDiscount, endOfDiscount)
		{
			this.percentageDiscount= percentageDiscount;
		}
		public DiscountPercentage(DiscountDTO discountDTO) : base(discountDTO.AmountForDiscount, discountDTO.StartOfDiscount, discountDTO.EndOfDiscount)
		{
			this.percentageDiscount = discountDTO.DiscountValue;
		}

		decimal IDiscount.CalculateDiscount(int Amount, decimal Price)
		{
			throw new NotImplementedException();
		}
		public decimal PercentageDiscount { get => percentageDiscount; set => percentageDiscount = value; }
	}
}
