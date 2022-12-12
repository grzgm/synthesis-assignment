using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
    public interface ILineItemRepository
    {
        bool CreateLineItem(LineItemDTO lineItemDTO);

        LineItemDTO ReadLineItemById(int id);

        List<LineItemDTO> ReadLineItems(LineItemDTO lineItemDTO, decimal purchasePrice, int amount);

        bool UpdateLineItem(LineItemDTO lineItemDTO);

        bool DeleteLineItem(LineItemDTO lineItemDTO);
    }
}
