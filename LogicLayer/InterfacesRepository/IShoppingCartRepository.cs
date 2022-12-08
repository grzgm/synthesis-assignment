using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IShoppingCartRepository
	{
		bool CreateShoppingCart(int clientId, LineItemDTO lineItemDTO);

		ShoppingCartDTO ReadShoppingCart(int id);

		bool UpdateShoppingCart(ShoppingCartDTO shoppingCartDTO);

		bool DeleteShoppingCart(ShoppingCartDTO shoppingCartDTO);
	}
}
