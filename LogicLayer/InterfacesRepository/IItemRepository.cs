using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
    public interface IItemRepository
    {
        bool CreateItem(ItemDTO itemDTO);

        ItemDTO ReadItem(string name, string password);

        bool UpdateItem(ItemDTO itemDTO);

        bool DeleteItem(int Id);
    }
}
