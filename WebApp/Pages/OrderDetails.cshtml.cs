using LogicLayer.Models;
using LogicLayer.InterfacesRepository;
using LogicLayer.InterfacesManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages
{
	[Authorize]
	public class OrderDetailsModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public int OrderId { get; set; }

		IOrderRepository orderRepository;
		IOrderManager orderManager;

		public Order order;

		public IActionResult OnGet()
		{
			orderRepository = new OrderRepository();
			orderManager = new OrderManager(orderRepository);

			order = orderManager.ReadOrderByClientIdOrderId(int.Parse(User.FindFirst("Id").Value), OrderId);

			if (order == null)
				return RedirectToPage("/Index");

			return Page();
		}
	}
}
