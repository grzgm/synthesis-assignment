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
            this.SortAddedItems();

            if (this.addedItems.Find(x => x.Item.Name == newLineItem.Item.Name) != null)
            {
                this.addedItems.Find(x => x.Item.Name == newLineItem.Item.Name).Amount += newLineItem.Amount;
                this.lastUpdatedLineItem = this.addedItems.Find(x => x.Item.Name == newLineItem.Item.Name);
                return false;
            }
            else
            {
                this.addedItems.Add(newLineItem);
                this.lastAddedLineItem= newLineItem;
                return true;
            }
        }
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

                if (sortedShoppingCart.AddedItems.Find(x => x.Item.Name == lineItem.Item.Name) != null)
                {
                    sortedShoppingCart.AddedItems.Find(x => x.Item.Name == lineItem.Item.Name).Amount += lineItem.Amount;
                }
                else
                {
                    sortedShoppingCart.AddedItems.Add(lineItem);
                }
            }
            this.addedItems = new List<LineItem>(sortedShoppingCart.AddedItems);
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (LineItem lineItem in addedItems)
            {
                totalPrice += (lineItem.PurchasePrice * lineItem.Amount);
            }
            return totalPrice;
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
