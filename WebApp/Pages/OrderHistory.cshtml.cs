using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
	[Authorize]
	public class OrderHistoryModel : PageModel
	{
		IOrderRepository orderRepository;
		IOrderManager orderManager;

		public List<Order> orders;

		public void OnGet()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			orders = orderManager.ReadOrders(int.Parse(User.FindFirst("Id").Value));
		}
    }
}
