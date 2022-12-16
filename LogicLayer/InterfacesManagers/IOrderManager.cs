using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IOrderManager
	{
		bool CreateOrder(Order order);

		Order ReadOrderByClientIdOrderId(int clientId, int orderId);
		List<Order> ReadOrdersByClientId(int clientId);

		bool UpdateOrder(Order order);

		bool DeleteOrder(Order order);
	}
}
