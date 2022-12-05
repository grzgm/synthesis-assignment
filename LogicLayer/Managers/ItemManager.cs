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
            return itemRepository.CreateItem(ConvertToItemDTO(item));
        }

        public Item ReadItem(int id, string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available)
        {
            ItemDTO itemDTO;
            // There is no need to search with name, email, password in database, cuz id is Unique
            try
            {
                itemDTO = itemRepository.ReadItem(id);
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

            if(available)
            {
                if (itemDTO.Available != available)
                    return null;
            }

            return new Item(itemDTO);
        }

        public List<Item> ReadItems(string name, ItemCategory category, ItemCategory subCategory, decimal price, bool available)
        {
            List<ItemDTO> itemsDTO;
            if (category != null && subCategory != null)
            {
                itemsDTO = itemRepository.ReadItems(name, category.Id, subCategory.Id, price, available);
            }
            else if (category == null && subCategory != null)
            {
                itemsDTO = itemRepository.ReadItems(name, 0, subCategory.Id, price, available);
            }
            else if (category != null && subCategory == null)
            {
                itemsDTO = itemRepository.ReadItems(name, category.Id, 0, price, available);
            }
            else
            {
                itemsDTO = itemRepository.ReadItems(name, 0, 0, price, available);
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
            return itemRepository.UpdateItem(ConvertToItemDTO(item));
        }

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        private ItemDTO ConvertToItemDTO(Item item)
        {
            ItemDTO itemDTO = new ItemDTO();
            itemDTO.Id = item.Id;
            itemDTO.Name = item.Name;
            itemDTO.Category = new ItemCategoryDTO { Id = item.Category.Id, Name = item.Category.Name, ParentId = null };
            itemDTO.SubCategory = new ItemCategoryDTO { Id = item.SubCategory.Id, Name = item.SubCategory.Name, ParentId = item.SubCategory.ParentCategory.Id }; ;
            itemDTO.Price = item.Price;
            itemDTO.Available = item.Available;
            itemDTO.UnitType = item.UnitType;
            return itemDTO;
        }
    }
}
