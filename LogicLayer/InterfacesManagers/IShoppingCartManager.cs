using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IShoppingCartManager
	{
		bool CreateShoppingCartItem(int clientId, LineItem lineItem);

		ShoppingCart ReadShoppingCart(int clientId);

		bool UpdateShoppingCartItem(LineItem lineItem);

		bool DeleteShoppingCart(LineItem lineItem);
	}
}
