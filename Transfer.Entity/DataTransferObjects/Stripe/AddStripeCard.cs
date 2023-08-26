using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.DataTransferObjects.Stripe
{
    public record AddStripeCard(
        string Name,
        string CardNumber,
        string ExpirationYear,
        string ExpirationMonth,
        string Cvc);
}
