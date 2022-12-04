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
        public ItemCategory ReadItemCategory(string name, string password)
        {
            throw new NotImplementedException();
        }

        public (List<ItemCategory>, List<ItemCategory>) ReadAllItemCategories()
        {
            List<ItemCategoryDTO> categoriesDTO = itemCategoryRepository.ReadAllItemCategories();
            List<ItemCategoryDTO> subCategoriesDTO = itemCategoryRepository.ReadAllItemSubCategories();

            List<ItemCategory> categories = ConvertToModelParent(categoriesDTO);
            List<ItemCategory> subCategories = new List<ItemCategory>();

            foreach (ItemCategoryDTO subCategoryDTO in subCategoriesDTO)
            {
                subCategories.Add(new ItemCategory(subCategoryDTO, categories.Find(i => i.Id == subCategoryDTO.ParentId)));
            }

            return (categories, subCategories);
        }

        public bool DeleteItemCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItemCategory(ItemCategory itemCategory)
        {
            throw new NotImplementedException();
        }

        private List<ItemCategory> ConvertToModelParent(List<ItemCategoryDTO> itemCategoriesDTO)
        {
            List<ItemCategory> itemCategories = new List<ItemCategory>();
            foreach (ItemCategoryDTO itemCategoryDTO in itemCategoriesDTO)
            {
                itemCategories.Add(new ItemCategory(itemCategoryDTO));
            }
            return itemCategories;
        }

        private List<ItemCategory> ConvertToModelChild(List<ItemCategoryDTO> itemCategoriesDTO)
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
