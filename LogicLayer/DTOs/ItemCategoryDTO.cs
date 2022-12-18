using LogicLayer.Models;

namespace LogicLayer.DTOs
{
    public class ItemCategoryDTO
    {
        public int Id
        { get; set; }
        public string Name
        { get; set; }
		public int? ParentId
		{ get; set; }
		public List<ItemCategoryDTO>? SubCategories
		{ get; set; }
	}
}
