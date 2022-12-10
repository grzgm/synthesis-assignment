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
			this.orderStatus = (OrderStatus)orderDTO.OrderStatus;
			this.purchasedItems = new List<LineItem>();
			foreach (LineItemDTO lineItemDTO in orderDTO.PurchasedItems)
			{
				this.purchasedItems.Add(new LineItem(lineItemDTO));
			}
			this.address = new Address(orderDTO.AddressDTO);
		}

		public Order(BonusCard? bonusCard, int? totalBonusPointsBeforeOrder, int? totalBonusPointsAfterOrder, int? orderBonusPoints, DateOnly orderDate, DateOnly deliveryDate, OrderStatus orderStatus, List<LineItem> purchasedItems, Address address)
		{
			this.bonusCard = bonusCard;
			this.totalBonusPointsBeforeOrder = totalBonusPointsBeforeOrder;
			this.totalBonusPointsAfterOrder = totalBonusPointsAfterOrder;
			this.orderBonusPoints = orderBonusPoints;
			this.orderDate = orderDate;
			this.deliveryDate = deliveryDate;
			this.orderStatus = orderStatus;
			this.purchasedItems = purchasedItems;
			this.address = address;
		}

		public decimal GetTotalPrice()
		{
			decimal totalPrice = 0;
			foreach (LineItem lineItem in purchasedItems)
			{
				totalPrice += (lineItem.PurchasePrice * lineItem.Amount);
			}
			return totalPrice;
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
