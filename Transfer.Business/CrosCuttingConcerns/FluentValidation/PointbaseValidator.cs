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
    public class PointBaseValidator : AbstractValidator<PointBase>
    {
        public PointBaseValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CountryCode).NotNull();
            RuleFor(x => x.CountryName).NotNull();
            RuleFor(x => x.Latitude).NotNull();
            RuleFor(x => x.LongiTude).NotNull();
            RuleFor(x => x.Name).NotNull();
           
        }
    }
}
