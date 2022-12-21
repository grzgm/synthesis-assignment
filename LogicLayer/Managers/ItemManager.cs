using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Models;

namespace LogicLayer.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository
                ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public bool CreateItem(Item item)
        {
            try
            {
                return itemRepository.CreateItem(ConvertToItemDTOWithoutDiscounts(item));
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Item ReadItem(int id, string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available)
        {
            ItemDTO itemDTO;
            // There is no need to search with name, email, password in database, cuz id is Unique
            try
            {
                itemDTO = itemRepository.ReadItemById(id);
            }
            catch (Exception ex)
            {
                return null;
            }

            if (name != "")
            {
                if (itemDTO.Name != name)
                    return null;
            }

            if (category != null)
            {
                if (itemDTO.Category.Name != category.Name)
                    return null;
            }

            if (subCategory != null)
            {
                if (itemDTO.SubCategory.Name != subCategory.Name)
                    return null;
            }

            if (price > 0)
            {
                if (itemDTO.Price != price)
                    return null;
            }

            if (itemDTO.Available != available)
                return null;

            return new Item(itemDTO);
        }

        public List<Item> ReadItems(string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available)
        {
            List<ItemDTO> itemsDTO;
            try
            {
                if (category != null && subCategory != null)
                {
                    itemsDTO = itemRepository.ReadItems(name, category.Id, subCategory.Id, price, available);
                }
                else if (category == null && subCategory == null)
                {
                    itemsDTO = itemRepository.ReadItems(name, 0, 0, price, available);
                }
                else if (category != null && subCategory == null)
                {
                    itemsDTO = itemRepository.ReadItems(name, category.Id, 0, price, available);
                }
                else
                {
                    itemsDTO = itemRepository.ReadItems(name, 0, subCategory.Id, price, available);
                }
            }
            catch(Exception ex)
            {
                return new List<Item>();
            }
            List<Item> items = new List<Item>();
            foreach (ItemDTO itemDTO in itemsDTO)
            {
                items.Add(new Item(itemDTO));
            }
            return items;
        }

        public List<Item> ReadAvailableItems()
        {
            List<ItemDTO> itemsDTO;
            try
            {
                itemsDTO = itemRepository.ReadAvailableItems();
            }
            catch(Exception ex)
            {
                return new List<Item>();
            }
            List<Item> items = new List<Item>();
            foreach (ItemDTO itemDTO in itemsDTO)
            {
                items.Add(new Item(itemDTO));
            }
            return items;
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                return itemRepository.UpdateItem(ConvertToItemDTOWithoutDiscounts(item));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteItem(Item item)
        {
            try
            {
                return itemRepository.DeleteItem(ConvertToItemDTOWithoutDiscounts(item));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ItemDTO ConvertToItemDTOWithoutDiscounts(Item item)
        {
            ItemDTO itemDTO = new ItemDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Category = new ItemCategoryDTO { Id = item.Category.Id, Name = item.Category.Name, ParentId = null },
                SubCategory = new ItemCategoryDTO { Id = item.SubCategory.Id, Name = item.SubCategory.Name, ParentId = item.Category.Id },
                Price = item.Price,
                Available = item.Available,
                UnitType = item.UnitType,
                StockAmount = item.StockAmount,
            };
            return itemDTO;
        }
    }
}
