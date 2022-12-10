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

		Order IOrderManager.ReadOrder(string name, string password)
		{
			throw new NotImplementedException();
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
