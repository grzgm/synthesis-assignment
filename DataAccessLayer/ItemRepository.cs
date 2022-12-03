using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;
using LogicLayer.DTOs;

namespace DataAccessLayer
{
	public class ItemRepository : MainRepository, IItemRepository
	{
		public ItemRepository()
		{
			throw new NotImplementedException();
		}

        public ItemDTO CreateItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemDTO ReadItem(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
