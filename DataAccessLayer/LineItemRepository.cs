using LogicLayer.DTOs;
using LogicLayer.InterfacesRepository;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class LineItemRepository : ILineItemRepository
    {
        private IEnumerable<LineItemDTO> GetLineItems(string Query, List<SqlParameter>? sqlParameters)
        {
            throw new NotImplementedException();
        }
        bool ILineItemRepository.CreateLineItem(LineItemDTO lineItemDTO)
        {
            throw new NotImplementedException();
        }

        LineItemDTO ILineItemRepository.ReadLineItemById(int id)
        {
            throw new NotImplementedException();
        }

        List<LineItemDTO> ILineItemRepository.ReadLineItems(LineItemDTO lineItemDTO, decimal purchasePrice, int amount)
        {
            throw new NotImplementedException();
        }

        bool ILineItemRepository.UpdateLineItem(LineItemDTO lineItemDTO)
        {
            throw new NotImplementedException();
        }

        bool ILineItemRepository.DeleteLineItem(LineItemDTO lineItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
