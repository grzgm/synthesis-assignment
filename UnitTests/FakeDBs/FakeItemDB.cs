using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.FakeDBs
{
	internal class FakeItemDB : IItemRepository
	{
		bool IItemRepository.CreateItem(ItemDTO itemDTO)
		{
			throw new NotImplementedException();
		}

		bool IItemRepository.DeleteItem(ItemDTO itemDTO)
		{
			throw new NotImplementedException();
		}

		List<ItemDTO> IItemRepository.ReadAvailableItems()
		{
			throw new NotImplementedException();
		}

		ItemDTO IItemRepository.ReadItemById(int id)
		{
			if (id == 1)
			{
				return new ItemDTO()
				{
					Id = 1,
					Name = "test",
					Category =
					new ItemCategoryDTO()
					{
						Id = 1,
						Name = "category",
						ParentId = null,
					},
					SubCategory = new ItemCategoryDTO()
					{
						Id = 2,
						Name = "subCategory1",
						ParentId = 1
					},
					Price = 10,
					Available = true,
					UnitType = "kg",
					StockAmount = 1000,
					Discounts = new List<DiscountDTO>(),
				};
			}
			else
				throw new Exception();
		}

		List<ItemDTO> IItemRepository.ReadItems(string name, int categoryId, int subCategoryId, decimal price, bool available)
		{
			if(name == "test")
			{
				return new List<ItemDTO>()
			{
				new ItemDTO()
				{
					Id = 1,
					Name = "test",
					Category =
					new ItemCategoryDTO()
					{
						Id = 1,
						Name = "category",
						ParentId = null,
					},
					SubCategory = new ItemCategoryDTO()
					{
						Id = 2,
						Name = "subCategory1",
						ParentId = 1
					},
					Price = 10,
					Available = true,
					UnitType = "kg",
					StockAmount = 1000,
					Discounts = new List<DiscountDTO>(),
					},
				new ItemDTO()
				{
					Id = 2,
					Name = "test",
					Category =
					new ItemCategoryDTO()
					{
						Id = 1,
						Name = "category",
						ParentId = null,
					},
					SubCategory = new ItemCategoryDTO()
					{
						Id = 2,
						Name = "subCategory1",
						ParentId = 1
					},
					Price = 10,
					Available = true,
					UnitType = "kg",
					StockAmount = 1000,
					Discounts = new List<DiscountDTO>(),
					},
			};
			}
			else
			{
				return new List<ItemDTO>();
			}
		}

		bool IItemRepository.UpdateItem(ItemDTO itemDTO)
		{
			throw new NotImplementedException();
		}
	}
}
