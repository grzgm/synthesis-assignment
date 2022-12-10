using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IOrderManager
	{
		bool CreateOrder(int clientId, ShoppingCart shoppingCart, Order order);

		Order ReadOrder(int clientId, int orderId);
		List<Order> ReadOrders(int clientId);

		bool UpdateOrder(Order order);

		bool DeleteOrder(Order order);
	}
}
