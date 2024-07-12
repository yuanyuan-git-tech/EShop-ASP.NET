using ApplicationCore.Contracts.IRepository;
using ApplicationCore.Entities;
using ApplicationCore.RequestModel;
using Infrastructure.Common;
using Infrastructure.Contract.IRepository;
using Infrastructure.Contract.IService;

namespace Infrastructure.Implementation.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<int> DeleteAddress(int Id)
        {
            var result = await _addressRepository.DeleteAddress(Id);
            return result;
        }

        public async Task<AddressRequestModel> GetAddress(int Id)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            
            var result = await _addressRepository.GetAddress(Id);
            var addressViewModel = mapper.Map<AddressRequestModel>(result);
            return addressViewModel;
        }

        public async Task<int> SaveAddress(AddressRequestModel address)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var addressEntity = mapper.Map<Address>(address);
            var result = await _addressRepository.SaveAddress(addressEntity);
            return result;
        }

        public async Task<int> UpdateAddress(AddressRequestModel address)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var addressEntity = mapper.Map<Address>(address);
            var result = await _addressRepository.UpdateAddress(addressEntity);
            return result;
        }

        public async Task<IEnumerable<AddressRequestModel>> GetAddressByCustomerId(int customerId)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            List<AddressRequestModel> addressViewModels = new List<AddressRequestModel>();
            var result = await _addressRepository.GetAddressByCustomerId(customerId);
            foreach (var addressEntity in result)
            {
                var addressViewModel = mapper.Map<AddressRequestModel>(addressEntity);
                addressViewModels.Add(addressViewModel);
            }
            
            return addressViewModels;
        }
    }
}
