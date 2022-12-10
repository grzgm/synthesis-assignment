using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IOrderManager
	{
		bool CreateOrder(Order order);

		Order ReadOrder(string name, string password);

		bool UpdateOrder(Order order);

		bool DeleteOrder(Order order);
	}
}
