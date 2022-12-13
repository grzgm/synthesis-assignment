using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class DiscountFixed : Discount, IDiscount
	{
		private decimal fixedDiscount;

		public DiscountFixed(int fixedDiscount, int amountForDiscount, DateTime endOfDiscount, DateTime startOfDiscount) : base(amountForDiscount, startOfDiscount, endOfDiscount)
		{
			this.fixedDiscount = fixedDiscount;
		}
		public DiscountFixed(DiscountDTO discountDTO) : base(discountDTO.AmountForDiscount, discountDTO.StartOfDiscount, discountDTO.EndOfDiscount)
		{
			this.fixedDiscount = discountDTO.DiscountValue;
		}

		decimal IDiscount.CalculateDiscount(int Amount, decimal Price)
		{
			throw new NotImplementedException();
		}
		public decimal FixedDiscount { get => fixedDiscount; set => fixedDiscount = value; }
	}
}
