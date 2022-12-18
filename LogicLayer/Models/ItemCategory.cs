using LogicLayer.DTOs;

namespace LogicLayer.Models
{
	public class ItemCategory
	{
		private int id;
		private string name;
		private ItemCategory? parentCategory;
		private List<ItemCategory>? subCategories;

		public ItemCategory()
		{

		}
		// FOR BLANK ITEM CATEGORY IN THE WinForms WHEN SEARCHING
		public ItemCategory(int id, string name)
		{
			this.id = id;
			this.name = name;
			this.parentCategory = null;
			subCategories = new List<ItemCategory>();
		}

		// for the ItemCategoryManager to create SubCategory without Reference to Parent
		// for the Item Model to create Parent Category without unneccecary list of subCategories
		public ItemCategory(ItemCategoryDTO itemCategoryDTO)
		{
			this.id = itemCategoryDTO.Id;
			this.name = itemCategoryDTO.Name;
			this.parentCategory = null;
		}
		// only for the Item Model to create subCategory
		public ItemCategory(ItemCategoryDTO itemCategoryDTO, ItemCategory itemCategory)
		{
			this.id = itemCategoryDTO.Id;
			this.name = itemCategoryDTO.Name;
			this.parentCategory = itemCategory;
		}

		// only for the ItemCategoryManager to create Category with list of subCategories
		public ItemCategory(ItemCategoryDTO itemCategoryDTO, List<ItemCategory> itemSubCategories)
		{
			this.id = itemCategoryDTO.Id;
			this.name = itemCategoryDTO.Name;
			this.parentCategory = null;
			this.subCategories = itemSubCategories;
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
		public List<ItemCategory>? SubCategories
		{
			get { return this.subCategories; }
			set { this.subCategories = value; }
		}
		public override string ToString()
		{
			return name;
		}
	}
}
