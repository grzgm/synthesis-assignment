using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;

namespace LogicLayer.Models
{
	public class ShoppingCart
	{
		private List<LineItem> addedItems;
        private LineItem lastAddedLineItem;
        private LineItem lastUpdatedLineItem;

		public ShoppingCart()
		{
			addedItems = new List<LineItem>();
		}
		public ShoppingCart(List<LineItem> addedItems)
		{
			this.addedItems = addedItems;
		}
		public ShoppingCart(ShoppingCartDTO shoppingCartDTO)
		{
			addedItems = new List<LineItem>();
			foreach (LineItemDTO lineItemDTO in shoppingCartDTO.AddedItems)
			{
				addedItems.Add(new LineItem(lineItemDTO));
			}
		}

		public bool IsEmpty()
		{
            return addedItems.Count <= 0;
        }
        public bool IsAddedLineItemNew(LineItem newLineItem)
        {
            //this.SortAddedItems();

            LineItem existingLineItem = this.addedItems.Find(x => x.Item.Id == newLineItem.Item.Id);

            if (existingLineItem != null)
            {
				existingLineItem.Amount += newLineItem.Amount;
                this.lastUpdatedLineItem = existingLineItem;
                return false;
            }
            else
            {
                this.addedItems.Add(newLineItem);
                this.lastAddedLineItem= newLineItem;
                return true;
            }
        }

		// Method just in case, as items are already sorted when adding new ones
		public void SortAddedItems()
		{
			ShoppingCart sortedShoppingCart = new ShoppingCart();

			//Dictionary<string, int> sortingLineItems = new Dictionary<string, int>();

			foreach (LineItem lineItem in this.addedItems)
			{
				//if (sortingLineItems.ContainsKey(lineItem.Item.Name))
				//{
				//    sortingLineItems[lineItem.Item.Name] += lineItem.Amount;
				//}
				//else
				//{
				//    sortingLineItems.Add(lineItem.Item.Name, lineItem.Amount);
				//}
				LineItem searchLineItem = sortedShoppingCart.AddedItems.Find(x => x.Item.Id == lineItem.Item.Id);

				if (searchLineItem != null)
				{
					searchLineItem.Amount += lineItem.Amount;
				}
				else
				{
					sortedShoppingCart.AddedItems.Add(lineItem);
				}
			}
			this.addedItems = new List<LineItem>(sortedShoppingCart.AddedItems);
		}

		public bool AreItemsAvailable()
		{
			bool Availability = true;
			for (int i = 0; i < addedItems.Count; i++)
			{
				if (addedItems[i].Item.StockAmount == 0 || addedItems[i].Item.Available == false)
				{
					Availability = false;
					addedItems.RemoveAt(i);
					i--;
					continue;
				}
				else if (addedItems[i].Amount > addedItems[i].Item.StockAmount)
				{
					Availability = false;
					addedItems[i].Amount = addedItems[i].Item.StockAmount;
				}
			}
			return Availability;
		}

		public decimal TotalPrice()
		{
			return Math.Round(PriceWithoutDiscount() - DiscountProfit(), 2);
		}
		public decimal DiscountProfit()
		{
			decimal discountProfit = 0;
			foreach (LineItem lineItem in addedItems)
			{
				discountProfit += lineItem.DiscountProfit();
			}
			return Math.Round(discountProfit, 2);
		}
		public decimal PriceWithoutDiscount()
		{
			decimal priceWithoutDiscount = 0;
			foreach (LineItem lineItem in addedItems)
			{
				priceWithoutDiscount += lineItem.PriceWithoutDiscount();
			}
			return Math.Round(priceWithoutDiscount, 2);
		}

		public List<LineItem> AddedItems
        {
            get { return this.addedItems; }
            set { this.addedItems = value; }
        }

        public LineItem LastAddedLineItem { get => lastAddedLineItem; set => lastAddedLineItem = value; }
        public LineItem LastUpdatedLineItem { get => lastUpdatedLineItem; set => lastUpdatedLineItem = value; }
    }
}
