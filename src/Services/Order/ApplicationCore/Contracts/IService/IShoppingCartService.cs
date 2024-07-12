using ApplicationCore.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RequestModel;

namespace Infrastructure.Contract.IService
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartRequestModel> GetShoppingCartByCustomerId (int Id, Guid customerId);
        Task<int> SaveShoppingCart (ShoppingCartRequestModel shoppingCart);
        Task<int> DeleteShoppingCart(int Id, Guid customerId);
        Task<ShoppingCartRequestModel> GetShoppingCartByCustomerId(Guid customerId);
    }
}
