using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class OrderManager : IOrderManager
	{
		private readonly IOrderRepository orderRepository;

		public OrderManager(IOrderRepository orderRepository)
		{
			this.orderRepository = orderRepository
				?? throw new ArgumentNullException(nameof(orderRepository));
		}

		bool IOrderManager.CreateOrder(Order order)
		{
			throw new NotImplementedException();
		}

		Order IOrderManager.ReadOrder(int clientId, int orderId)
		{
			try
			{
				return new Order(orderRepository.ReadOrder(clientId, orderId));
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		List<Order> IOrderManager.ReadOrders(int clientId)
		{
			try
			{
				List<Order> orders = new List<Order>();
				List<OrderDTO> ordersDTO = orderRepository.ReadOrders(clientId);
				foreach (OrderDTO orderDTO in ordersDTO)
				{
					orders.Add(new Order(orderDTO));
				}
				return orders;
			}
			catch (Exception ex)
			{
				return new List<Order>();
			}
		}

		bool IOrderManager.UpdateOrder(Order order)
		{
			throw new NotImplementedException();
		}

		bool IOrderManager.DeleteOrder(Order order)
		{
			throw new NotImplementedException();
		}
	}
}
