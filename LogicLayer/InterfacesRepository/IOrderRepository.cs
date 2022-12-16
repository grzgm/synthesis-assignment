using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IOrderRepository
	{
		bool CreateOrder(OrderDTO orderDTO);

		OrderDTO ReadOrderByClientIdOrderId(int clientId, int orderId);
		List<OrderDTO> ReadOrdersByClientId(int clientId);

		bool UpdateOrder(OrderDTO orderDTO);

		bool DeleteOrder(OrderDTO orderDTO);
	}
}
