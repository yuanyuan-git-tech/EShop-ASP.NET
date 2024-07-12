using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract.IRepository
{
    public interface IOrderRepository
    {
        Task<int> SaveOrder(Order order);
        Task<int> TotalOrders();
        Task<int> TotalCustomerOrders(Guid customerId);
        Task<int> DeleteOrder(int orderId);
        Task<Order> GetOrderById(int orderId);
        Task<int> UpdateOrder(Order order);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId, int pageNumber, int pageSize);
        Task<Order> GetOrderByCustomerId(int orderId, Guid customerId);
        Task<IEnumerable<Order>> GetAll(int pageNumber, int pageSize);
        Task<Order> GetOrderBillByCustomerId(decimal billAmout, Guid customerId);
    }
}
