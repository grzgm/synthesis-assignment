using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace LogicLayer.InterfacesManagers
{
	public interface IItemCategoryManager
	{
		bool CreateItemCategory(ItemCategory itemCategory);

		ItemCategory ReadItemCategory(string name, string password);
        (List<ItemCategory>, List<ItemCategory>) ReadAllItemCategories();

        bool UpdateItemCategory(ItemCategory itemCategory);

		bool DeleteItemCategory(int Id);
	}
}
