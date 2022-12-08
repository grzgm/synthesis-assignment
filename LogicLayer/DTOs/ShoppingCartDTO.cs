using LogicLayer.Models;

namespace LogicLayer.DTOs
{
	public class ShoppingCartDTO
	{
		public List<LineItemDTO> AddedItems
		{
			get;
			set;
		}
	}
}
