using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using UnitTests.FakeDBs;

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
			int assertCounter = 0;

			// Act
			itemCategories = itemCategoryManager.ReadAllItemCategories();

			// Assert
			if (itemCategories[0].Name == "category" && itemCategories[0].Id == 1)
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[0].Name == "subCategory1" && itemCategories[0].SubCategories[0].Id == 2)
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[1].Name == "subCategory2" && itemCategories[0].SubCategories[1].Id == 3)
			{
				assertCounter++;
			}

			Assert.AreEqual(assertCounter, 3);

		}
		[TestMethod]
		public void ConvertToModelTest()
		{
			// Arrange
			itemCategoryRepository = new FakeItemCategoryDB();
			itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);
			List<ItemCategory> itemCategories;
			List<ItemCategoryDTO> itemCategoriesDTO = new List<ItemCategoryDTO> {
				new ItemCategoryDTO() {
					Id = 1,
					Name = "category",
					ParentId = null,
					SubCategories = new List<ItemCategoryDTO>() {
						new ItemCategoryDTO() { Id = 2, Name = "subCategory1", ParentId = 1 },
						new ItemCategoryDTO() { Id = 3, Name = "subCategory2", ParentId = 1 },}
				}
			};

			int assertCounter = 0;

			// Act
			itemCategories = ItemCategoryManager.ConvertToModel(itemCategoriesDTO);

			// Assert
			if (itemCategories[0].Name == "category" && itemCategories[0].Id == 1)
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[0].Name == "subCategory1" && itemCategories[0].SubCategories[0].Id == 2)
			{
				assertCounter++;
			}
			if (itemCategories[0].SubCategories[1].Name == "subCategory2" && itemCategories[0].SubCategories[1].Id == 3)
			{
				assertCounter++;
			}

			Assert.AreEqual(assertCounter, 3);
		}
	}
}
