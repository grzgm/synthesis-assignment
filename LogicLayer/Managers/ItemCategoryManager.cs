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
		private readonly IItemCategoryRepository itemCategoryRepository;

		public ItemCategoryManager(IItemCategoryRepository itemCategoryRepository)
		{
            this.itemCategoryRepository = itemCategoryRepository
                ?? throw new ArgumentNullException(nameof(itemCategoryRepository));
        }

        public bool CreateItemCategory(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }

        public List<ItemCategory> ReadAllItemCategories()
        {
            try
			{
				return ConvertToModel(itemCategoryRepository.ReadAllItemCategories());
			}
            catch (Exception ex) {
                return new List<ItemCategory>();
            }
        }

        public bool DeleteItemCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemCategory(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }

        private List<ItemCategory> ConvertToModel(List<ItemCategoryDTO> itemCategoriesDTO)
        {
            List<ItemCategory> itemCategories = new List<ItemCategory>();
            foreach (ItemCategoryDTO itemCategoryDTO in itemCategoriesDTO)
			{
				List<ItemCategory> itemSubCategories = new List<ItemCategory>();
                itemSubCategories = ConvertToModelChildren(itemCategoryDTO.SubCategories);
				itemCategories.Add(new ItemCategory(itemCategoryDTO, itemSubCategories));
            }
            return itemCategories;
        }

        private List<ItemCategory> ConvertToModelChildren(List<ItemCategoryDTO> itemCategoriesDTO)
        {
            List<ItemCategory> itemCategories = new List<ItemCategory>();
            foreach (ItemCategoryDTO itemCategoryDTO in itemCategoriesDTO)
            {
                itemCategories.Add(new ItemCategory(itemCategoryDTO));
            }
            return itemCategories;
        }
    }
}
