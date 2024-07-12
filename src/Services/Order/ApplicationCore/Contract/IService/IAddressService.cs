using ApplicationCore.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RequestModel;

namespace Infrastructure.Contract.IService
{
    public interface IAddressService
    {
        Task<int> SaveAddress(AddressRequestModel address);
        Task<int> UpdateAddress(AddressRequestModel address);
        Task<int> DeleteAddress(int Id);
        Task<AddressRequestModel> GetAddress(int Id);
        Task<IEnumerable<AddressRequestModel>> GetAddressByCustomerId(int customerId);
    }
}
