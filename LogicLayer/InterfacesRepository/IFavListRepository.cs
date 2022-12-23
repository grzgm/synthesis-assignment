using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IFavListRepository
	{
		bool CreateFavListItem(int clientId, ItemDTO itemDTO);

		FavListDTO ReadFavList(int clientId);

		bool UpdateFavListItem(ItemDTO itemDTO);

        bool DeleteFavListItem(ItemDTO itemDTO);
	}
}
