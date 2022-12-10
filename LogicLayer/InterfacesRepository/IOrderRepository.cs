using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
	public interface IOrderRepository
	{
		bool CreateOrder(OrderDTO orderDTO);

		OrderDTO ReadOrder(string name, string password);

		bool UpdateOrder(OrderDTO orderDTO);

		bool DeleteOrder(OrderDTO orderDTO);
	}
}
