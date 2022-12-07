using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
	public class LineItem
	{
		private Item item;
		private decimal purchasePrice;
		private int amount;

		public decimal TotalPrice()
		{
			return amount * purchasePrice;
		}
	}
}
