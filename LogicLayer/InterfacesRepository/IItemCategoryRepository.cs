using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IItemCategoryRepository
	{
		bool CreateItemCategory(ItemCategoryDTO itemCategoryDTO);

		ItemCategoryDTO ReadItemCategory(string name, string password);

		bool UpdateItemCategory(ItemCategoryDTO itemCategoryDTO);

		bool DeleteItemCategory(int Id);
	}
}
