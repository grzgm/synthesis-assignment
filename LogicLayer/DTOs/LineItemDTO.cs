using LogicLayer.Models;

namespace LogicLayer.DTOs
{
    public class LineItemDTO
    {
        public ItemDTO ItemDTO
        {
            get;
            set;
        }

        public decimal PurchasePrice
        {
            get;
            set;
        }
        public int Amount
        {
            get;
            set;
        }
    }
}
