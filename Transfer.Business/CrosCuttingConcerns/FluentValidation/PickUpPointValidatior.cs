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
    public class PickUpPointValidator : AbstractValidator<PickUpPoint>
    {
        public PickUpPointValidator()
        {
            RuleFor(x => x.VehicleId).NotNull();
            RuleFor(x => x.Vehicle).NotNull();

        }
    }
}
