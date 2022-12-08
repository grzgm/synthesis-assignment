using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
	public class ShoppingCart
	{
		private List<LineItem> addedItems;

		public ShoppingCart()
		{
			addedItems = new List<LineItem>();
		}

		[JsonConstructor]
		public ShoppingCart(List<LineItem> addedItems)
		{
			this.addedItems = addedItems;
		}

		public bool IsEmpty()
		{
			throw new NotImplementedException();
		}

		public List<LineItem> AddedItems
		{
			get { return this.addedItems; }
			set { this.addedItems = value; }
		}
	}
}
