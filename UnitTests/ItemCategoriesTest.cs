using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
	[TestClass]
	public class ItemCategoryTest
	{
		private IItemCategoryRepository itemCategoryRepository;
		private IItemCategoryManager itemCategoryManager;

		[TestMethod]
		public void ReadItemCategoryConvertionFromDTOToCategoryAndSubCategory()
		{
			// Arrange
			itemCategoryRepository = new FakeItemCategoryDB();
			itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);
			List<ItemCategory> itemCategories;
			List<ItemCategory> itemSubCategories;
			int assertCounter = 0;

			// Act
			itemCategories = itemCategoryManager.ReadAllItemCategories();

			// Assert
			if (itemCategories[0].Name == "category")
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[0].Name == "subCategory1")
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[1].Name == "subCategory2")
			{
				assertCounter++;
			}

			Assert.AreEqual(assertCounter, 3);

		}
	}
}
