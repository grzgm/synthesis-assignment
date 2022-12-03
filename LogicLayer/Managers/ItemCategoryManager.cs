using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
	public class ItemCategoryManager : IItemCategoryManager
	{
		private readonly IItemCategoryRepository ItemCategoryRepository;

		public ItemCategoryManager(IItemCategoryRepository itemCategoryRepository)
		{
			throw new NotImplementedException();
		}

        public bool CreateItemCategory(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemCategory ReadItemCategory(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemCategory(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }
    }
}
