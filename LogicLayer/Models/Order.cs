using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class Order
	{
		private int id;
		private BonusCard? bonusCard;
		private int? totalBonusPointsBeforeOrder;
		private int? totalBonusPointsAfterOrder;
		private int? orderBonusPoints;
		private DateOnly orderDate;
		private DateOnly deliveryDate;
		private OrderStatus orderStatus;
		private List<LineItem> purchasedItems;
		private Address address;

		public Order()
		{
			throw new System.NotImplementedException();
		}
		public Order(OrderDTO orderDTO)
		{
			this.id = orderDTO.Id;
			this.bonusCard = orderDTO.BonusCard;
			this.totalBonusPointsBeforeOrder = orderDTO.TotalBonusPointsBeforeOrder;
			this.totalBonusPointsAfterOrder = orderDTO.TotalBonusPointsAfterOrder;
			this.orderBonusPoints = orderDTO.OrderBonusPoints;
			this.orderDate = orderDTO.OrderDate;
			this.deliveryDate = orderDTO.DeliveryDate;
			this.orderStatus = orderDTO.OrderStatus;
			this.purchasedItems = orderDTO.PurchasedItems;
			this.address = orderDTO.Address;
		}

		public decimal TotalPrice()
		{
			throw new System.NotImplementedException();
		}
		public int Id { get => id; set => id = value; }
		public BonusCard? BonusCard { get => bonusCard; set => bonusCard = value; }
		public int? TotalBonusPointsBeforeOrder { get => totalBonusPointsBeforeOrder; set => totalBonusPointsBeforeOrder = value; }
		public int? TotalBonusPointsAfterOrder { get => totalBonusPointsAfterOrder; set => totalBonusPointsAfterOrder = value; }
		public int? OrderBonusPoints { get => orderBonusPoints; set => orderBonusPoints = value; }
		public DateOnly OrderDate { get => orderDate; set => orderDate = value; }
		public DateOnly DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
		public OrderStatus OrderStatus { get => orderStatus; set => orderStatus = value; }
		public List<LineItem> PurchasedItems { get => purchasedItems; set => purchasedItems = value; }
		public Address Address { get => address; set => address = value; }
	}
}
