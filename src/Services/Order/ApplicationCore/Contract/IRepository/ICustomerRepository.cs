using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract.IRepository
{
    public interface ICustomerRepository
    {
        Task<int> SaveCustomer(Customer entity);
        Task<int> UpdateCustomer(Customer entity);
        Task<int> DeleteCustomer(Guid customerId);
        Task<Customer> GetCustomerById(Guid customerId);
    }
}
