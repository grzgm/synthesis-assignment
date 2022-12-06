using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
    public interface IItemManager
    {
        bool CreateItem(Item item);

        Item ReadItem(int id, string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available);
        List<Item> ReadItems(string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available);

        bool UpdateItem(Item item);

        bool DeleteItem(Item item);
    }
}
