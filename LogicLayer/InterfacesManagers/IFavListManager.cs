using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IFavListManager
	{
		bool CreateFavListItem(int clientId, Item item);

		FavList ReadFavList(int clientId);

		bool UpdateFavListItem(Item item);

		bool DeleteFavListItem(Item item);
	}
}
