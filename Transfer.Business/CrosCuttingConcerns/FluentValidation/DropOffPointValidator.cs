using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class DropOffPointValidator : AbstractValidator<DropOffPoint>
    {
        public DropOffPointValidator()
        {
            RuleFor(x => x.VehicleId).NotNull().WithMessage("VehicleId boş olamaz");
            RuleFor(x => x.Vehicle).NotNull().WithMessage("Vehicle boş olamaz");

        }
    }
}
