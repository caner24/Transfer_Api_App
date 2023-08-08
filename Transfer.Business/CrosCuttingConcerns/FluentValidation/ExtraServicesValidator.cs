﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Transfer.Entity;

namespace Transfer.Business.CrosCuttingConcerns.FluentValidation
{
    public class ExtraServicesValidator : AbstractValidator<ExtraServices>
    {
        public ExtraServicesValidator()
        {
            RuleFor(x => x.ExtraServiceType).NotNull();
            RuleFor(x => x.TotalPrice).NotNull().WithMessage("Total Price boş olamaz");

        }
    }
}
