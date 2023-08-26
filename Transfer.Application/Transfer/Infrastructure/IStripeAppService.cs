using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity.DataTransferObjects.Stripe;

namespace Transfer.Application.Transfer.Infrastructure
{
    public interface IStripeAppService
    {
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}
