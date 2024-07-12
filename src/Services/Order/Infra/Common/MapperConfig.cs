using ApplicationCore.Entities;
using ApplicationCore.RequestModel;
using AutoMapper;

namespace Infrastructure.Common
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            // Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderRequestModel>();
                cfg.CreateMap<OrderDetails, OrderDetailRequestModel>();
                cfg.CreateMap<Customer, CustomerRequestModel>();
                cfg.CreateMap<Address, AddressRequestModel>();
                cfg.CreateMap<ShoppingCart, ShoppingCartRequestModel>();
                cfg.CreateMap<ShoppingCartItem, ShoppingCartItemRequestModel>();
                cfg.CreateMap<PaymentMethod, PaymentMethodRequestModel>();

                //// Reverse Mapping
                cfg.CreateMap<OrderRequestModel, Order>();
                cfg.CreateMap<OrderDetailRequestModel, OrderDetails>();
                cfg.CreateMap<CustomerRequestModel, Customer>();
                cfg.CreateMap<AddressRequestModel, Address>();
                cfg.CreateMap<ShoppingCartItemRequestModel, ShoppingCartItem>();
                cfg.CreateMap<ShoppingCartRequestModel, ShoppingCart>();
                cfg.CreateMap<PaymentMethodRequestModel, PaymentMethod>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
