using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity.DataTransferObjects.Stripe;

namespace Transfer.Application.Transfer.Infrastructure.EntityFramework
{
    public class StripeAppManager : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;
        public StripeAppManager(
        ChargeService chargeService,
        CustomerService customerService,
        TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
        }


        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = "cus_OWWmYqTwWWNksC",
                ReceiptEmail = "cnr24clp@gmail.com",
                Description = "Demo mock payments",
                Currency = payment.Currency,
                Amount = payment.Amount
            };

            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            return new StripePayment(
              createdPayment.CustomerId,
              createdPayment.ReceiptEmail,
              createdPayment.Description,
              createdPayment.Currency,
              createdPayment.Amount,
              createdPayment.Id);
        }
    }
}
