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
			(itemCategories, itemSubCategories) = itemCategoryManager.ReadAllItemCategories();

			// Assert
			foreach (ItemCategory itemSubCategory in itemSubCategories)
			{
				if(itemSubCategory.ParentCategory == itemCategories[0])
				assertCounter++;
			}
			Assert.AreEqual(assertCounter, 2);

		}
	}
}
