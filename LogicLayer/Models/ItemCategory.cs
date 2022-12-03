using LogicLayer.DTOs;

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

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public ItemCategory? ParentCategory
        {
            get { return this.parentCategory; }
            set { this.parentCategory = value; }
        }
    }
}
