using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.DataTransferObjects.Stripe
{
    public record AddStripePayment(
          string CustomerId,
          string ReceiptEmail,
          string Description,
          string Currency,
          long Amount);
}
