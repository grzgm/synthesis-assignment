using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTOs
{
    public class ItemDTO
    {
        public string Name
        {
            get; set;
        }

        public ItemCategoryDTO Category
        {
            get; set;
        }

        public ItemCategoryDTO SubCategory
        {
            get; set;
        }

        public decimal Price
        {
            get; set;
        }

        public bool Available
        {
            get; set;
        }

        public string UnitType
        {
            get; set;
        }
    }
}
