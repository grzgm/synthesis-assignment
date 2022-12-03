using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
    public class ItemManager : IItemManager
    {
        private IItemRepository itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            throw new NotImplementedException();
        }

        public Item CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Item ReadItem(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
