using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class FavListManager: IFavListManager
	{
		private readonly IFavListRepository favListRepository;

		public FavListManager(IFavListRepository favListRepository)
		{
			this.favListRepository = favListRepository
				?? throw new ArgumentNullException(nameof(favListRepository));
        }

        bool IFavListManager.CreateFavListItem(int clientId, Item item)
        {
            try
            {
                return favListRepository.CreateFavListItem(clientId, ItemManager.ConvertToItemDTOWithoutDiscounts(item));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        FavList IFavListManager.ReadFavList(int clientId)
		{
			try
			{
				return new FavList(favListRepository.ReadFavList(clientId));
			}
			catch (Exception ex)
			{
				return new FavList();
			}
		}

		bool IFavListManager.UpdateFavListItem(Item item)
        {
            try
            {
                return favListRepository.UpdateFavListItem(ItemManager.ConvertToItemDTOWithoutDiscounts(item));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		bool IFavListManager.DeleteFavListItem(Item item)
		{
			try
			{
				return favListRepository.DeleteFavListItem(ItemManager.ConvertToItemDTOWithoutDiscounts(item));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static FavListDTO ConvertToFavListDTO(FavList favList)
		{
			FavListDTO favListDTO = new FavListDTO();
			favListDTO.AddedItems = new HashSet<ItemDTO>();
			foreach (Item item in favList.AddedItems)
			{
				favListDTO.AddedItems.Add(ItemManager.ConvertToItemDTOWithoutDiscounts(item));
			};

			return favListDTO;
		}
	}
}
