using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IShoppingCartManager
	{
		bool CreateShoppingCart(int clientId, LineItem lineItem);

		ShoppingCart ReadShoppingCart(int clientId);

		bool UpdateShoppingCart(ShoppingCart shoppingCart);

		bool DeleteShoppingCart(ShoppingCart shoppingCart);
	}
}
