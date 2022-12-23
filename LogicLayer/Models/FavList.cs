using LogicLayer.DTOs;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;

namespace LogicLayer.Models
{
	public class FavList
	{
		private HashSet<Item> addedItems;

		public FavList()
		{
			addedItems = new HashSet<Item>();
		}
		public FavList(HashSet<Item> addedItems)
		{
			this.addedItems = addedItems;
		}
		public FavList(FavListDTO favListDTO)
		{
			addedItems = new HashSet<Item>();
			foreach (ItemDTO itemDTO in favListDTO.AddedItems)
			{
				addedItems.Add(new Item(itemDTO));
			}
		}

		public bool IsEmpty()
		{
            return addedItems.Count <= 0;
        }
        public bool IsAddedItemNew(Item newItem)
        {
			return addedItems.Add(newItem);
        }

		public bool ClearNotAvailableItems()
		{
			bool Availability = true;
			foreach (Item item in addedItems)
			{
				if (item.StockAmount == 0 || item.Available == false)
				{
					Availability = false;
					addedItems.Remove(item);
				}
			}
			return Availability;
		}

		public HashSet<Item> AddedItems
        {
            get { return this.addedItems; }
            set { this.addedItems = value; }
        }
    }
}
