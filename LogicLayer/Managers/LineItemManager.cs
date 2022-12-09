using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
    public class LineItemManager : ILineItemManager
    {
        private readonly ILineItemRepository lineItemRepository;

        public LineItemManager(ILineItemRepository lineItemRepository)
        {
            this.lineItemRepository = lineItemRepository
                ?? throw new ArgumentNullException(nameof(lineItemRepository));
        }

        bool ILineItemManager.CreateLineItem(LineItem lineItem)
        {
            try
            {
                return lineItemRepository.CreateLineItem(ConvertToLineItemDTO(lineItem));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        LineItem ILineItemManager.ReadLineItem(int id, Item lineItem, decimal purchasePrice, int amount)
        {
            throw new NotImplementedException();
        }

        List<LineItem> ILineItemManager.ReadLineItems(Item lineItem, decimal purchasePrice, int amount)
        {
            throw new NotImplementedException();
        }

        bool ILineItemManager.UpdateLineItem(LineItem lineItem)
        {
            try
            {
                return lineItemRepository.UpdateLineItem(ConvertToLineItemDTO(lineItem));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool ILineItemManager.DeleteLineItem(LineItem lineItem)
        {
            try
            {
                return lineItemRepository.DeleteLineItem(ConvertToLineItemDTO(lineItem));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		public static LineItemDTO ConvertToLineItemDTO(LineItem lineItem)
        {
            LineItemDTO lineItemDTO = new LineItemDTO()
            {
                Id = lineItem.Id,
                ItemDTO = ItemManager.ConvertToItemDTO(lineItem.Item),
                PurchasePrice = lineItem.PurchasePrice,
                Amount = lineItem.Amount,
            };
            return lineItemDTO;
        }
    }
}
