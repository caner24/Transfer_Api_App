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
    public class PoinBaseValidator : AbstractValidator<PointBase>
    {
        public PoinBaseValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş olamaz");
            RuleFor(x => x.CountryCode).NotNull().WithMessage("CountryCode boş olamaz");
            RuleFor(x => x.CountryName).MaximumLength(40).WithMessage("CountryName 40 karakteri geçemez");
            RuleFor(x => x.Latitude).NotNull().WithMessage("Latitude boş olamaz");
            RuleFor(x => x.LongiTude).NotNull().WithMessage("Longitude boş olamaz");
            RuleFor(x => x.Name).NotNull().WithMessage("Name boş olamaz");
           
        }
    }
}
