using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DTOs;

namespace LogicLayer.InterfacesRepository
{
    public interface IItemRepository
    {
        ItemDTO CreateItem(ItemDTO itemDTO);

        ItemDTO ReadItem(string name, string password);

        bool UpdateItem(ItemDTO itemDTO);

        bool DeleteItem(int Id);
    }
}
