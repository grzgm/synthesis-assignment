using LogicLayer.Models;

namespace LogicLayer.DTOs
{
    public class ItemCategoryDTO
    {
        public int Id
        { get; set; }
        public string Name
        { get; set; }
        public ItemCategoryDTO? ParentCategory
        { get; set; }
    }
}
