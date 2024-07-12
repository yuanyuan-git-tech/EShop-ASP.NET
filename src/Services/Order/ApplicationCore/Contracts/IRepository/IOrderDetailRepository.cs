using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<int> SaveOrderDetail(OrderDetails orderDetails);
        Task<int> DeleteOrderDetail(int id, int OrderId);
        Task<OrderDetails> GetOrderDetailById(int orderdetailId);
        Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderId(int OrderId, int pageNumber, int pageSize);
        Task<int> UpdateOrderDetail(OrderDetails orderDetails);
        Task<IEnumerable<OrderDetails>> GetOrderDetailByOrderId(int orderId);
    }
}
