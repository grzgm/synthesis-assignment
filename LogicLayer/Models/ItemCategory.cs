using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class ItemCategory
    {
        private int id;
        private string name;
        private ItemCategory? parentCategory;

        public ItemCategory(int id, string name, ItemCategory parentCategory)
        {
            this.id = id;
            this.name = name;
            this.parentCategory = parentCategory;
        }
        public ItemCategory(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.parentCategory = null;
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
