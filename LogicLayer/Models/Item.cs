using LogicLayer.DTOs;
using System.Text.Json.Serialization;

namespace LogicLayer.Models
{

    public class Item
    {
        private int id;
        private string name;
        private ItemCategory category;
        private ItemCategory subCategory;
        private decimal price;
        private string unitType;
        private bool available;
        private int stockAmount;
        private List<IDiscount> discounts;
		public Item()
		{
		}
		public Item(ItemDTO itemDTO)
		{
			this.id = itemDTO.Id;
			this.name = itemDTO.Name;
			this.category = new ItemCategory(itemDTO.Category);
			this.subCategory = new ItemCategory(itemDTO.SubCategory, this.Category);
			this.price = itemDTO.Price;
			this.available = itemDTO.Available;
			this.unitType = itemDTO.UnitType;
			this.stockAmount = itemDTO.StockAmount;
            this.discounts = new List<IDiscount>();

			if (itemDTO.Discounts.Any())
            {
                this.discounts= new List<IDiscount>();
                foreach (DiscountDTO discountDTO in itemDTO.Discounts)
                {
                    IDiscount discount;
                    switch (discountDTO.DiscountTypeId)
					{
						case 1:
							discount = new DiscountFixed(discountDTO);
                            break;
						case 2:
							discount = new DiscountPercentage(discountDTO);
                            break;
                        // check it with DiscountTypeId 3
						default:
                            continue;
                            break;
                    }
                    this.discounts.Add(discount);
                }

			}
		}
		public Item(int id, string name, ItemCategory category, ItemCategory subCategory, decimal price, string unitType, bool available, int stockAmount)
		{
			this.id = id;
			this.name = name;
			this.category = category;
			this.subCategory = subCategory;
			this.price = price;
			this.unitType = unitType;
			this.available = available;
			this.stockAmount = stockAmount;
		}

		public int Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ItemCategory Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public ItemCategory SubCategory
        {
            get { return this.subCategory; }
            set { this.subCategory = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public bool Available
        {
            get { return this.available; }
            set { this.available = value; }
        }

        public string UnitType
        {
            get { return this.unitType; }
            set { this.unitType = value; }
        }
        public int StockAmount
        {
            get { return this.stockAmount; }
            set { this.stockAmount = value; }
        }

		public List<IDiscount> Discounts 
        {
            get { return this.discounts; }
            set { this.discounts = value; } 
        }

        public override string ToString()
        {
            return id.ToString() + "; " + name + "; " + category.ToString() + "; " + subCategory.ToString() + "; " + price.ToString() + "; " + unitType + "; " + stockAmount.ToString() + "; " + available.ToString() + "; ";
        }
    }
}
