using LogicLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.DTOs
{
	public class OrderDTO
	{
		public int Id { get; set; }
		public BonusCard? BonusCard { get; set; }
		public int? TotalBonusPointsBeforeOrder { get; set; }
		public int? TotalBonusPointsAfterOrder { get; set; }
		public int? OrderBonusPoints { get; set; }
		public DateOnly OrderDate { get; set; }
		public DateOnly DeliveryDate { get; set; }
		public int OrderStatus { get; set; }
		//public List<LineItem> PurchasedItems { get; set; }
		public AddressDTO Address { get; set; }
	}
}
