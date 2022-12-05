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
            ItemDTO newItemDTO = ConvertToItemDTO(item);
            return itemRepository.CreateItem(newItemDTO);
        }

        public bool DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Item ReadItem()
        {
            throw new NotImplementedException();
        }

        public List<Item> ReadItems()
        {
            List<ItemDTO> itemsDTO = itemRepository.ReadItems();
            List<Item> items = new List<Item>();
            foreach (ItemDTO itemDTO in itemsDTO)
            {
                items.Add(new Item(itemDTO));
            }
            return items;
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        private ItemDTO ConvertToItemDTO(Item item)
        {
            ItemDTO itemDTO = new ItemDTO();
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
