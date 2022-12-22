using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
    public class LineItemManager
    {
		public static LineItemDTO ConvertToLineItemDTO(LineItem lineItem)
		{
			LineItemDTO lineItemDTO = new LineItemDTO()
			{
				Id = lineItem.Id,
				ItemDTO = ItemManager.ConvertToItemDTOWithoutDiscounts(lineItem.Item),
				PurchasePrice = lineItem.PurchasePrice,
				Amount = lineItem.Amount,
			};
			return lineItemDTO;
		}
	}
}
