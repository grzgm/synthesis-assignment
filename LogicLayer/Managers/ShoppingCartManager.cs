using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class ShoppingCartManager: IShoppingCartManager
	{
		private readonly IShoppingCartRepository shoppingCartRepository;

		public ShoppingCartManager(IShoppingCartRepository shoppingCartRepository)
		{
			this.shoppingCartRepository = shoppingCartRepository
				?? throw new ArgumentNullException(nameof(shoppingCartRepository));
        }

        bool IShoppingCartManager.CreateShoppingCartItem(int clientId, LineItem lineItem)
        {
            try
            {
                return shoppingCartRepository.CreateShoppingCartItem(clientId, LineItemManager.ConvertToLineItemDTO(lineItem));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ShoppingCart IShoppingCartManager.ReadShoppingCart(int clientId)
		{
			try
			{
				return new ShoppingCart(shoppingCartRepository.ReadShoppingCart(clientId));
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		bool IShoppingCartManager.UpdateShoppingCartItem(LineItem lineItem)
        {
            try
            {
                return shoppingCartRepository.UpdateShoppingCartItem(LineItemManager.ConvertToLineItemDTO(lineItem));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		bool IShoppingCartManager.DeleteShoppingCart(LineItem lineItem)
		{
			try
			{
				return shoppingCartRepository.DeleteShoppingCart(LineItemManager.ConvertToLineItemDTO(lineItem));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static ShoppingCartDTO ConvertToShoppingCartDTO(ShoppingCart shoppingCart)
		{
			ShoppingCartDTO shoppingCartDTO = new ShoppingCartDTO();
			shoppingCartDTO.AddedItems = new List<LineItemDTO>();
			foreach (LineItem lineItem in shoppingCart.AddedItems)
			{
				shoppingCartDTO.AddedItems.Add(LineItemManager.ConvertToLineItemDTO(lineItem));
			};

			return shoppingCartDTO;
		}
	}
}
