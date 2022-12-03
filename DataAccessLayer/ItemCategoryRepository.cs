using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LogicLayer.InterfacesRepository;
using LogicLayer.DTOs;
using System.Xml.Linq;

namespace DataAccessLayer
{
	public class ItemCategoryRepository : MainRepository, IItemCategoryRepository
	{
		public ItemCategoryRepository()
		{
			throw new NotImplementedException();
		}

        public bool CreateItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemCategoryDTO ReadItemCategory(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
