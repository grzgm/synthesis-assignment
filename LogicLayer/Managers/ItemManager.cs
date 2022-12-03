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

        public Item ReadItem(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        private ItemDTO ConvertToItemDTO(Item item)
        {
            ItemDTO itemDTO = new ItemDTO();
            itemDTO.Name = item.Name;
            //itemDTO.Category= item.Category;
            //itemDTO.SubCategory= item.SubCategory;
            itemDTO.Category= new ItemCategoryDTO { Id = 1, Name = "Fruit" };
            itemDTO.SubCategory = new ItemCategoryDTO{ Id = 3, Name = "Fruit", ParentCategory = new ItemCategoryDTO { Id = 1, Name = "Fruit" } };
            itemDTO.Price= item.Price;
            itemDTO.Available= item.Available;
            itemDTO.UnitType= item.UnitType;
            return itemDTO;
        }
    }
}
