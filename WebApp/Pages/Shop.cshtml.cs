using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class ShopModel : PageModel
    {
        IItemRepository itemRepository;
        IItemManager itemManager;
        IItemCategoryRepository itemCategoryRepository;
        IItemCategoryManager itemCategoryManager;

        public List<Item> items;
        public void OnGet()
        {
            itemRepository = new ItemRepository();
            itemManager = new ItemManager(itemRepository);
            itemCategoryRepository = new ItemCategoryRepository();
            itemCategoryManager = new ItemCategoryManager(itemCategoryRepository);

            items = itemManager.ReadItems("", null, null, 0, true);
        }
    }
}
