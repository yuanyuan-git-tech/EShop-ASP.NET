using ApplicationCore.Contracts.IRepository;
using ApplicationCore.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Implmentation.Repository
{
    public class AddressRepository : IAddressRepository, IBaseRepository<Address>
    {
        private readonly OrderDbContext _dbContext;
        public AddressRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> DeleteAddress(int Id)
        {
            var entity = await _dbContext.Address.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return 0;
            }

            _dbContext.Address.Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Address> GetAddress(int Id)
        {
            var entity = await _dbContext.Address.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<Address>> GetAddressByCustomerId(int customerId)
        {
            var entity = await _dbContext.Address.Where(x => x.CustomerId == customerId).ToListAsync();
            return entity;
        }

        public async Task<int> SaveAddress(Address address)
        {
            await _dbContext.Address.AddAsync(address);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateAddress(Address address)
        {
             _dbContext.Address.Update(address);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
