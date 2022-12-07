namespace LogicLayer.Models
{
    public class LineItem
    {
        private Item item;
        private decimal purchasePrice;
        private int amount;

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
