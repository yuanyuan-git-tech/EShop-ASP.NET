using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;
using Infra.Common;

namespace Infra.Implementation.Services;

public class ShipperService: IShipperService
{
    private readonly IShipperRepository _shipperRepository;
    private readonly IMapper _mapper;
    
    public ShipperService(IShipperRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
        _mapper = MapperConfig.InitializeAutomapper();
    }

    public async Task<int> AddShipperAsync(ShipperRequestModel model)
    {
        Expression<Func<Shipper, bool>> filter = shipper => shipper.Email == model.Email;
        var existingShipper = await _shipperRepository.GetByConditionAsync(filter);
        if (existingShipper.Any())
        {
            throw new Exception("Email is already in use.");
        }
        var newShipperEntity = _mapper.Map<Shipper>(model);
        await _shipperRepository.AddAsync(newShipperEntity);
        return newShipperEntity.Id;
    }

    public async Task<int> UpdateShipperAsync(int id, ShipperRequestModel model)
    {
        var existingShipper = await _shipperRepository.GetByIdAsync(id);
        if (existingShipper == null)
        {
            throw new Exception("Shipper does not exist");
        }
        _mapper.Map(model, existingShipper);
        return await _shipperRepository.UpdateAsync(existingShipper);
    }

    public async Task<int> DeleteShipperAsync(int id)
    {
        return await _shipperRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ShipperResponseModel>> GetAllShippers()
    {
        var shippers = await _shipperRepository.GetAllAsync();
        var mapper = MapperConfig.InitializeAutomapper();
        return mapper.Map<IEnumerable<ShipperResponseModel>>(shippers);
    }

    public async Task<ShipperResponseModel> GetShipperByIdAsync(int id)
    {
        var shipper = await _shipperRepository.GetByIdAsync(id);
        return _mapper.Map<ShipperResponseModel>(shipper);
    }
    

    public Task<IEnumerable<ShipperResponseModel>> GetShipperByRegion(string region)
    {
        return null;
    }
}