using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IOrderRepository
	{
		bool CreateOrder(int clientId, OrderDTO orderDTO);

		OrderDTO ReadOrder(int clientId, int orderId);
		List<OrderDTO> ReadOrders(int clientId);

		bool UpdateOrder(OrderDTO orderDTO);

		bool DeleteOrder(OrderDTO orderDTO);
	}
}
