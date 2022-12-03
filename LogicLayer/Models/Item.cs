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
        private int price;
        private bool available;
        private string unitType;

        public int BonusCalculator()
        {
            throw new NotImplementedException();
        }
    }
}
