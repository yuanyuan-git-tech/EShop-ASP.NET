using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infra.Data;

namespace Infra.Implementation.Repositories;

public class ShipperRepository: BaseRepository<Shipper>, IShipperRepository
{
    private IShipperRepository _shipperRepositoryImplementation;

    public ShipperRepository(ShippingDbContext context) : base(context)
    {
        
    }
}