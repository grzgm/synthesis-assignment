using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
    public interface IItemRepository
    {
        bool CreateItem(ItemDTO itemDTO);

        ItemDTO ReadItem(int id);
        List<ItemDTO> ReadItems();

        bool UpdateItem(ItemDTO itemDTO);

        bool DeleteItem(int Id);
    }
}
