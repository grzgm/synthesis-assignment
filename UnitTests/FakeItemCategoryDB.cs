using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	internal class FakeItemCategoryDB : IItemCategoryRepository
	{
		bool IItemCategoryRepository.CreateItemCategory(ItemCategoryDTO itemCategoryDTO)
		{
			throw new NotImplementedException();
		}

		List<ItemCategoryDTO> IItemCategoryRepository.ReadAllItemCategories()
		{
			return new List<ItemCategoryDTO> { 
				new ItemCategoryDTO() {
					Id = 1,
					Name = "category",
					ParentId = null,
					SubCategories = new List<ItemCategoryDTO>() {
						new ItemCategoryDTO() { Id = 2, Name = "subCategory1", ParentId = 1 },
						new ItemCategoryDTO() { Id = 3, Name = "subCategory2", ParentId = 1 },}
				}
			};
		}
		bool IItemCategoryRepository.UpdateItemCategory(ItemCategoryDTO itemCategoryDTO)
		{
			throw new NotImplementedException();
		}

		bool IItemCategoryRepository.DeleteItemCategory(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
