using BusinessLayer.DTOs;
using BusinessLayer.Heplers;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IOrderService
    {
        Task<DataSourceResult<GetOrderDTO>> GetOrders(CustomListParam customListParam);
        Task AddOrder(AddOrderDTO dto, string userName);
    }
}
