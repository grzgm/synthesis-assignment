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

		bool IShoppingCartManager.CreateShoppingCart(int clientId, LineItem lineItem)
		{
			try
			{
				return shoppingCartRepository.CreateShoppingCart(clientId, LineItemManager.ConvertToLineItemDTO(lineItem));
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

		bool IShoppingCartManager.UpdateShoppingCart(ShoppingCart shoppingCart)
		{
			throw new NotImplementedException();
		}

		bool IShoppingCartManager.DeleteShoppingCart(ShoppingCart shoppingCart)
		{
			throw new NotImplementedException();
		}

		private ShoppingCartDTO ConvertToShoppingCartDTO(ShoppingCart shoppingCart)
		{
			throw new System.NotImplementedException();
		}
	}
}
