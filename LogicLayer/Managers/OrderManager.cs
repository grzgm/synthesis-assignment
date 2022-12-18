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
			try
			{
				return orderRepository.CreateOrder(ConvertToOrderDTO(order));
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		Order IOrderManager.ReadOrderByClientIdOrderId(int clientId, int orderId)
		{
			try
			{
				return new Order(orderRepository.ReadOrderByClientIdOrderId(clientId, orderId));
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		List<Order> IOrderManager.ReadOrdersByClientId(int clientId)
		{
			try
			{
				List<Order> orders = new List<Order>();
				List<OrderDTO> ordersDTO = orderRepository.ReadOrdersByClientId(clientId);
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

		public static OrderDTO ConvertToOrderDTO(Order order)
		{
			OrderDTO orderDTO = new OrderDTO()
			{
				Id = order.Id,
				clientDTO = ClientManager.ConvertToClientDTO(order.Client),
				OrderBonusPoints = order.OrderBonusPoints,
				OrderSpentBonusPoints = order.OrderSpentBonusPoints,
				OrderDate = order.OrderDate,
				DeliveryDate = order.DeliveryDate,
				OrderStatus = (int)order.OrderStatus,
			};
			orderDTO.PurchasedItems = new List<LineItemDTO>();
			orderDTO.AddressDTO = new AddressDTO()
			{
				Country = order.Address.Country,
				City = order.Address.City,
				Street = order.Address.Street,
				PostalCode = order.Address.PostalCode,
			};

			foreach (LineItem lineItem in order.PurchasedItems)
			{
				orderDTO.PurchasedItems.Add(LineItemManager.ConvertToLineItemDTO(lineItem));
			};

			return orderDTO;
		}
	}
}
