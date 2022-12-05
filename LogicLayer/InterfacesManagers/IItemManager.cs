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

        Item ReadItem();
        List<Item> ReadItems();

        bool UpdateItem(Item item);

        bool DeleteItem(int Id);
    }
}
