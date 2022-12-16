namespace LogicLayer.DTOs
{
	public class DiscountDTO
	{
		public int DiscountTypeId { get; set; }
		public DateTime StartOfDiscount { get; set; }
		public DateTime EndOfDiscount { get; set; }
		public int AmountForDiscount { get; set; }
		public decimal DiscountValue { get; set; }
		public string DiscountMessage { get; set; }
	}
}
