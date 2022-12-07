using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
    public interface ILineItemManager
    {
        bool CreateLineItem(LineItem lineItem);

        LineItem ReadLineItem(int id, Item lineItem, decimal purchasePrice, int amount);

        List<LineItem> ReadLineItems(Item lineItem, decimal purchasePrice, int amount);

        bool UpdateLineItem(LineItem lineItem);

        bool DeleteLineItem(LineItem lineItem);
    }
}
