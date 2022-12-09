using LogicLayer.Models;

namespace LogicLayer.DTOs
{
    public class LineItemDTO
    {
        public int Id
        {
            get;
            set;
        }
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
