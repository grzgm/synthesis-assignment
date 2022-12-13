namespace LogicLayer.Models
{
	public abstract class Discount
	{
		private DateTime startOfDiscount;
		private DateTime endOfDiscount;
		private int amountForDiscount;
		private decimal discountValue;
		private string discountMessage;

		protected Discount(int amountForDiscount, DateTime startOfDiscount, DateTime endOfDiscount, decimal discountValue, string discountMessage)
		{
			this.amountForDiscount = amountForDiscount;
			this.startOfDiscount = startOfDiscount;
			this.endOfDiscount = endOfDiscount;
			this.discountValue = discountValue;
			this.discountMessage = discountMessage;
		}

		public string ToString()
		{
			return this.discountMessage;
		}
		public DateTime StartOfDiscount { get => startOfDiscount; set => startOfDiscount = value; }
		public DateTime EndOfDiscount { get => endOfDiscount; set => endOfDiscount = value; }
		public int AmountForDiscount { get => amountForDiscount; set => amountForDiscount = value; }
		public decimal DiscountValue { get => discountValue; set => discountValue = value; }
		public string DiscountMessage { get => discountMessage; set => discountMessage = value; }
	}
}
