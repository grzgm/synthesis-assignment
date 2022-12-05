using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
    public interface IItemRepository
    {
        bool CreateItem(ItemDTO itemDTO);

        ItemDTO ReadItem();
        List<ItemDTO> ReadItems();

        bool UpdateItem(ItemDTO itemDTO);

        bool DeleteItem(int Id);
    }
}
