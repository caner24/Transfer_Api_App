using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class TransfersValidator : AbstractValidator<Transfers>
    {
        public TransfersValidator()
        {
            RuleFor(x => x.TotalAmount).NotNull().WithMessage("Total Amount boş olamaz");
            RuleFor(x => x.BookingStatusType).NotNull().MaximumLength(250).WithMessage("Booking Status Type boş olamaz");
            RuleFor(x => x.VehicleId).NotNull().WithMessage("VehicleId boş olamaz");

        }
    }
}
