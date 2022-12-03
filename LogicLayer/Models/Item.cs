using LogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer.Models
{

    public class Item
    {
        private int id;
        private string name;
        private ItemCategory category;
        private ItemCategory subCategory;
        private decimal price;
        private bool available;
        private string unitType;

        public Item()
        {

        }

        public Item(ItemDTO itemDTO)
        {

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

        public int BonusCalculator()
        {
            throw new NotImplementedException();
        }
    }
}
