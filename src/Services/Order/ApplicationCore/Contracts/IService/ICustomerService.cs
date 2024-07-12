using ApplicationCore.RequestModel;

namespace Infrastructure.Contract.IService;

public interface ICustomerService
{
    Task<int> SaveCustomer(CustomerRequestModel entity);
    Task<int> UpdateCustomer(CustomerRequestModel entity);
    Task<int> DeleteCustomer(Guid customerId);
    Task<CustomerRequestModel> GetCustomerById(Guid customerId);
}