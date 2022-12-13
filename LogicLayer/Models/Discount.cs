namespace LogicLayer.Models
{
	public abstract class Discount
	{
		private DateTime startOfDiscount;
		private DateTime endOfDiscount;
		private int amountForDiscount;

		protected Discount(int amountForDiscount, DateTime startOfDiscount, DateTime endOfDiscount)
		{
			this.amountForDiscount = amountForDiscount;
			this.startOfDiscount = startOfDiscount;
			this.endOfDiscount = endOfDiscount;
		}

		public DateTime StartOfDiscount { get => startOfDiscount; set => startOfDiscount = value; }
		public DateTime EndOfDiscount { get => endOfDiscount; set => endOfDiscount = value; }
		public int AmountForDiscount { get => amountForDiscount; set => amountForDiscount = value; }
	}
}
