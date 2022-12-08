using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class LineItem
	{
		private Item item;
		private decimal purchasePrice;
		private int amount;

		public LineItem(Item item)
		{
			this.item = item;
			this.purchasePrice = item.Price;
			this.amount = 1;
		}

		public LineItem(Item item, int amount)
		{
			this.item = item;
			this.purchasePrice = item.Price;
			this.amount = amount;
		}
		public LineItem(LineItemDTO lineItemDTO)
		{
			this.item = new Item(lineItemDTO.ItemDTO);
			this.purchasePrice = lineItemDTO.PurchasePrice;
			this.amount = lineItemDTO.Amount;
		}

		public decimal TotalPrice()
		{
			return amount * purchasePrice;
		}
		public Item Item
		{
			get { return item; }
			set { item = value; }
		}

		public decimal PurchasePrice
		{
			get { return purchasePrice; }
			set { purchasePrice = value; }
		}
		public int Amount
		{
			get { return amount; }
			set { amount = value; }
		}
	}
}
