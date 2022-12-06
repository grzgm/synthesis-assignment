using LogicLayer.DTOs;
using LogicLayer.Models;

namespace LogicLayer.InterfacesRepository
{
    public interface IItemRepository
    {
        bool CreateItem(ItemDTO itemDTO);

        ItemDTO ReadItem(int id);
        List<ItemDTO> ReadItems(string name, int categoryId, int subCategoryId, decimal price, bool available);

        bool UpdateItem(ItemDTO itemDTO);

        bool DeleteItem(ItemDTO itemDTO);
    }
}
