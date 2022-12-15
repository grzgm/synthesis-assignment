using LogicLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.DTOs
{
	public class OrderDTO
	{
		public int Id { get; set; }
		public ClientDTO clientDTO { get; set; }
		public int? OrderBonusPoints { get; set; }
		public DateOnly OrderDate { get; set; }
		public DateOnly DeliveryDate { get; set; }
		public int OrderStatus { get; set; }
		public List<LineItemDTO> PurchasedItems { get; set; }
		public AddressDTO AddressDTO { get; set; }
	}
}
