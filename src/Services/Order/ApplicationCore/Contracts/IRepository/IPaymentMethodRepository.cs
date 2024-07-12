using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract.IRepository
{
    public interface IPaymentMethodRepository
    {
        Task<int> SavePaymentMethod(PaymentMethod paymentMethods);
        Task<int> UpdatePaymentMethod(PaymentMethod paymentMethods);
        Task<int> DeletePaymentMethod(int paymentMethodId);
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods(Guid customerId);
    }
}
