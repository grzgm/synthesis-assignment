using LogicLayer.DTOs;


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
            this.stockAmount= itemDTO.StockAmount;
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

        public int BonusCalculator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return id.ToString() + "; " + name + "; " + category.ToString() + "; " + subCategory.ToString() + "; " + price.ToString() + "; " + unitType + "; " + stockAmount.ToString() + "; " + available.ToString() + "; ";
        }
    }
}
