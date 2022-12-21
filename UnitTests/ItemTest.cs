
using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using UnitTests.FakeDBs;

namespace UnitTests
{
	[TestClass]
	public class ItemTest
	{
		IItemRepository itemRepository;
		IItemManager itemManager;

		[TestMethod]
		public void ReadItemTest()
		{
			// Arrange
			itemRepository = new FakeItemDB();
			itemManager = new ItemManager(itemRepository);
			ItemCategory itemCategory = new ItemCategory()
			{
				Id = 1,
				Name = "category",
				ParentCategory = null,
			};
			ItemCategory itemSubCategory = new ItemCategory()
			{
				Id = 2,
				Name = "subCategory1",
				ParentCategory = itemCategory,
			};
			Item item;
			bool check = true;

			// Act
			item = itemManager.ReadItem(1, "test", itemCategory, itemSubCategory, 10, true);

			// Assert
			if (item != null)
			{
				if (item.Id != 1)
					check = false;
				if (item.Name != "test")
					check = false;
				if (item.Category.Id != 1)
					check = false;
				if (item.SubCategory.Id != 2)
					check = false;
				if (item.Price != 10)
					check = false;
				if (item.Available != true)
					check = false;
			}
			else
				check = false;

			Assert.AreEqual(check, true);
		}

		[TestMethod]
		public void ReadItemThatDoesNotExistTest()
		{
			// Arrange
			itemRepository = new FakeItemDB();
			itemManager = new ItemManager(itemRepository);
			ItemCategory itemCategory = new ItemCategory()
			{
				Id = 1,
				Name = "category",
				ParentCategory = null,
			};
			ItemCategory itemSubCategory = new ItemCategory()
			{
				Id = 2,
				Name = "subCategory1",
				ParentCategory = itemCategory,
			};
			Item item;
			bool check = true;

			// Act
			item = itemManager.ReadItem(2, "bbb", itemCategory, itemSubCategory, 10, true);

			// Assert
			if (item != null)
			{
				if (item.Id != 1)
					check = false;
				if (item.Name != "test")
					check = false;
				if (item.Category.Id != 1)
					check = false;
				if (item.SubCategory.Id != 2)
					check = false;
				if (item.Price != 10)
					check = false;
				if (item.Available != true)
					check = false;
			}
			else
				check = false;

			Assert.AreEqual(check, false);
		}

		[TestMethod]
		public void ReadItemsAvailableWithTheSameNameTest()
		{
			// Arrange
			itemRepository = new FakeItemDB();
			itemManager = new ItemManager(itemRepository);
			List<Item> items;
			bool check = true;

			// Act
			items = itemManager.ReadItems("test", null, null, 0, true);

			// Assert
			if (items != null && items.Any())
			{
				if (items[0].Name != "test" || items[1].Name != "test")
					check = false;
			}
			else
				check = false;

			Assert.AreEqual(check, true);
		}

		[TestMethod]
		public void ReadItemsAvailableWithTheSameNameNoItemsTest()
		{
			// Arrange
			itemRepository = new FakeItemDB();
			itemManager = new ItemManager(itemRepository);
			List<Item> items;
			bool check = true;

			// Act
			items = itemManager.ReadItems("aa", null, null, 0, true);

			// Assert
			if (items != null && items.Any())
			{
				if (items[0].Name != "test" || items[1].Name != "test")
					check = false;
			}
			else
				check = false;

			Assert.AreEqual(check, false);
		}

		[TestMethod]
		public void ConvertToItemDTOWithoutDiscountsTest()
		{
			// Arrange
			itemRepository = new FakeItemDB();
			itemManager = new ItemManager(itemRepository);
			ItemDTO itemDTO;
			Item item = new Item()
			{
				Name = "test",
				Category = new ItemCategory()
				{
					Id = 1,
					Name = "category",
					ParentCategory = null,
				},
				SubCategory = new ItemCategory()
				{
					Id = 2,
					Name = "subCategory1",
					ParentCategory = new ItemCategory()
					{
						Id = 1,
						Name = "category",
						ParentCategory = null,
					},
				},
				Price = 10,
				Available = true,
				UnitType = "kg",
				StockAmount = 1000,
			};
			bool check = true;

			// Act
			itemDTO = ItemManager.ConvertToItemDTOWithoutDiscounts(item);

			// Assert
			if (itemDTO != null)
			{
				if (itemDTO.Name != "test")
					check = false;
				if (itemDTO.Category.Id != 1)
					check = false;
				if (itemDTO.SubCategory.Id != 2)
					check = false;
				if (itemDTO.Price != 10)
					check = false;
				if (itemDTO.Available != true)
					check = false;
			}
			else
				check = false;

			Assert.AreEqual(check, true);
		}
	}
}
