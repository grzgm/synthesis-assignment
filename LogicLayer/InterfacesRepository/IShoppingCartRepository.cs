using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IShoppingCartRepository
	{
		bool CreateShoppingCartItem(int clientId, LineItemDTO lineItemDTO);
		bool CreateShoppingCartItems(int clientId, List<LineItemDTO> lineItemsDTO);

		ShoppingCartDTO ReadShoppingCart(int clientId);

		bool UpdateShoppingCartItem(LineItemDTO lineItemDTO);
		bool UpdateShoppingCartItems(List<LineItemDTO> lineItemsDTO);

        bool DeleteShoppingCart(LineItemDTO lineItemDTO);
	}
}
